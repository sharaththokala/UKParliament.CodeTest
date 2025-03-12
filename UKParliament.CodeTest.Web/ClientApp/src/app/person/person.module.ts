import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonListComponent } from './components/person-list/person-list.component';
import { PersonManagementComponent } from './pages/person-management/person-management.component';
import { PersonService } from './services/person.service';
import { PersonFormComponent } from './components/person-form/person-form.component';
import { AddPersonComponent } from './pages/add-person/add-person.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditPersonComponent } from './pages/edit-person/edit-person.component';
import { RouterModule } from '@angular/router';
import { DepartmentService } from './services/department.service';

@NgModule({
  declarations: [
    PersonListComponent, 
    PersonManagementComponent, 
    PersonFormComponent,
    AddPersonComponent,
    EditPersonComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [PersonManagementComponent],
  providers: [PersonService, DepartmentService]
})
export class PersonModule { }
