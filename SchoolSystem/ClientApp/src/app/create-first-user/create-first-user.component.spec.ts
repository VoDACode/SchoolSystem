import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFirstUserComponent } from './create-first-user.component';

describe('CreateFirstUserComponent', () => {
  let component: CreateFirstUserComponent;
  let fixture: ComponentFixture<CreateFirstUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateFirstUserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateFirstUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
