import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MessageService } from 'src/app/services/message.service';
import { MessageSubjects } from 'src/app/models/messageSubject';
import { MessageForm } from 'src/app/models/messageForm';
import { Messages } from 'src/app/models/message';
import IMask from 'imask';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-add-mes-form',
  templateUrl: './add-mes-form.component.html',
  styleUrls: ['./add-mes-form.component.css']
})
export class AddMesFormComponent implements OnInit {

//
  public fg: FormGroup;

  @Output() messagesUpdated = new EventEmitter<Messages[]>();

  submitted:boolean = false;
  messageList$:Observable<any[]> = this.service.getMessagesList();
  messageSubjectList$:Observable <MessageSubjects[]> = this.service.getMessageSubjectList();

  constructor(private service:MessageService, private fb: FormBuilder){ /////////////
    this.fg = fb.group({
      phone: ['', [Validators.required, Validators.pattern("^[0-9]{10}$")]],
      contactName: ['', [Validators.required]],
      title: ['', [Validators.required]],
      message_text: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.pattern("^[\\w]{1,}[\\w.+-]{0,}@[\\w-]{2,}([.][a-zA-Z]{2,}|[.][\\w-]{2,}[.][a-zA-Z]{2,})$")]]
    })
  }

  phoneMask = { mask: "8 (000) 000-00-00" }; //


  get p(){
    return this.fg.controls;
  }
   
  onFormSubmit(){
    alert("8" + this.fg.value.phone);
  } 

  onMesCreate(message: {contactName: string, email: string, phone: string, title: string, message_text: string}){

    message.phone = "8" + message.phone;
    this.service.addMes(message);
    this.service.addMes(message)
        .subscribe((mess: Messages[]) => this.messagesUpdated.emit(mess));
    this.submitted = true;
    this.messageList$ = this.service.getMessagesList();
  }

  ngOnInit(): void {
  }
}
