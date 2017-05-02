 import { Injectable } from '@angular/core';
// import { Headers, Http } from '@angular/http';

//import 'rxjs/add/operator/toPromise';

import { Statistics } from './statistics';
import { STATISTICS } from './mock-statistics';

@Injectable()
export class StatisticsService {

  // private headers = new Headers({'Content-Type': 'application/json'});
  // private statisticsUrl = 'statistics/api/statistics';  // URL to web api

  constructor(/*private http: Http*/) { }

  getStatistics(): Promise<Statistics> {
      return Promise.resolve(STATISTICS);
    /*return this.http.get(this.statisticsUrl)
               .toPromise()
               .then(response => response.json().data as Statistics)
               .catch(this.handleError);*/
  }

  /*private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }*/
}
