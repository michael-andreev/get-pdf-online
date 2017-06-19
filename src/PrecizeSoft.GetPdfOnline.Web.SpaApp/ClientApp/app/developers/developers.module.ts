import { NgModule } from '@angular/core';

// import {PrismComponent} from 'angular-prism';
import {CodeHighlighterModule} from 'primeng/components/codehighlighter/codehighlighter';

import { DevelopersComponent } from './developers.component';
import { DevelopersRoutingModule } from './developers-routing.module';

import { DevelopersOverviewComponent } from './developers-overview.component';
import { DevelopersRestApiComponent } from './developers-rest-api.component';
import { DevelopersSoapApiComponent } from './developers-soap-api.component';

@NgModule({
    imports: [
        DevelopersRoutingModule,
        CodeHighlighterModule
    ],
    declarations: [
        // PrismComponent,
        DevelopersComponent,
        DevelopersOverviewComponent,
        DevelopersRestApiComponent,
        DevelopersSoapApiComponent
    ],
    providers: [/* TODO: Providers go here */]
})
export class DevelopersModule { }
