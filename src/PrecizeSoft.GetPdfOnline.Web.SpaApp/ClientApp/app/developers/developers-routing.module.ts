import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DevelopersComponent } from './developers.component';

import { DevelopersOverviewComponent } from './developers-overview.component';
import { DevelopersRestApiComponent } from './developers-rest-api.component';
import { DevelopersSoapApiComponent } from './developers-soap-api.component';
import { DevelopersUseOfflineComponent } from './developers-use-offline.component';
import { DevelopersNetLibrariesComponent } from './developers-net-libraries.component';
import { DevelopersSourceCodeComponent } from './developers-source-code.component';

const developersRoutes: Routes = [
    {
        path: 'api',
        redirectTo: 'developers/rest-api'
    },
    {
        path: 'soap',
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
                path: 'use-offline',
                component: DevelopersUseOfflineComponent
            },
            {
                path: 'net-libraries',
                component: DevelopersNetLibrariesComponent
            },
            {
                path: 'source-code',
                component: DevelopersSourceCodeComponent
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
