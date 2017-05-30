import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DownloadComponent } from './download.component';

const downloadRoutes: Routes = [
  // { path: '', component: DownloadComponent }
  { path: 'download', component: DownloadComponent }
];

@NgModule({
  imports: [RouterModule.forChild(downloadRoutes)],
  exports: [RouterModule]
})
export class DownloadRoutingModule { }
