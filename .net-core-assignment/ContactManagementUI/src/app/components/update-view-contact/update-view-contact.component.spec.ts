import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateViewContactComponent } from './update-view-contact.component';

describe('UpdateViewContactComponent', () => {
  let component: UpdateViewContactComponent;
  let fixture: ComponentFixture<UpdateViewContactComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateViewContactComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateViewContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
