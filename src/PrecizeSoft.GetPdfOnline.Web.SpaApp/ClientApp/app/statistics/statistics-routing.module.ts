import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { StatisticsComponent } from './statistics.component';

const statisticsRoutes: Routes = [
  // { path: '', component: StatisticsComponent }
  { path: 'statistics', component: StatisticsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(statisticsRoutes)],
  exports: [RouterModule]
})
export class StatisticsRoutingModule { }
