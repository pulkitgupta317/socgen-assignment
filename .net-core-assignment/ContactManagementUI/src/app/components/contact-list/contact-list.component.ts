import { Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/models/contact.interface';
import { MessageToastService } from 'src/app/prime-ng/services/message-toast.service';
import { ContactService } from 'src/app/services/contact.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {

  data: Contact[];
  loading = true;
  first = 0;
  rows = 10;
  cols: {
    field: string,
    header: string
  }[];

  constructor(private contactService: ContactService,
    private messageToastService: MessageToastService) {
    this.cols = [
      { field: 'vin', header: 'SNo.' },
      { field: 'vin', header: 'FirstName' },
      { field: 'year', header: 'LastName' },
      { field: 'color', header: 'Actions' }
    ];
  }

  ngOnInit(): void {
    this.fillData();
  }

  fillData() {
    this.contactService.GetAll().subscribe(x => {
      this.data = x;
      this.loading = false;
    }, error => {
      this.messageToastService.errorMessageToast('An error occurred');
      this.loading = false;
    });
  }


  onDelete(id: number) {
    this.contactService.DeleteContact(id).subscribe(x => {
      this.messageToastService.successMessageToast('Contact has been successfully deleted');
      this.fillData();
    }, error => {
      this.messageToastService.errorMessageToast('An error occurred');
    })
  }

  prev(): void {
    this.first = this.first - this.rows;
  }

  reset(): void {
    this.first = 0;
  }

  isLastPage(): boolean {
    return this.first === (this.data.length - this.rows);
  }

  isFirstPage(): boolean {
    return this.first === 0;
  }
}
