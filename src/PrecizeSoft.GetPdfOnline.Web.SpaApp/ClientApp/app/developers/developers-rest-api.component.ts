import { Component, OnInit, OnDestroy, PLATFORM_ID, Inject, ViewChild } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

import iFrameResize from 'iframe-resizer/js/iframeResizer.min.js';

@Component({
    templateUrl: 'developers-rest-api.component.html'
})
export class DevelopersRestApiComponent implements OnInit, OnDestroy {
    constructor(@Inject(PLATFORM_ID) private platformId: Object) { }

    @ViewChild('swaggerFrame') swaggerFrame;

    ngOnInit() {
        if (isPlatformBrowser(this.platformId)) {
            iFrameResize({ log: false }, '#swaggerFrame');
        }
    }

    ngOnDestroy() {
        this.swaggerFrame.nativeElement.iFrameResizer.close();
    }
}