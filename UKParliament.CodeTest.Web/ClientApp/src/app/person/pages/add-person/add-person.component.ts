import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { Router } from '@angular/router';
import { PersonModel } from '../../../../app/shared/interface/person-model';
import { Observable } from 'rxjs';
import { DepartmentService } from '../../services/department.service';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrl: './add-person.component.scss'
})
export class AddPersonComponent {
  departments$: Observable<any>;
  constructor(private personService: PersonService, private departmentService: DepartmentService, private router: Router) {
    this.departments$ = this.departmentService.getDepartments();
  }

  onFormSubmit(person: PersonModel) {
    this.personService.addPerson(person).subscribe(() => {
      this.router.navigate(['/']);
    }
    );
  }

  onFormCancel() {
    this.router.navigate(['/']);
  }
}
