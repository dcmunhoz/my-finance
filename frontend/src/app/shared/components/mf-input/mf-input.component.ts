/* eslint-disable */
import { CommonModule } from '@angular/common';
import { Component, forwardRef, input, output } from '@angular/core';
import {
  ControlValueAccessor,
  FormControl,
  FormsModule,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms';

let uniqueId = 0;

export enum MFInputTypeEnum {
  Text = 'text',
  Password = 'password',
}

@Component({
  selector: 'mf-input',
  templateUrl: './mf-input.component.html',
  styleUrls: ['./mf-input.component.scss'],
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MFInputComponent),
      multi: true,
    },
  ],
})
export class MFInputComponent implements ControlValueAccessor {
  public label = input<string>('', { alias: 'p-lable' });
  public type = input<MFInputTypeEnum>(MFInputTypeEnum.Text, { alias: 'p-type' });
  public placeholder = input<string>('', { alias: 'p-placeholder' });
  public hasError = input<boolean>(false, { alias: 'p-error' });
  public errorDetail = input<string>('', { alias: 'p-error-detail' });
  public valueChanged = output();

  public formControl: FormControl;
  protected inputId = `mf-input-${++uniqueId}`;

  public onChange: Function = () => {};
  public onTouched: Function = () => {};

  private _teste = '';

  public get value(): any {
    return this.formControl.value;
  }

  public set value(value: any) {
    if (value !== this.formControl.value) {
      this.formControl.setValue(value);
      this.onChange(value);
      this.valueChanged.emit();
    }
  }

  constructor() {
    this.formControl = new FormControl('');
  }

  public writeValue(value: any): void {
    this.value = value;
  }

  public registerOnChange(fn: any): void {
    this.formControl.valueChanges.subscribe(fn);
  }

  public registerOnTouched(fn: Function): void {
    this.onTouched = fn;
  }

  public setDisabledState?(isDisabled: boolean): void {
    if (isDisabled) this.formControl.disable();
    else this.formControl.enable();
  }
}
