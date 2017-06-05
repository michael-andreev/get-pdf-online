import { Component, OnInit, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { LocalStorageService } from 'angular-2-local-storage';
import { UUID } from 'angular2-uuid';

import { ConverterService } from './shared/converter.service';
import { ConvertJob } from './shared/convert-job';
import { ConvertError } from './shared/convert-error';

@Component({
    selector: 'convert-view',
    styleUrls: [ './convert.component.css' ],
    templateUrl: './convert.component.html'
})

export class ConvertComponent implements OnInit {

    private sessionId: string;

    private randomValue: string = UUID.UUID();

    supportedFormatsString: string;

    convertJobs: ConvertJob[];

    processingFilesCount = 0;

    errors: ConvertError[] = [];

    constructor(@Inject(PLATFORM_ID) private platformId: Object, private localStorageService: LocalStorageService, private converterService: ConverterService) { }

    ngOnInit() {
        if (this.localStorageService.get('sessionId') === null) {
            this.localStorageService.set('sessionId', UUID.UUID());
        }
        
        if (isPlatformBrowser(this.platformId)) {
            this.sessionId = this.localStorageService.get('sessionId').toString();
        }

        /*if (isPlatformBrowser(this.platformId)) {
            alert(this.sessionId);
        }*/
        // hack
        /*if (this.sessionId === null)
        {
            this.sessionId = UUID.UUID();
        }*/

        this.converterService.getSupportedFormatsString()
        .then(response => this.supportedFormatsString = response);

        this.reloadJobs();
    }

    convert(event): void {
        let fileList: FileList = event.target.files;
        if(fileList.length > 0) {
            for (var i = 0; i < fileList.length; i++) {
                var file = fileList[i];
                
                this.processingFilesCount++;
                this.converterService.convert(file, this.sessionId)
                .then(() => this.reloadJobs()
                            .then(r => {
                                this.processingFilesCount--;
                                this.randomValue = UUID.UUID();
                            })
                            .catch(e => {
                                this.errors.push({
                                    message: `Can't load converted file. Please check your connection and try to refresh the page. If the problem persists, please contact the developer.`
                                });
                                this.processingFilesCount--;
                            }))
                .catch(fileName => {
                    this.errors.push({
                        message: `Can't load file "${fileName}". Please check your connection and try again. If the problem persists, please contact the developer.`
                    });
                    this.processingFilesCount--;
                });
            }
        }
    }

    reloadJobs(): Promise<ConvertJob[]> {
        return this.converterService.getJobsBySession(this.sessionId)
        .then(r => this.convertJobs = r);
    }

    deleteError(error: ConvertError) {
        this.errors.splice(this.errors.indexOf(error), 1);
    }

    deleteAll() {
        this.converterService.deleteSession(this.sessionId)
        .then(() => this.reloadJobs());
    }
}
