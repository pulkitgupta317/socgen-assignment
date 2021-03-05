import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { CreateContactComponent } from './components/create-contact/create-contact.component';
import { UpdateViewContactComponent } from './components/update-view-contact/update-view-contact.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'contacts',
    pathMatch: 'full'
  },
  {
    path: 'contacts',
    component: ContactListComponent
  },
  {
    path: 'contact/:id',
    component: UpdateViewContactComponent
  },
  {
    path: 'create-contact',
    component: CreateContactComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
