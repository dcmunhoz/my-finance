import { Component, ElementRef, input, OnInit, output } from '@angular/core';
import { MFNotificationDetail, MFNotificationType } from '../service/mf-notification.service';

@Component({
  selector: 'mf-notification',
  templateUrl: './mf-notification.component.html',
  styleUrls: ['./mf-notification.component.scss'],
})
export class MFNotificationComponent implements OnInit {
  public notification = input<MFNotificationDetail>(undefined, { alias: 'p-notification' });
  public clicked = output<number>({ alias: 'p-click' });

  //eslint-disable-next-line @typescript-eslint/no-explicit-any
  private _timer: any;

  protected notificationType = MFNotificationType;
  protected removing = false;
  protected timeLeftPercent = 100;

  constructor(private _host: ElementRef<HTMLElement>) {}

  public ngOnInit(): void {
    const duration = 5000;
    const interval = 10;

    this._timer = setInterval(() => {
      this.timeLeftPercent -= (interval / duration) * 100;

      if (this.timeLeftPercent <= 0) {
        clearInterval(this._timer);
        this.removeNotification();
      }
    }, interval);
  }

  public removeNotification(): void {
    if (this.removing) return;

    this.removing = true;
    const timeout = setTimeout(() => {
      this.clicked.emit(this.notification()?.id ?? 0);
      this.removing = false;
      clearTimeout(timeout);
      clearInterval(this._timer);
    }, 300);
  }
}
