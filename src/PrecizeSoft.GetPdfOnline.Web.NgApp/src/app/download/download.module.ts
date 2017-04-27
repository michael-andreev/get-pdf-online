import { NgModule } from '@angular/core';

import { DownloadComponent } from './download.component';
import { DownloadRoutingModule } from './download-routing.module';

@NgModule({
    imports: [
        DownloadRoutingModule
    ],
    declarations: [
        DownloadComponent
    ],
    providers: [/* TODO: Providers go here */]
})
export class DownloadModule { }
