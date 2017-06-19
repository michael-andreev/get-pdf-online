import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
// import { FormsModule }   from '@angular/forms';

import {DragDropModule} from 'primeng/components/dragdrop/dragdrop';

import { ConvertComponent } from './convert.component';
import { ConvertRoutingModule } from './convert-routing.module';

import { ConverterService } from './shared/converter.service';
import { ErrorDescriptionPipe } from './error-description.pipe';

@NgModule({
    imports: [
        // FormsModule,
        CommonModule,
        DragDropModule,
        ConvertRoutingModule
    ],
    declarations: [
        ConvertComponent,
        ErrorDescriptionPipe
    ],
    exports: [
    ],
    providers: [
        ConverterService
    ]// ,
    // id: 'ConvertModule',
})
export class ConvertModule { }
