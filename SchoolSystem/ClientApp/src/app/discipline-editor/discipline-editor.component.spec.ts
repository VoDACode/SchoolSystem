import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisciplineEditorComponent } from './discipline-editor.component';

describe('DisciplineEditorComponent', () => {
  let component: DisciplineEditorComponent;
  let fixture: ComponentFixture<DisciplineEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisciplineEditorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisciplineEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
