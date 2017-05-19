import 'zone.js/dist/zone-node';
// Polyfills
// import 'es6-promise';
// import 'es6-shim';
import './polyfills';

import 'reflect-metadata';
import 'zone.js';

// import './vendor';

import { enableProdMode } from '@angular/core';
import { INITIAL_CONFIG } from '@angular/platform-server';
import { createServerRenderer, RenderResult } from 'aspnet-prerendering';
// Grab the (Node) server-specific NgModule
import { ServerAppModule } from './app/server-app.module';
// ***** The ASPNETCore Angular Engine *****
import { ngAspnetCoreEngine, IEngineOptions, createTransferScript } from '@nguniversal/aspnetcore-engine';

enableProdMode(); // for faster server rendered builds

export default createServerRenderer(params => {

    /*
     * How can we access data we passed from .NET ?
     * you'd access it directly from `params.data` under the name you passed it
     * ie: params.data.WHATEVER_YOU_PASSED
     * -------
     * We'll show in the next section WHERE you pass this Data in on the .NET side
     */

    // Platform-server provider configuration
    const setupOptions: IEngineOptions = {
        appSelector: '<app></app>',
        ngModule: ServerAppModule,
        request: params,
        providers: [
            /* Other providers you want to pass into the App would go here
            *    { provide: CookieService, useClass: ServerCookieService }
    
            * ie: Just an example of Dependency injecting a Class for providing Cookies (that you passed down from the server)
              (Where on the browser you'd have a different class handling cookies normally)
            */
        ]
    };

    // ***** Pass in those Providers & your Server NgModule, and that's it!
    return ngAspnetCoreEngine(setupOptions).then(response => {

        // Want to transfer data from Server -> Client?

        // Add transferData to the response.globals Object, and call createTransferScript({}) passing in the Object key/values of data
        // createTransferScript() will JSON Stringify it and return it as a <script> window.TRANSFER_CACHE={}</script>
        // That your browser can pluck and grab the data from
        response.globals.transferData = createTransferScript({
            someData: 'Transfer this to the client on the window.TRANSFER_CACHE {} object',
            fromDotnet: params.data.thisCameFromDotNET // example of data coming from dotnet, in HomeController
        });

        return ({
            html: response.html,
            globals: response.globals
        });

    });
});

/*import 'zone.js/dist/zone-node';
import 'reflect-metadata';
// import { ngExpressEngine } from '@ng-universal/express-engine';

// import 'angular2-universal-polyfills';
// import 'angular2-universal-patch';
import 'zone.js';
import { createServerRenderer, RenderResult } from 'aspnet-prerendering';
import { enableProdMode } from '@angular/core';
// import { platformNodeDynamic } from 'angular2-universal';
import { INITIAL_CONFIG, platformServer } from '@angular/platform-server';

import { APP_BASE_HREF } from '@angular/common';

import { ServerAppModule } from './app/server-app.module';

enableProdMode();*/
//const platform = platformNodeDynamic();
/*const platform = platformServer();

export default createServerRenderer(params => {
    return new Promise<RenderResult>((resolve, reject) => {
        const requestZone = Zone.current.fork({
            name: 'angular-universal request',
            properties: {
                baseUrl: '/',
                requestUrl: params.url,
                originUrl: params.origin,
                preboot: false,
                document: '<app></app>'
            },
            onHandleError: (parentZone, currentZone, targetZone, error) => {
                // If any error occurs while rendering the module, reject the whole operation
                reject(error);
                return true;
            }
        });

        return requestZone.run<Promise<string>>(() => platform.bootstrapModule(ServerAppModule)).then(html => {
            resolve({ html: html });
        }, reject);
    });
});*/
/*
import { ORIGIN_URL } from './app/shared/constants/baseurl.constants';
// Grab the (Node) server-specific NgModule
import { ServerAppModule } from './app/server-app.module';
// Temporary * the engine will be on npm soon (`@universal/ng-aspnetcore-engine`)
import { ngAspnetCoreEngine, IEngineOptions, createTransferScript } from './polyfills/temporary-aspnetcore-engine';

enableProdMode();

export default createServerRenderer((params: BootFuncParams) => {

    // Platform-server provider configuration
    const setupOptions: IEngineOptions = {
        appSelector: '<app></app>',
        ngModule: ServerAppModule,
        request: params,
        providers: [
            // Optional - Any other Server providers you want to pass (remember you'll have to provide them for the Browser as well)
        ]
    };

    return ngAspnetCoreEngine(setupOptions).then(response => {
        // Apply your transferData to response.globals
        response.globals.transferData = createTransferScript({
            someData: 'Transfer this to the client on the window.TRANSFER_CACHE {} object',
            fromDotnet: params.data.thisCameFromDotNET // example of data coming from dotnet, in HomeController
        });

        return ({
            html: response.html,
            globals: response.globals
        });
    });
});
*/
