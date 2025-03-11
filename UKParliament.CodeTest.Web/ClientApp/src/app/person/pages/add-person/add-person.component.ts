import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { Router } from '@angular/router';
import { PersonModel } from '../../../../app/shared/interface/person-model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrl: './add-person.component.scss'
})
export class AddPersonComponent {
  departments$: Observable<any>;
  constructor(private service: PersonService, private router: Router) {
    this.departments$ = this.service.getDepartments();
  }

  onFormSubmit(person: PersonModel) {
    this.service.addPerson(person).subscribe(
      res => {
        this.router.navigate(['/']);
      }
    );
  }

  onFormCancel() {
    this.router.navigate(['/']);
  }
}
