import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonService } from '../../services/person.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonModel } from '../../../../app/shared/interface/person-model';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrl: './edit-person.component.scss'
})
export class EditPersonComponent {
  departments$: Observable<any>;
  person$: Observable<any>;
  id: number;

  constructor(private service: PersonService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.departments$ = this.service.getDepartments();
    this.id = this.activatedRoute.snapshot.params['id'];
    this.person$ = this.service.getPersonById(this.id);
  }

   onFormSubmit(person: PersonModel) {
      this.service.savePerson(person, this.id).subscribe(
        res => {
          this.router.navigate(['/']);
        }
      );
    }
  
    onFormCancel() {
      this.router.navigate(['/']);
    }
}
