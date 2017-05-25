import './browser.polyfills';
// import './browser.vendor';
// import 'zone.js/dist/zone';  // Included with Angular CLI.

import { enableProdMode } from '@angular/core';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { BrowserAppModule } from './app/browser-app.module';

// import 'bootstrap';

import { environment } from './environments/environment';

const rootElemTagName = 'app'; // Update this if you change your root component selector

// Enable either Hot Module Reloading or production mode
if (module['hot']) {
    module['hot'].accept();
    module['hot'].dispose(() => {
        // Before restarting the app, we create a new root element and dispose the old one
        const oldRootElem = document.querySelector(rootElemTagName);
        const newRootElem = document.createElement(rootElemTagName);
        oldRootElem.parentNode.insertBefore(newRootElem, oldRootElem);
        // platform.destroy();
        modulePromise.then(appModule => appModule.destroy());
    });
}

if (environment.production) {
  enableProdMode();
}

const modulePromise = platformBrowserDynamic().bootstrapModule(BrowserAppModule);

// Boot the application, either now or when the DOM content is loaded
/*const platform = platformUniversalDynamic();
const bootApplication = () => { platform.bootstrapModule(AppModule); };
if (document.readyState === 'complete') {
    bootApplication();
} else {
    document.addEventListener('DOMContentLoaded', bootApplication);
}*/
