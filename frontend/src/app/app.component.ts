import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MFNotificationWrapperComponent } from './shared/components/mf-notification-wrapper/mf-notification-wrapper.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MFNotificationWrapperComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {}
