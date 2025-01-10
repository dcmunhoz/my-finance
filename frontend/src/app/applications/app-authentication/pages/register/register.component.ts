import { Component, inject } from '@angular/core';
import { MFContainerComponent } from '../../../../shared/components/mf-container/mf-container.component';
import { IdentityService } from '../../services/indetity.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterUserRequest } from '../../services/requests/register-user-request.interface';
import { RouterLink } from '@angular/router';
import { MFButtonComponent } from '../../../../shared/components/mf-button/mf-button.component';
import { MFInputComponent } from '../../../../shared/components/mf-input/mf-input.component';
import { MFNotificationService } from '../../../../shared/components/mf-notification-wrapper/service/mf-notification.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  imports: [
    MFContainerComponent,
    MFButtonComponent,
    MFInputComponent,
    ReactiveFormsModule,
    RouterLink,
  ],
})
export class RegisterComponent {
  private readonly _identityService = inject(IdentityService);
  private readonly _fb = inject(FormBuilder);
  private readonly _notificationService = inject(MFNotificationService);

  protected formRegister = this._fb.group({
    email: ['', Validators.required],
    name: ['', Validators.required],
    password: ['', Validators.required],
    confirmationPassword: ['', [Validators.required]],
  });

  protected registerUser(): void {
    const random = Math.floor(Math.random() * 3) + 1;

    switch (random) {
      case 1:
        this._notificationService.success(
          'Success Notification',
          'This is a random success message',
        );
        break;
      case 2:
        this._notificationService.warning(
          'Warning Notification',
          'This is a random warning message',
        );
        break;
      case 3:
        this._notificationService.error('Error Notification', 'This is a random error message');
        break;
    }

    return;

    this.formRegister.setErrors(null);

    if (this.formRegister.invalid) {
      this.formRegister.setErrors({ hasError: true });
      return;
    }

    const request = this.formRegister.value as RegisterUserRequest;
    this._identityService.registerUser(request).subscribe({
      next: (response) => {
        console.log(response);
      },
    });
  }
}
