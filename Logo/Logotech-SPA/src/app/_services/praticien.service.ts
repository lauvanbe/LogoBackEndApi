import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Docteur } from '../_models/docteur';

@Injectable({
  providedIn: 'root'
})
export class PraticienService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDocteurs(): Observable<Docteur[]> {
    return this.http.get<Docteur[]>(this.baseUrl + 'docteurs');
  }

  getDocteur(id): Observable<Docteur> {
    return this.http.get<Docteur>(this.baseUrl + 'docteurs/' + id);
  }

  addDocteur(docteur: Docteur) {
    return this.http.post(this.baseUrl + 'docteurs', docteur);
  }

  updateDocteur(id: number, docteur: Docteur) {
    return this.http.put(this.baseUrl + 'docteurs/edit/' + id, docteur);
  }

  deleteDocteur(id: number) {
    return this.http.delete(this.baseUrl + 'docteurs/' + id);
  }
}
