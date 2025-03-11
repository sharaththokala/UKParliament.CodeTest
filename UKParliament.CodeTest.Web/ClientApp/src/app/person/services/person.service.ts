import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonListItemModel } from '../../../app/shared/interface/person-list-item-model';

@Injectable()
export class PersonService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getPeople(): Observable<PersonListItemModel[]> {
      const url = `https://localhost:44416/api/person`;
      return this.http.get<PersonListItemModel[]>(url);
    }
}