import { Component, OnInit, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

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
    isClientSide: boolean;

    summaryStat: SummaryStat;
    statByFileCategories: StatByFileCategory[];
    dailyStat: StatByHour[];

    selectedDate: Date = new Date();

    statByFileCategoriesChartData: any;
    statByFileCategoriesChartOptions: any;
    dailyStatChartData: any;

    constructor(@Inject(PLATFORM_ID) private platformId: Object, private statisticsService: StatisticsService) {
    }

    getStatistics(): void {
        this.statisticsService
        .getSummaryStat()
        .then(summaryStatistics => this.summaryStat = summaryStatistics);

        this.statisticsService
        .getStatByFileCategories()
        .then(stat => this.statByFileCategories = stat)
        .then(stat => this.statByFileCategoriesChartData = this.CreateStatByFileCategoriesChartData(stat));

        // var dt = new Date(Date.UTC(2017,5,2));
        // console.log(dt);

        this.loadDailyStat();
    }

    ngOnInit() {
        this.isClientSide = isPlatformBrowser(this.platformId);

        this.getStatistics();
    }

    dateSelected() {
        this.loadDailyStat();
    }

    private loadDailyStat() {
        this.statisticsService
        .getDailyStat(this.selectedDate)
        .then(stat => stat.sort((a, b) => a.hour - b.hour))
        .then(stat => {
            this.dailyStat = stat;
            this.dailyStatChartData = {
                labels: ['00', '', '', '03', '', '', '06', '', '', '09', '', '', '12', '', '', '15', '', '', '18', '', '', '21', '', ''],
                datasets: [
                    {
                        label: 'Queries count',
                        backgroundColor: '#8cd3ff',
                        borderColor: '#5cbae6',
                        // fill: false,
                        data: this.createDailyStatChartDatasetData(this.dailyStat)
                    }
                ]
            };
        });
    }

    private ConvertFileCategoryCodeToNumber(code: string): number {
        let catNumber: number;

        switch (code) {
            case 'Document': catNumber = 0; break;
            case 'Spreadsheet': catNumber = 1; break;
            case 'Presentation': catNumber = 2; break;
            case 'Diagram': catNumber = 3; break;
            case 'Image': catNumber = 4; break;
            case 'UNKNOWN': catNumber = 5; break;
            default: console.log('Unknown FileCategoryCode');
        };

        return catNumber;
    }

    private CreateStatByFileCategoriesChartData(stat: StatByFileCategory[]): any {
        let a: number[] = new Array(24);
        a.fill(0);        
        
        stat.forEach((entry) => a[this.ConvertFileCategoryCodeToNumber(entry.fileCategoryCode)] = entry.totalCount);

        return {
            labels: ['Documents', 'Spreadsheets', 'Presentations', 'Diagrams', 'Images', 'Other'],
            datasets: [
                {
                    data: a,
                    backgroundColor: [
                        "#5cbae6",
                        "#b6d957",
                        "#fac364",
                        '#8cd3ff',
                        '#d998cb',
                        '#f2d249'
                    ]
                }
            ]    
        };        
    }

    private createDailyStatChartDatasetData(stat: StatByHour[]): number[] {
        let a: number[] = new Array(24);
        a.fill(0);

        stat.forEach((entry) => a[entry.hour] = entry.totalCount);

        return a;
    }
}