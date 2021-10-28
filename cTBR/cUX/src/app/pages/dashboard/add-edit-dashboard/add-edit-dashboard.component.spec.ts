import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditDashboardComponent } from './add-edit-dashboard.component';

describe('AddEditDashboardComponent', () => {
  let component: AddEditDashboardComponent;
  let fixture: ComponentFixture<AddEditDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
