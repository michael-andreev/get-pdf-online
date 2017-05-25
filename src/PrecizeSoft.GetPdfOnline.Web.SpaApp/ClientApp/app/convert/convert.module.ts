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
    exports: [
    ],
    providers: [/* TODO: Providers go here */]// ,
    // id: 'ConvertModule',
})
export class ConvertModule { }
