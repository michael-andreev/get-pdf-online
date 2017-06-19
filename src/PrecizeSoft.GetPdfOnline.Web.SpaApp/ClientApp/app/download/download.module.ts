import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DownloadComponent } from './download.component';
import { DownloadRoutingModule } from './download-routing.module';

@NgModule({
    imports: [
        DownloadRoutingModule,
        CommonModule
    ],
    declarations: [
        DownloadComponent
    ],
    providers: [/* TODO: Providers go here */]
})
export class DownloadModule { }
