import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LocalStorageModule } from 'angular-2-local-storage';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component'

import { ConvertModule } from './convert/convert.module';
import { DownloadModule } from './download/download.module';
import { StatisticsModule } from './statistics/statistics.module';
import { DevelopersModule } from './developers/developers.module';
import { AboutModule } from './about/about.module';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent
    ],
    imports: [
        LocalStorageModule.withConfig({
            prefix: 'getpdf.online',
            storageType: 'localStorage'
        }),
        AppRoutingModule,
        ConvertModule,
        DownloadModule,
        StatisticsModule,
        DevelopersModule,
        AboutModule
    ]
};
