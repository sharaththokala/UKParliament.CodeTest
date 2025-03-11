import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonListComponent } from './components/person-list/person-list.component';
import { PersonManagementComponent } from './pages/person-management/person-management.component';
import { PersonService } from './services/person.service';

@NgModule({
  declarations: [PersonListComponent, PersonManagementComponent],
  imports: [
    CommonModule
  ],
  exports: [PersonManagementComponent],
  providers: [PersonService]
})
export class PersonModule { }
