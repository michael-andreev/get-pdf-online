import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConvertModule } from './convert/convert.module';
import { DownloadModule } from './download/download.module';
import { StatisticsModule } from './statistics/statistics.module';
import { DevelopersModule } from './developers/developers.module';
import { AboutModule } from './about/about.module';

const routes: Routes = [
  { path: '', loadChildren: 'app/convert/convert.module#ConvertModule' },
  { path: 'download', loadChildren: 'app/download/download.module#DownloadModule' },
  { path: 'statistics', loadChildren: 'app/statistics/statistics.module#StatisticsModule' },
  { path: 'developers', loadChildren: 'app/developers/developers.module#DevelopersModule' },
  { path: 'about', loadChildren: 'app/about/about.module#AboutModule' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

//export const routedComponents = [ConvertComponent];
