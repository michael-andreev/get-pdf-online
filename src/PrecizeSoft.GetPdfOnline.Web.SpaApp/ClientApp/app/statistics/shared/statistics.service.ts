import { Injectable, Inject } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import * as moment from 'moment';

import { Statistics } from './statistics';
import { SummaryStat } from './summary-stat';
import { StatByFileCategory } from './stat-by-file-category';
import { StatByHour } from './stat-by-hour';
import { STATISTICS } from './mock-statistics';

@Injectable()
export class StatisticsService {

  // private headers = new Headers({'Content-Type': 'application/json'});
  private summaryStatUrl = '/api/statistics/v1/summary';
  private statByFileCategoriesUrl = '/api/statistics/v1/fileCategories';
  private statByDateUrl = '/api/statistics/v1/hours/getByDate?dateWithTimeZone=';

  constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) { }

  getStatistics(): Promise<Statistics> {
      return Promise.resolve(STATISTICS);
      // return Promise.resolve(new Statistics() { summary = this.getSummaryStatistics() });
  }

  getSummaryStat(): Promise<SummaryStat> {
      return this.http.get(this.originUrl + this.summaryStatUrl)
          .toPromise()
          .then(response => response.json() as SummaryStat)
          .catch(this.handleError);
  }

  getStatByFileCategories(): Promise<StatByFileCategory[]> {
      return this.http.get(this.originUrl + this.statByFileCategoriesUrl)
          .toPromise()
          .then(response => response.json() as StatByFileCategory[])
          .catch(this.handleError);
  }


  getDailyStat(date: Date): Promise<StatByHour[]> {
      return this.http.get(`${this.originUrl}${this.statByDateUrl}${moment(date).format('YYYY-MM-DDZ')}`)
          .toPromise()
          .then(response => response.json() as StatByHour[])
          .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
