import { Component } from '@angular/core';
import { Messages } from './models/message';
import { MessageService } from './services/message.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'mesUI';
  messages: Messages[] = [];
  mesToEdit?: Messages;
  show:boolean = false;

  constructor(private messageService: MessageService) {}

  ngOnInit() : void {
   // this.messageService.getMessages().subscribe((result: Messages[]) => (this.messages = result));
  }
  updateMesList(){

    this.messageService.getMessages().subscribe((result: Messages[]) => (this.messages = result));
    this.show = true;
  }
  initNewMes() {
    this.mesToEdit = new Messages();
  }
  editMes(messages: Messages) {
    this.mesToEdit = messages;
  }
}

