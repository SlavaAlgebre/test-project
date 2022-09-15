import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Messages } from '../models/message';
import { MessageForm } from '../models/messageForm';
import { MessageSubjects } from '../models/messageSubject';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  readonly messageAPIUrl = "https://localhost:7143/api";

  private url = "Messages";
  constructor(private http: HttpClient) { }
  
  public addMessages(mes: Messages) : Observable<Messages[]>{
    return this.http.post<Messages[]>(this.messageAPIUrl + '/Messages', mes);
  }


  getMessageSubjectList():Observable<MessageSubjects[]> {
    return this.http.get<MessageSubjects[]>(this.messageAPIUrl + '/MessageSubjects');
  }
  getMessagesList():Observable<Messages[]> {
    return this.http.get<Messages[]>(this.messageAPIUrl + '/Messages');
  }

  getMessages() : Observable<Messages[]> {
    return this.http.post<any>(this.messageAPIUrl + '/Get', {id: 0});
  }

  addMes(data:MessageForm) : Observable<MessageForm[]>{ //добавить данные в бд из формы
    //return this.http.post<any>(this.messageAPIUrl + '/Add', data);
    return this.http.post<MessageForm[]>(this.messageAPIUrl + '/Add', data);

  }
}
