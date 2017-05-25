import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StatisticsComponent } from './statistics.component';
import { StatisticsRoutingModule } from './statistics-routing.module';
import { StatisticsService } from './shared/statistics.service';

@NgModule({
    imports: [
        CommonModule,
        StatisticsRoutingModule
    ],
    declarations: [
        StatisticsComponent
    ],
    providers: [
        StatisticsService
    ]
})
export class StatisticsModule { }
