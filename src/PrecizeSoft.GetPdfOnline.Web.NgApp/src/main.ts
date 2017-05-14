import { enableProdMode } from '@angular/core';
import { platformBrowser } from '@angular/platform-browser';

// import { getTranslationProviders } from './app/i18n-providers';

import { AppModuleNgFactory } from './aot/app/app.module.ngfactory';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

console.log('Running AOT compiled');
platformBrowser().bootstrapModuleFactory(AppModuleNgFactory);
/*getTranslationProviders().then(providers => {
  const options = { providers };
  platformBrowserDynamic().bootstrapModule(AppModule, options);
});*/
