import 'zone.js/dist/zone-node';
import 'reflect-metadata'; //
import 'zone.js';
import 'rxjs/Rx'; //

// import 'bootstrap/dist/css/bootstrap.min.css';
// import 'bootstrap/dist/css/bootstrap-theme.min.css';
// import 'bootstrap/dist/js/bootstrap.min.js';

import { enableProdMode } from '@angular/core';

// import { platformServer, renderModuleFactory } from '@angular/platform-server'; //

import * as express from 'express';
// import { ngUniversalEngine } from './universal-engine';
import { ngExpressEngine } from '@ngx-universal/express-engine';

// import { AppServerModuleNgFactory } from '../../aot/src/uni/app.server.ngfactory';
import { AppServerModule } from './app.server.module';

enableProdMode();

const server = express();

// set our angular engine as the handler for html files, so it will be used to render them.
server.engine('html', ngExpressEngine({
    bootstrap: AppServerModule
}));

// set default view directory
server.set('views', 'dist');

server.use('/', express.static('dist', {index: false})); //

server.get('*', (req, res) => {
  res.render('../dist/index.html', {
    req,
    res
  });
});

// handle requests for routes in the app.  ngExpressEngine does the rendering.
/*server.get(['/', '/download', '/statistics', '/developers', '/about'], (req, res) => {
    res.render('index.html', {req});
});

// handle requests for static files
server.get(['/*.js', '/*.css'], (req, res, next) => {
    const fileName: string = req.originalUrl;
    console.log(fileName);
    const root = fileName.startsWith('/node_modules/') ? '.' : 'src';
    res.sendFile(fileName, { root: root }, function (err) {
        if (err) {
            next(err);
        }
    });
});*/

// start the server
server.listen(3200, () => {
    console.log('listening on port 3200...');
});
