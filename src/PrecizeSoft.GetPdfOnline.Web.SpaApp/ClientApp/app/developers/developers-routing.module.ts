import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DevelopersComponent } from './developers.component';

import { DevelopersOverviewComponent } from './developers-overview.component';
import { DevelopersRestApiComponent } from './developers-rest-api.component';
import { DevelopersSoapApiComponent } from './developers-soap-api.component';

const developersRoutes: Routes = [
    {
        path: 'api',
        pathMatch: 'full',
        redirectTo: 'developers/rest-api'
    },
    {
        path: 'soap',
        pathMatch: 'full',
        redirectTo: 'developers/soap-api'
    },
    {
        // path: '',
        path: 'developers',
        component: DevelopersComponent,
        children: [
            {
                path: 'overview',
                component: DevelopersOverviewComponent
            },
            {
                path: 'rest-api',
                component: DevelopersRestApiComponent
            },
            {
                path: 'soap-api',
                component: DevelopersSoapApiComponent
            },
            {
                path: '**',
                redirectTo: 'overview'
            }
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(developersRoutes)],
  exports: [RouterModule]
})
export class DevelopersRoutingModule { }
