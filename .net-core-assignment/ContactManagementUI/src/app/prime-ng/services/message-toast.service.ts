import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class MessageToastService {

  constructor(private messageService: MessageService) { }

  errorMessageToast(message: string): void {
    this.messageService.add(
      {
        severity: 'error',
        summary: 'Error',
        detail: message
      });
  }

  successMessageToast(message: string): void {
    this.messageService.add(
      {
        severity: 'success',
        summary: 'Success',
        detail: message
      });
  }
}
