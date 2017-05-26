import { Component, OnInit } from '@angular/core';
import iFrameResize from 'iframe-resizer/js/iframeResizer.min.js';

@Component({
    templateUrl: 'developers-rest-api.component.html'
})

export class DevelopersRestApiComponent implements OnInit {
    constructor() { }

    ngOnInit() {
        iFrameResize({ log: true }, '#swaggerFrame');
    }
}