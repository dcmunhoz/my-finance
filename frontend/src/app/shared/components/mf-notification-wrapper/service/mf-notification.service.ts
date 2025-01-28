import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

export enum MFNotificationType {
  Success,
  Warning,
  Error,
}

export interface MFNotificationDetail {
  id: number;
  title: string;
  message: string;
  type: MFNotificationType;
}

@Injectable({ providedIn: 'root' })
export class MFNotificationService {
  private _notifications = new BehaviorSubject<MFNotificationDetail[]>([]);

  public get notifications(): Observable<MFNotificationDetail[]> {
    return this._notifications;
  }

  public success(title: string, message: string): void {
    this._addNotification({
      id: this._generateId(),
      title,
      message,
      type: MFNotificationType.Success,
    });
  }

  public warning(title: string, message: string): void {
    this._addNotification({
      id: this._generateId(),
      title,
      message,
      type: MFNotificationType.Warning,
    });
  }

  public error(title: string, message: string): void {
    this._addNotification({
      id: this._generateId(),
      title,
      message,
      type: MFNotificationType.Error,
    });
  }

  public removeNotification(id: number): void {
    this._notifications.next(this._notifications.value.filter((n) => n.id !== id));
  }

  private _generateId(): number {
    return this._notifications.value.length + 1;
  }

  private _addNotification(notification: MFNotificationDetail): void {
    this._notifications.next([...this._notifications.value, notification]);
  }
}
