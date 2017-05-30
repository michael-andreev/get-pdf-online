import { Component, OnInit } from '@angular/core';

import { StatisticsService } from './shared/statistics.service';
import { Statistics } from './shared/statistics';
import { SummaryStat } from './shared/summary-stat';
import { StatByFileCategory } from './shared/stat-by-file-category';
import { StatByHour } from './shared/stat-by-hour';

import { ChartModule } from 'primeng/primeng';

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

        this.statisticsService
        .getSummaryStat()
        .then(summaryStatistics => this.statistics.summary = summaryStatistics);

        this.statisticsService
        .getStatByFileCategories()
        .then(stat => this.statistics.statByFileCategories = stat);

        var dt = new Date(Date.UTC(2017,4,28));

        this.statisticsService
        .getDailyStat(dt)
        .then(stat => this.statistics.dailyStat = stat);
    }

    ngOnInit() {
        this.getStatistics();
    }
}