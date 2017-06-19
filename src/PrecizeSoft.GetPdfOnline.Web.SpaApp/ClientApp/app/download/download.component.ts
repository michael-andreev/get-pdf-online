import { Component, OnInit } from '@angular/core';

@Component({
    styleUrls: [ './download.component.css' ],
    templateUrl: './download.component.html'
})

export class DownloadComponent implements OnInit {

    datePublished: Date = new Date(2017, 5, 9);
    
    constructor() { }

    ngOnInit() { }
}