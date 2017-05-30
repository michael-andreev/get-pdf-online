import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

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
        AppRoutingModule,
        ConvertModule,
        DownloadModule,
        StatisticsModule,
        DevelopersModule,
        AboutModule
    ]
};
