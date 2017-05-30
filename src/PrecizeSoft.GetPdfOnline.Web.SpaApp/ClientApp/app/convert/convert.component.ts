import { Component, OnInit } from '@angular/core';

import { ConverterService } from './shared/converter.service';
import { ConvertJob } from './shared/convert-job';

@Component({
    selector: 'convert-view',
    styleUrls: [ './convert.component.css' ],
    templateUrl: './convert.component.html'
})

export class ConvertComponent implements OnInit {

    private sessionId: string = '9516e8e5-ec8e-4c12-8b40-0809ec0bafe3';

    supportedFormatsString: string;

    convertJobs: ConvertJob[];

    constructor(private converterService: ConverterService) { }

    ngOnInit() {
        this.converterService.getSupportedFormatsString()
        .then(response => this.supportedFormatsString = response);

        this.reloadJobs();
    }

    convert(event): void {
        let fileList: FileList = event.target.files;
        if(fileList.length > 0) {
            let file: File = fileList[0];
            this.converterService.convert(file, this.sessionId)
            .then(() => this.reloadJobs());
        }
    }

    reloadJobs() {
        this.converterService.getJobsBySession(this.sessionId)
        .then(r => this.convertJobs = r);
        /*.then(r => r.forEach((v) => {
            v.outputFile.fileName = v.outputFile.getFileNameWithoutExtension();
        }));*/
    }
}