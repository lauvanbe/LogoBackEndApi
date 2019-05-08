import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from '../_models/Patient';

@Injectable({
  providedIn: 'root'
})

export class PatientService {
  baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getPatients(): Observable<Patient[]> {
      return this.http.get<Patient[]>(this.baseUrl + 'patients');
    }

    getPatient(id): Observable<Patient> {
      return this.http.get<Patient>(this.baseUrl + 'patients/' + id);
    }

    addPatient(patient: Patient) {
      return this.http.post(this.baseUrl + 'patients' , patient);
    }

    updatePatient(id: number, patient: Patient) {
      return this.http.put(this.baseUrl + 'patients/edit/' + id, patient);
    }

    setMainPhoto(patientId: number, id: number) {
      return this.http.post(this.baseUrl + 'patients/' + patientId + '/photos/' + id + '/setMain', {});
    }

    deletePhoto(patientId: number, id: number) {
      return this.http.delete(this.baseUrl + 'patients/' + patientId + '/photos/' + id);
    }

    deletPatient(id: number) {
      return this.http.delete(this.baseUrl + 'patients/' + id);
    }
}
