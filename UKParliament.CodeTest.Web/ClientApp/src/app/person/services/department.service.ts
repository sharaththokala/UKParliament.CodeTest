import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentModel } from '../../../app/shared/interface/department-model';

@Injectable()
export class DepartmentService {

  url: string = `https://localhost:44416/api/department`;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getDepartments(): Observable<DepartmentModel[]> {
    return this.http.get<DepartmentModel[]>(this.url);
  }
}