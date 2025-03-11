import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonListComponent } from './components/person-list/person-list.component';
import { PersonManagementComponent } from './pages/person-management/person-management.component';
import { PersonService } from './services/person.service';
import { PersonFormComponent } from './components/person-form/person-form.component';
import { AddPersonComponent } from './pages/add-person/add-person.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    PersonListComponent, 
    PersonManagementComponent, 
    PersonFormComponent,
    AddPersonComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [PersonManagementComponent],
  providers: [PersonService]
})
export class PersonModule { }
