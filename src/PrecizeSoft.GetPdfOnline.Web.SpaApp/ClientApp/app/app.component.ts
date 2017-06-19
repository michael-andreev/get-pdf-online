import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Router, NavigationEnd } from '@angular/router';
declare let ga: Function; // Google Analytics

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GetPDF.online';

  currentPath: string;

  currentLanguage: string;

  constructor(private router: Router, @Inject(PLATFORM_ID) private platformId: Object, @Inject('LOCALE') private locale) {
    router.events.subscribe((event) => {
      this.currentPath = router.url;
      if (event instanceof NavigationEnd) {
        if (typeof ga === 'function') {
          ga('set', 'page', event.urlAfterRedirects);
          ga('send', 'pageview');
        }
      }
    });
  
    // Fix bug with providers on the client side when SkipCodeGeneration=false in webpack.config
    if (isPlatformBrowser(platformId)) {
      this.locale = document['locale'];
    }

    switch (this.locale) {
      case 'en': this.currentLanguage = 'English'; break;
      case 'ru': this.currentLanguage = 'Русский'; break;
      default: throw new Error('Unknown locale.');
    }
  }
}
