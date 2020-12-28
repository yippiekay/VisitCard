import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { IVisitCard } from '../shared/models/visitCard';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VisitCardService {
  baseUrl = environment.apiUrl;
  httpOptions = {
    withCredentials: true
  };

  constructor(private client: HttpClient) { }

  getCard(): Observable<IVisitCard> {
    return this.client.get<IVisitCard>(this.baseUrl + '/card', this.httpOptions);
  }

  updateCard(card: IVisitCard): Observable<IVisitCard> {
    return this.client.put<IVisitCard>(this.baseUrl + '/card', card, this.httpOptions);
  }
}
