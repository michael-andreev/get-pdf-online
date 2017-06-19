import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AboutComponent } from './about.component';

import { AboutHomeComponent } from './about-home.component';
import { AboutContactUsComponent } from './about-contact-us.component';
import { AboutTechnologiesComponent } from './about-technologies.component';

const aboutRoutes: Routes = [
  // { path: '', component: AboutComponent }
  {
    path: 'about',
    component: AboutComponent,
    children: [
            {
                path: 'home',
                component: AboutHomeComponent
            },
            {
                path: 'contact-us',
                component: AboutContactUsComponent
            },
            {
                path: 'technologies',
                component: AboutTechnologiesComponent
            },
            {
                path: '**',
                redirectTo: 'home'
            }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(aboutRoutes)],
  exports: [RouterModule]
})
export class AboutRoutingModule { }
