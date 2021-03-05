import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.interface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  GetAll(): Observable<Contact[]> {
    return this.http.get<Contact[]>(`${environment.apiUrl}/Contact/GetAll`);
  }

  GetItem(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${environment.apiUrl}/Contact/GetById/${id}`);
  }

  DeleteContact(id: number): Observable<any> {
    return this.http.delete<any>(`${environment.apiUrl}/Contact/Delete/${id}`);
  }

  UpdateContact(contact: Contact): Observable<number> {
    return this.http.put<number>(`${environment.apiUrl}/Contact/UpdateContact`, contact);
  }

  CreateContact(contact: Contact): Observable<number> {
    return this.http.post<number>(`${environment.apiUrl}/Contact/CreateContact`, contact);
  }
}
