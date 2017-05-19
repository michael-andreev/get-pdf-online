import { BrowserModule } from '@angular/platform-browser';
import { ServerModule } from '@angular/platform-server';
import { NgModule } from '@angular/core';
import { AppComponent } from './components/app/app.component'
import { AppModule } from './app.module';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule.withServerTransition({
            appId: 'gpo-universal'
        }),
        ServerModule,
        AppModule
    ]
})
export class ServerAppModule {
}
