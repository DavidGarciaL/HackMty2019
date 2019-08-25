import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalFacturasPage } from './modal-facturas.page';

describe('ModalFacturasPage', () => {
  let component: ModalFacturasPage;
  let fixture: ComponentFixture<ModalFacturasPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalFacturasPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalFacturasPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
