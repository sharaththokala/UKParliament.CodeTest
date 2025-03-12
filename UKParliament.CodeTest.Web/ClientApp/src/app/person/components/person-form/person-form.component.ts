import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonModel } from '../../../../app/shared/interface/person-model';
import { DepartmentModel } from 'src/app/shared/interface/department-model';
import { FutureDateValidator } from 'src/app/shared/validators/future.date.validator';
import { InvalidNameValidator } from 'src/app/shared/validators/invalid.name.validator';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrl: './person-form.component.scss'
})
export class PersonFormComponent implements OnChanges {
  personForm!: FormGroup;
  @Input() departments!: DepartmentModel[];
  @Output() formSubmit: EventEmitter<PersonModel> = new EventEmitter();
  @Output() formCancel: EventEmitter<any> = new EventEmitter();
  @Input() person!: PersonModel;

  currentDate: Date;

  constructor(private formBuilder: FormBuilder) {
    this.currentDate = new Date();
  }

  ngOnChanges() {
    this.personForm = this.formBuilder.group({
      firstName: [this.person && this.person.firstName ? this.person.firstName : '', [Validators.required, Validators.max(100), InvalidNameValidator.invalidName]],
      lastName: [this.person && this.person.lastName ? this.person.lastName : '', [Validators.required, Validators.max(100), InvalidNameValidator.invalidName]],
      dateOfBirth: [this.person && this.person.dateOfBirth ? this.person.dateOfBirth : '', [Validators.required, FutureDateValidator.greaterThanToday]],
      departmentId: [this.person && this.person.departmentId ? this.person.departmentId : '', [Validators.required]],
    });

    this.personForm.valueChanges.subscribe((person: PersonModel) => {
      this.person = person;
    });
  }

  onFormSubmit() {
    if (this.personForm.valid) {
      this.formSubmit.emit(this.person);
    }
  }

  onFormCancel() {
    this.formCancel.emit();
  }
}
