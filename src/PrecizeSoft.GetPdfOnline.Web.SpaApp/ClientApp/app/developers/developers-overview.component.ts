import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: 'developers-overview.component.html'
})

export class DevelopersOverviewComponent implements OnInit {

    htmlCode: string;

    constructor() { }

    ngOnInit() {
        this.htmlCode = `<html>
    <head>
        <meta charset="utf-8" />
    </head>
    <body>
        <h1>Convert to PDF</h1>
        <form action="http://getpdf.online/api/converter/v1/jobs"
              method="post" enctype="multipart/form-data" target="info">
            <input type="file" name="file"/>
            <input type="submit"/>
        </form>
        <h2>Convert information:</h2>
        <iframe name="info" style="width:100%;"></iframe>
        <h2>Download PDF:</h2>
        Copy "fileId" value without quotes from the block "outputFile" in the "Convert information" area here
        <input type="text"
               onkeyup="document.getElementById('link').href='http://getpdf.online/api/converter/v1/files/'+this.value;"/>
        and click <a id="link" href="#">Download</a>.
    </body>
</html>`;
    }
}