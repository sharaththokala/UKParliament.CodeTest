import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { RouterLink, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { PersonModule } from './person/person.module';
import { PersonManagementComponent } from './person/pages/person-management/person-management.component';
import { AddPersonComponent } from './person/pages/add-person/add-person.component';
import { EditPersonComponent } from './person/pages/edit-person/edit-person.component';

@NgModule({ declarations: [
        AppComponent,
        HomeComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        FormsModule,
        PersonModule,
        RouterLink,
        RouterModule.forRoot([
            { path: '', component: PersonManagementComponent, pathMatch: 'full' },
            { path: 'add-person', component: AddPersonComponent },
            { path: 'edit-person/:id', component: EditPersonComponent },
        ])], providers: [provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
