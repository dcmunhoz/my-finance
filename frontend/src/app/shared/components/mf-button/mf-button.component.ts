import { CommonModule } from '@angular/common';
import { Component, input, output } from '@angular/core';

export enum MFButtonKindEnum {
  Default = 'default',
  Danger = 'danger',
  Success = 'success',
}

export enum MFButtonTypeEnum {
  Primary = 'primary',
  Secondary = 'secondary',
  Tertiary = 'tertiary',
}

@Component({
  selector: 'mf-button',
  templateUrl: './mf-button.component.html',
  styleUrls: ['./mf-button.component.scss'],
  imports: [CommonModule],
})
export class MFButtonComponent {
  public clickEvent = output({ alias: 'p-onclick' });
  public kind = input(MFButtonKindEnum.Default, { alias: 'p-kind' });
  public type = input(MFButtonTypeEnum.Primary, { alias: 'p-type' });

  protected onClick(): void {
    this.clickEvent.emit();
  }
}
