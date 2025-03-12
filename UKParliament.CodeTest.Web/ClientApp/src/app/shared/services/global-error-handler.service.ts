import { ErrorHandler, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class GlobalErrorHandlerService implements ErrorHandler {

  constructor(private router: Router) { }

  handleError(error: any): void {
    this.router.navigate(['/error-page']);
  }
}
