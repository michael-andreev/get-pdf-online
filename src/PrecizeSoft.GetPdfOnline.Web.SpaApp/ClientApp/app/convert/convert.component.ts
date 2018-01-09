import { Component, OnInit, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { UUID } from 'angular2-uuid';
import { CookieService } from 'ngx-cookie';
import * as moment from 'moment';

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

    constructor(@Inject(PLATFORM_ID) private platformId: Object,
                private cookieService: CookieService, private converterService: ConverterService) { }

    ngOnInit() {
        this.converterService.getSupportedFormatsString()
        .then(response => this.supportedFormatsString = response);
    
        if (isPlatformBrowser(this.platformId)) {
            this.sessionId = this.cookieService.get('sessionId');

            if (this.sessionId == null) {
                this.sessionId = UUID.UUID();

                var yearFromNow = new Date();
                yearFromNow.setFullYear(yearFromNow.getFullYear() + 1);

                this.cookieService.put('sessionId', this.sessionId, { expires: yearFromNow });
            }

            this.reloadJobs();
        }
    }

    convert(event): void {
        this.convertFiles(event.target.files);
    }

    dropFiles(event): void {
        this.convertFiles(event.dataTransfer.files);
    }

    convertFiles(fileList: FileList): void {
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
