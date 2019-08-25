import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalVentasPage } from './modal-ventas.page';

describe('ModalVentasPage', () => {
  let component: ModalVentasPage;
  let fixture: ComponentFixture<ModalVentasPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalVentasPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalVentasPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
