import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { RouterLink, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PersonModule } from './person/person.module';
import { PersonManagementComponent } from './person/pages/person-management/person-management.component';
import { AddPersonComponent } from './person/pages/add-person/add-person.component';
import { EditPersonComponent } from './person/pages/edit-person/edit-person.component';
import { GlobalErrorHandlerService } from './shared/services/global-error-handler.service';
import { ErrorComponent } from './components/error/error.component';

@NgModule({ declarations: [
        AppComponent,
        ErrorComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        FormsModule,
        PersonModule,
        RouterLink,
        RouterModule.forRoot([
            { path: '', component: PersonManagementComponent, pathMatch: 'full' },
            { path: 'add-person', component: AddPersonComponent },
            { path: 'edit-person/:id', component: EditPersonComponent },
            { path: 'error-page', component: ErrorComponent },
        ])], providers: [provideHttpClient(withInterceptorsFromDi()), {provide: ErrorHandler, useClass: GlobalErrorHandlerService}] })
export class AppModule { }


