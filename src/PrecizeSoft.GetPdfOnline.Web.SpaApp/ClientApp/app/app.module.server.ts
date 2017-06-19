import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
// import { APP_BASE_HREF } from '@angular/common';

import { sharedConfig } from './app.module.shared';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        ServerModule,
        ...sharedConfig.imports
    ]/*,
    providers: [
        {
            provide: APP_BASE_HREF,
            useValue: '/ru/')
        }
    ]*/
})
export class AppModule {
}
