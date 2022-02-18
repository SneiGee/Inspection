import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ApiService {
  baseUrl = "https://localhost:7217/api/";
  
  constructor(private http: HttpClient) { }

  getInspectionList() {
    return this.http.get<any>(this.baseUrl + 'inspection');
  }

  addInspection(data: any) {
    return this.http.post(this.baseUrl + 'inspection', data);
  }

  updateInspection(id: number|string, data: any) {
    return this.http.put(this.baseUrl + 'inspection/' + id, data);
  }
  
  deleteInspection(id: number|string) {
    return this.http.delete(this.baseUrl + 'inspection/' + id);
  }

  // InspectionType 
  getInspectionTypeList(): Observable<any[]> {
    return this.http.get<any>(this.baseUrl + 'inspectionTypes');
  }

  addInspectionType(data: any) {
    return this.http.post(this.baseUrl + 'inspectionTypes', data);
  }

  updateInspectionType(id: number|string, data: any) {
    return this.http.put(this.baseUrl + 'inspectionTypes/' + id, data);
  }

  // Status
  getStatusList() {
    return this.http.get<any>(this.baseUrl + 'status');
  }

  addStatus(data: any) {
    return this.http.post(this.baseUrl + 'status', data);
  }

  updateStatus(id: number|string, data: any) {
    return this.http.put(this.baseUrl + 'status/' + id, data);
  }
}