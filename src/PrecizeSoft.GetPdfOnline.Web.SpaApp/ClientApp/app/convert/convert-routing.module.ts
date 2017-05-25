import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConvertComponent } from './convert.component';

const convertRoutes: Routes = [
    { path: '', component: ConvertComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(convertRoutes)],
  exports: [RouterModule]
})
export class ConvertRoutingModule { }

// export const routedComponents = [ConvertComponent];
