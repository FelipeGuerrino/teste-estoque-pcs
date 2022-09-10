import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Computer } from '../models/computer';

@Injectable({
  providedIn: 'root'
})
export class ComputerService {

  constructor(private http: HttpClient) { }

  baseUrl = `${environment.baseUrl}api/computer`

  getAllComputers(): Observable<Computer[]> {
    return this.http.get<Computer[]>(this.baseUrl)
  }

  getSearchComputers(text: string): Observable<Computer[]> {
    return this.http.get<Computer[]>(`${this.baseUrl}/search/${text}`)
  }

  post(pc: Computer) {
    return this.http.post(this.baseUrl, pc)
  }
  put(pc: Computer) {
    return this.http.put(`${this.baseUrl}/${pc.id}`, pc)
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`)
  }
}
