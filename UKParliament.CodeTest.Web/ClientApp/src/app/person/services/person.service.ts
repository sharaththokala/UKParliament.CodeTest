import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonListItemModel } from '../../../app/shared/interface/person-list-item-model';
import { PersonModel } from '../../../app/shared/interface/person-model';

@Injectable()
export class PersonService {
  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.url = `${this.baseUrl}api/person`;
  }

  getPeople(): Observable<PersonListItemModel[]> {
    return this.http.get<PersonListItemModel[]>(this.url);
  }

  getPersonById(id: number): Observable<PersonModel> {
    return this.http.get<PersonModel>(`${this.url}/${id}`);
  }

  addPerson(data: PersonModel): Observable<any> {
    return this.http.post(`${this.url}`, data);
  }

  savePerson(data: PersonModel, id: number): Observable<any> {
    return this.http.put(`${this.url}/${id}`, data);
  }
}