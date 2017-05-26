import { NgModule } from '@angular/core';

import { AboutComponent } from './about.component';
import { AboutRoutingModule } from './about-routing.module';

@NgModule({
    imports: [
        AboutRoutingModule
    ],
    declarations: [
        AboutComponent
    ],
    providers: [/* TODO: Providers go here */]
})
export class AboutModule { }
