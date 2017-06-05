import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'errorDescription'
})

export class ErrorDescriptionPipe implements PipeTransform {
    transform(value: any, ...args: any[]): any {
        switch (value) {
            case 10: {
                return "File is empty";
            }
            case 20: {
                return "File doesn't have extension";
            }
            case 30: {
                return "File extension is invalid";
            }
            case 40: {
                return "File format doesn't supported";
            }
            case 99:
            default: {
                return "An unexpected error occurred. Please try again. If the problem persists, please contact the developer.";
            }
        }
    }
}