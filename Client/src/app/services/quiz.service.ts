import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QueryParams, QuizResponse } from '../Model/quiz-question.model';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  private apiUrl = 'https://localhost:7084/api/Quiz'; 

  constructor(private http: HttpClient) {}

  getQuestions(queryParams?: QueryParams): Observable<QuizResponse> {
    let params = new HttpParams();
  
    // Directly append the dataSource query parameter if it exists
    if (queryParams && queryParams.dataSource) {
      params = params.append('dataSource', queryParams.dataSource);
    }
  
    return this.http.get<QuizResponse>(`${this.apiUrl}/GetQuestions`, { params });
  }
  

  submitAnswers(answers: any[]): Observable<any> {
    return this.http.post(`${this.apiUrl}/submit`, answers);
  }
}
