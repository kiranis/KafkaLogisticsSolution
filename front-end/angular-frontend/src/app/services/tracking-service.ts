import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ETAPrediction, ScanEvent } from '../models/tracking-models';

@Injectable({
  providedIn: 'root'
})
export class TrackingService {
  private readonly scanApiUrl = 'http://localhost:5000/api';
  private readonly etaApiUrl = 'http://localhost:5001/api';

  constructor(private http: HttpClient) {}

  getScanEvents(packageId: string): Observable<ScanEvent[]> {
    return this.http.get<ScanEvent[]>(`${this.scanApiUrl}/scans/${packageId}`);
  }

  getETAPrediction(packageId: string): Observable<ETAPrediction> {
    return this.http.get<ETAPrediction>(`${this.etaApiUrl}/eta-predictions/${packageId}`);
  }
}