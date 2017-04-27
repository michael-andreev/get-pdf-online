import { NgModule } from '@angular/core';

import { StatisticsComponent } from './statistics.component';
import { StatisticsRoutingModule } from './statistics-routing.module';

@NgModule({
    imports: [
        StatisticsRoutingModule
    ],
    declarations: [
        StatisticsComponent
    ],
    providers: [/* TODO: Providers go here */]
})
export class StatisticsModule { }
