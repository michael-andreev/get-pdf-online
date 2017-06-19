import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { Headers, Http, RequestOptions } from '@angular/http';
import { isPlatformBrowser } from '@angular/common';

import 'rxjs/add/operator/toPromise';

import * as moment from 'moment';

import { StorageFileInfo } from './storage-file-info';
import { ConvertJob } from './convert-job';

@Injectable()
export class ConverterService {

  // private headers = new Headers({'Content-Type': 'application/json'});
  private getSupportedFormatsUrl = '/api/converter/v1/formats';
  private convertUrl = '/api/converter/v1/jobs';
  private getJobsBySessionUrl = '/api/converter/v1/jobs/getBySession?sessionId=';
  private deleteSessionUrl = '/api/converter/v1/sessions/';

  constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string, @Inject(PLATFORM_ID) private platformId: Object) {
        // Fix bug with Providers on the Client side
        if (isPlatformBrowser(platformId)) {
            this.originUrl = location.origin;
        }
  }

  getSupportedFormats(): Promise<string[]> {
      return this.http.get(this.originUrl + this.getSupportedFormatsUrl)
          .toPromise()
          .then(response => response.json() as string[])
          .catch(this.handleError);
  }

  getSupportedFormatsString(): Promise<string> {
      return this.getSupportedFormats()
      .then(response => response.sort().join(', '));
  }

  convert(file: File, sessionId: string): Promise<ConvertJob> {
      let formData : FormData = new FormData();
      formData.append('file', file, file.name);
      formData.append('sessionId', sessionId);

      // let headers = new Headers();
      // headers.append('Accept', 'application/json');
      // let options = new RequestOptions({ headers: headers });

      return this.http.post(this.originUrl + this.convertUrl, formData/*, options*/)
      .toPromise()
      .then(response => response.json() as ConvertJob)
      .catch(e => {
          // return Promise.reject(e);
          return Promise.reject(file.name);
      });
      // .catch(this.handleError);
  }

  getJobsBySession(sessionId: string): Promise<ConvertJob[]> {
      return this.http.get(this.originUrl + this.getJobsBySessionUrl + sessionId)
          .toPromise()
          .then(response => response.json() as ConvertJob[])
          .then(r => r.sort(this.compareConvertJobs));
          // .catch(this.handleError);
  }

  private compareConvertJobs(a: ConvertJob, b: ConvertJob) {
      return new Date(b.inputFile.createDateUtc).getTime() - new Date(a.inputFile.createDateUtc).getTime();
  }

  deleteSession(sessionId: string): Promise<void> {
      return this.http.delete(this.originUrl + this.deleteSessionUrl + sessionId)
          .toPromise()
          .then(response => null)
          .catch(this.handleError);
  }

  /*getStatByFileCategories(): Promise<StatByFileCategory[]> {
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
  }*/

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
