import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonService } from '../../services/person.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonModel } from '../../../../app/shared/interface/person-model';
import { DepartmentService } from '../../services/department.service';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrl: './edit-person.component.scss'
})
export class EditPersonComponent {
  departments$: Observable<any>;
  person$: Observable<any>;
  id: number;

  constructor(private personService: PersonService, private departmentService: DepartmentService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.departments$ = this.departmentService.getDepartments();
    this.id = this.activatedRoute.snapshot.params['id'];
    this.person$ = this.personService.getPersonById(this.id);
  }

  onFormSubmit(person: PersonModel) {
    this.personService.savePerson(person, this.id).subscribe(() => {
      this.router.navigate(['/']);
    }
    );
  }

  onFormCancel() {
    this.router.navigate(['/']);
  }
}
