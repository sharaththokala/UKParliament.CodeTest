import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-person-management',

  templateUrl: './person-management.component.html',
  styleUrl: './person-management.component.scss'
})
export class PersonManagementComponent {
  people$: Observable<any>;

  constructor(private personService: PersonService) {
    this.people$ = this.personService.getPeople();
  }
}