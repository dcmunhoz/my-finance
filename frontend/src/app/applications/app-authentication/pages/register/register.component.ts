import { Component, inject } from '@angular/core';
import { MFContainerComponent } from '../../../../shared/components/mf-container/mf-container.component';
import { IdentityService } from '../../services/indetity.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterUserRequest } from '../../services/requests/register-user-request.interface';
import { Router, RouterLink } from '@angular/router';
import { MFButtonComponent } from '../../../../shared/components/mf-button/mf-button.component';
import { MFInputComponent } from '../../../../shared/components/mf-input/mf-input.component';
import { MFNotificationService } from '../../../../shared/components/mf-notification-wrapper/service/mf-notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IErrorResponse } from '../../../../shared/common/responses/error-response.interface';

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
  private readonly _router = inject(Router);

  protected formRegister = this._fb.group({
    email: ['', Validators.required],
    name: ['', Validators.required],
    password: ['', Validators.required],
    confirmationPassword: ['', [Validators.required]],
  });

  protected isLoading = false;

  protected registerUser(): void {
    this.formRegister.setErrors(null);

    if (this.formRegister.invalid) {
      this.formRegister.setErrors({ hasError: true });
      return;
    }

    this.isLoading = true;
    const request = this.formRegister.value as RegisterUserRequest;
    this._identityService
      .registerUser(request)
      .subscribe({
        next: () => {
          this._router.navigate(['/login']);
          this._notificationService.success('Sucesso!', 'Usuário registrado com sucesso');
        },
        error: (e: HttpErrorResponse) => {
          const response = e.error as IErrorResponse;

          if (response.details != null && response.details.length > 0) {
            response.details.forEach((detail) => {
              this._notificationService.error('Atenção!', detail.message);
            });
          } else {
            this._notificationService.error(response.title, response.message);
          }
        },
      })
      .add(() => (this.isLoading = false));
  }
}
