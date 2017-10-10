import * as Raven from 'raven-js';
import { ToastyService } from 'ng2-toasty';
import { ErrorHandler, Inject, NgZone } from '@angular/core';

export class AppErrorHandler implements ErrorHandler {

    constructor(@Inject(ToastyService) private toastyService: ToastyService) {}

    handleError(error: any): void {
        Raven.captureException(error.originalError || error);
        console.log('Someting went wrong.');
        // this.ngZone.run(()=>{
        //     this.toastyService.error({
        //         title: 'Error',
        //         msg : 'An unexpected error happend.',
        //         theme: 'bootstrap',
        //         showClose: true,
        //         timeout: 5000
        //    });      
        // });       
    }

}