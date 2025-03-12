import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentModel } from '../../../app/shared/interface/department-model';

@Injectable()
export class DepartmentService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getDepartments(): Observable<DepartmentModel[]> {
    console.log(this.baseUrl);
    return this.http.get<DepartmentModel[]>(`${this.baseUrl}api/department`);
  }
}