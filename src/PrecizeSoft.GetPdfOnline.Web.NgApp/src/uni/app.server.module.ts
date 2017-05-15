import { NgModule } from '@angular/core';
// import { BrowserModule } from '@angular/platform-browser'; //
import { ServerModule } from '@angular/platform-server';

import { APP_BASE_HREF } from '@angular/common';
import { AppComponent } from '../app/app.component';
import { AppModule } from '../app/app.module';

@NgModule({
  imports: [
    ServerModule,
    AppModule
  ],
  bootstrap: [
    AppComponent
  ],
  providers: [
    {provide: APP_BASE_HREF, useValue: '/'}
  ]
})
export class AppServerModule {
}
