import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMesFormComponent } from './add-mes-form.component';

describe('AddMesFormComponent', () => {
  let component: AddMesFormComponent;
  let fixture: ComponentFixture<AddMesFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddMesFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddMesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
