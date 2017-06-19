// import 'reflect-metadata';
// import 'zone.js';
// import 'rxjs/add/operator/first';
import './server.polyfills';
import './server.vendor';

import { enableProdMode, isDevMode, ApplicationRef, NgZone, ValueProvider } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { platformDynamicServer, PlatformState, INITIAL_CONFIG } from '@angular/platform-server';
import { createServerRenderer, RenderResult } from 'aspnet-prerendering';
// import { AppModule } from './app/app.module.server';
import { AppModuleNgFactory } from './ngfactory/app/app.module.server.ngfactory';

// import { APP_BASE_HREF } from '@angular/common';

// enableProdMode(); //Don't work with multiple applications. Moved to vendor.webpack to call once on server

export default createServerRenderer(params => {
    const providers = [
        { provide: INITIAL_CONFIG, useValue: { document: '<app></app>', url: params.url } },
        { provide: 'ORIGIN_URL', useValue: params.origin },
        { provide: 'LOCALE', useValue: params.data.locale },
        {
            provide: APP_BASE_HREF,
            useValue: '/' + params.data.locale
        }
    ];

    return platformDynamicServer(providers).bootstrapModuleFactory(AppModuleNgFactory).then(moduleRef => {
        const appRef = moduleRef.injector.get(ApplicationRef);
        const state = moduleRef.injector.get(PlatformState);
        const zone = moduleRef.injector.get(NgZone);

        return new Promise<RenderResult>((resolve, reject) => {
            zone.onError.subscribe(errorInfo => reject(errorInfo));
            appRef.isStable.first(isStable => isStable).subscribe(() => {
                // Because 'onStable' fires before 'onError', we have to delay slightly before
                // completing the request in case there's an error to report
                setImmediate(() => {
                    resolve({
                        html: state.renderToString()
                    });
                    moduleRef.destroy();
                });
            });
        });
    });
});
