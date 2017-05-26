import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component'

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent
    ],
    imports: [
        AppRoutingModule
    ]
};
