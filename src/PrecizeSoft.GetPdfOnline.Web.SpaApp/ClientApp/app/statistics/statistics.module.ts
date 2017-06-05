import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';
import { HttpModule } from '@angular/http';

import { StatisticsComponent } from './statistics.component';
import { StatisticsRoutingModule } from './statistics-routing.module';
import { StatisticsService } from './shared/statistics.service';

import {CalendarModule} from 'primeng/components/calendar/calendar';
import {ChartModule} from 'primeng/components/chart/chart';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        HttpModule,
        CalendarModule,
        ChartModule,
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
