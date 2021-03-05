import { NgModule } from '@angular/core';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { PanelModule } from 'primeng/panel';
import { DropdownModule } from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { RatingModule } from 'primeng/rating';
import { RippleModule } from 'primeng/ripple';
import { CarouselModule } from 'primeng/carousel';
import { TableModule } from 'primeng/table';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

@NgModule({
  declarations: [],
  imports: [
    ToastModule,
    ButtonModule,
    PanelModule,
    DialogModule,
    DropdownModule,
    InputTextModule,
    RippleModule,
    RatingModule,
    CarouselModule,
    TableModule,
    ProgressSpinnerModule
  ],
  exports: [
    ToastModule,
    ButtonModule,
    PanelModule,
    DialogModule,
    DropdownModule,
    InputTextModule,
    RippleModule,
    RatingModule,
    CarouselModule,
    TableModule,
    ProgressSpinnerModule
  ],
  providers: [
    MessageService
  ]
})
export class PrimeNgDependencyModule { }
