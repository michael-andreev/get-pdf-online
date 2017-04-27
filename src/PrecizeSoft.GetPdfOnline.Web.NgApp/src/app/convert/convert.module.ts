import { NgModule } from '@angular/core';

import { ConvertComponent } from './convert.component';
import { ConvertRoutingModule } from './convert-routing.module';

@NgModule({
    imports: [
        ConvertRoutingModule
    ],
    declarations: [
        ConvertComponent
    ],
    providers: [/* TODO: Providers go here */]
})
export class ConvertModule { }
