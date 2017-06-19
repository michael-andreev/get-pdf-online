import { NgModule } from '@angular/core';

import { AboutComponent } from './about.component';
import { AboutRoutingModule } from './about-routing.module';

import { AboutHomeComponent } from './about-home.component';
import { AboutContactUsComponent } from './about-contact-us.component';
import { AboutTechnologiesComponent } from './about-technologies.component';

@NgModule({
    imports: [
        AboutRoutingModule
    ],
    declarations: [
        AboutComponent,
        AboutHomeComponent,
        AboutContactUsComponent,
        AboutTechnologiesComponent
    ],
    providers: [/* TODO: Providers go here */]
})
export class AboutModule { }
