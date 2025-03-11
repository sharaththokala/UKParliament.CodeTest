import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonListItemModel } from '../../../app/shared/interface/person-list-item-model';
import { PersonModel } from '../../../app/shared/interface/person-model';
import { DepartmentModel } from '../../../app/shared/interface/department-model';

@Injectable()
export class PersonService {
  url: string = `https://localhost:44416/api/person`;

  getDepartmentUrl: string = `https://localhost:44416/api/department`;


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPeople(): Observable<PersonListItemModel[]> {
    return this.http.get<PersonListItemModel[]>(this.url);
  }

  getDepartments(): Observable<DepartmentModel[]> {
    return this.http.get<DepartmentModel[]>(this.getDepartmentUrl);
  }

  addPerson(data: PersonModel): Observable<any> {
    return this.http.post(this.url, data);
  }
}