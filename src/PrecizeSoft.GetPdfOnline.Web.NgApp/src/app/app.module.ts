import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
// import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

/*const routes: Routes = [
  // { path: '', component: ConvertComponent },
  // { path: 'download', component: DownloadComponent },
  // { path: 'statistics', component: StatisticsComponent },
  // { path: 'developers', loadChildren: 'app/developers/developers.module#DevelopersModule' },
  // { path: 'about', component: AboutComponent }

  // { path: '', component: ConvertComponent },
  { path: '', loadChildren: 'app/convert/convert.module#ConvertModule' },
  { path: 'download', loadChildren: 'app/download/download.module#DownloadModule' },
  { path: 'statistics', loadChildren: './statistics/statistics.module#StatisticsModule' },
  // { path: 'developers/overview', loadChildren: './developers/developers.module#DevelopersModule' },
  { path: 'developers', loadChildren: 'app/developers/developers.module#DevelopersModule' },
  { path: 'about', loadChildren: 'app/about/about.module#AboutModule' }
];*/

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
    // RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
