import { Component, inject } from '@angular/core';
import { MFNotificationService } from './service/mf-notification.service';
import { MFNotificationComponent } from './components/mf-notification.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'mf-notification-wrapper',
  templateUrl: './mf-notification-wrapper.component.html',
  styleUrls: ['./mf-notification-wrapper.component.scss'],
  imports: [MFNotificationComponent, CommonModule],
})
export class MFNotificationWrapperComponent {
  private readonly _service = inject(MFNotificationService);

  protected notifications$ = this._service.notifications;

  protected removed(id: number): void {
    this._service.removeNotification(id);
  }
}
