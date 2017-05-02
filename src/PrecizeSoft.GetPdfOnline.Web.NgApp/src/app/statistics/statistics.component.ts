import { Component, OnInit } from '@angular/core';

import { StatisticsService } from './shared/statistics.service';
import { Statistics } from './shared/statistics';
import { SummaryStat } from './shared/summary-stat';
import { StatByFileCategory } from './shared/stat-by-file-category';
import { StatByHour } from './shared/stat-by-hour';

import { STATISTICS } from './shared/mock-statistics';

@Component({
    styleUrls: [ './statistics.component.css' ],
    templateUrl: './statistics.component.html'
})
export class StatisticsComponent implements OnInit {
    statistics: Statistics;

    constructor(private statisticsService: StatisticsService) { }

    getStatistics(): void {
        this.statisticsService
        .getStatistics()
        .then(statitstics => this.statistics = statitstics);
    }

    ngOnInit() {
        this.getStatistics();
    }
}