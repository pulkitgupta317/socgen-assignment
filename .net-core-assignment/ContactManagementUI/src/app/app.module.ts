import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrimeNgDependencyModule } from './prime-ng/prime-ng-dependency/prime-ng-dependency.module';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { CreateContactComponent } from './components/create-contact/create-contact.component';
import { UpdateViewContactComponent } from './components/update-view-contact/update-view-contact.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ContactListComponent,
    CreateContactComponent,
    UpdateViewContactComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    PrimeNgDependencyModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
