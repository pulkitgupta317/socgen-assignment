import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageToastService } from 'src/app/prime-ng/services/message-toast.service';
import { ContactService } from 'src/app/services/contact.service';

@Component({
  selector: 'app-update-view-contact',
  templateUrl: './update-view-contact.component.html',
  styleUrls: ['./update-view-contact.component.css']
})
export class UpdateViewContactComponent implements OnInit {
  pageType: string;
  id: number;
  contact: FormGroup;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private contactService: ContactService,
    private messageService: MessageToastService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.contact = this.fb.group({
      id: [0],
      firstName: ["", Validators.required],
      lastName: ["", Validators.required],
      phoneNumbers: this.fb.array([], Validators.required)
    });

    this.activatedRoute.params.subscribe(x => {
      this.id = x['id'];
      this.getContactData(this.id);
    });
  }

  getContactData(id: number) {
    this.contactService.GetItem(id).subscribe(x => {
      if (!x) {
        this.messageService.errorMessageToast('Invalid contact Id');
        this.router.navigate(['/contacts']);
      } else {
        this.contact.patchValue(x);
        x.phoneNumbers.forEach(number => {
          const temp = this.newPhoneNumber;
          temp.patchValue(number);
          this.phoneNumberFormArray.push(temp);
        });
      }
    }, error => {
      console.log(error);
    })
  }

  get newPhoneNumber(): FormGroup {
    return this.fb.group({
      id: [0],
      type: ["Personal", Validators.required],
      number: ["", [Validators.required, Validators.pattern("[0-9 ]{10}")]]
    });
  }

  onSubmit() {
    this.submitted = true;
    if (this.contact.invalid) {
      return;
    }
    this.contactService.UpdateContact(this.contact.value).subscribe(x => {
      this.messageService.successMessageToast('Contact has been successfully updated');
      this.router.navigate(['contacts']);
    }, error => {
      this.messageService.errorMessageToast('An error occurred')
    });
  }

  get item(): { [key: string]: AbstractControl; } {
    return (this.contact as FormGroup).controls;
  }

  get phoneNumberFormArray(): FormArray {
    return this.contact.get('phoneNumbers') as FormArray;
  }

  addPhoneNumber() {
    let fg = this.newPhoneNumber;
    this.phoneNumberFormArray.push(fg);
  }

  deletePhoneNumber(idx: number) {
    this.phoneNumberFormArray.removeAt(idx);
  }
}
