import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
  /*{ path: '', loadChildren: './convert/convert.module#ConvertModule' },
  { path: 'download', loadChildren: './download/download.module#DownloadModule' },
  { path: 'statistics', loadChildren: './statistics/statistics.module#StatisticsModule' },
  { path: 'developers', loadChildren: './developers/developers.module#DevelopersModule' },
  { path: 'about', loadChildren: './about/about.module#AboutModule' }*/
];

@NgModule({
  declarations: [
  ],
  imports: [
  RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

// export const routedComponents = [ConvertComponent];
