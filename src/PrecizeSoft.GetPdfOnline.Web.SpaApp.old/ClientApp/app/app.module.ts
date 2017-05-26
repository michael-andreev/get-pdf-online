// import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component'

@NgModule({
    // bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
    ],
    imports: [
        // BrowserModule,
        /*BrowserModule.withServerTransition({
            appId: 'gpo-universal'
        }),*/
        // UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        CommonModule,
        FormsModule,
        HttpModule,
        AppRoutingModule
    ]
})
export class AppModule {
}
