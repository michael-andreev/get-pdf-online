import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import helpers from '../../webpack/helpers';

// import { ConvertComponent } from './convert/convert.component';
// import { DownloadComponent } from './download/download.component';
// import { StatisticsComponent } from './statistics/statistics.component';
// import { AboutComponent } from './about/about.component';

/*import { ConvertModule } from './convert/convert.module';
import { DownloadModule } from './download/download.module';
import { StatisticsModule } from './statistics/statistics.module';
import { DevelopersModule } from './developers/developers.module';
import { AboutModule } from './about/about.module';*/

const routes: Routes = [
  // { path: '', component: ConvertComponent },
  // { path: 'download', component: DownloadComponent },
  // { path: 'statistics', component: StatisticsComponent },
  // { path: 'developers', loadChildren: 'app/developers/developers.module#DevelopersModule' },
  // { path: 'about', component: AboutComponent }

  // { path: '', component: ConvertComponent },
  { path: '', loadChildren: './convert/convert.module#ConvertModule' },
  { path: 'download', loadChildren: './download/download.module#DownloadModule' },
  { path: 'statistics', loadChildren: './statistics/statistics.module#StatisticsModule' },
  // { path: 'developers/overview', loadChildren: './developers/developers.module#DevelopersModule' },
  { path: 'developers', loadChildren: './developers/developers.module#DevelopersModule' },
  { path: 'about', loadChildren: './about/about.module#AboutModule' }

  /*{ path: '', loadChildren: () => ConvertModule },
  { path: 'download', loadChildren: () => DownloadModule },
  { path: 'statistics', loadChildren: () => StatisticsModule },
  // { path: 'developers/overview', loadChildren: './developers/developers.module#DevelopersModule' },
  { path: 'developers', loadChildren: () => DevelopersModule },
  { path: 'about', loadChildren: () => AboutModule }*/
];

@NgModule({
  declarations: [
  ],
  imports: [
  RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// export const routedComponents = [ConvertComponent];
