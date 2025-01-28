import { Component, inject } from '@angular/core';
import { MFContainerComponent } from '../../../../shared/components/mf-container/mf-container.component';
import { Router, RouterLink } from '@angular/router';
import {
  MFButtonComponent,
  MFButtonKindEnum,
  MFButtonTypeEnum,
} from '../../../../shared/components/mf-button/mf-button.component';
import {
  MFInputComponent,
  MFInputTypeEnum,
} from '../../../../shared/components/mf-input/mf-input.component';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MFNotificationService } from '../../../../shared/components/mf-notification-wrapper/service/mf-notification.service';
import { LoginRequest } from '../../../../shared/services/identity/requests/login-request.interface';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorResponse } from '../../../../shared/common/responses/error-response.interface';
import { IdentityService } from '../../../../shared/services/identity/indetity.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  imports: [
    ReactiveFormsModule,
    MFContainerComponent,
    MFButtonComponent,
    MFInputComponent,
    RouterLink,
  ],
})
export class LoginComponent {
  private readonly _identityService = inject(IdentityService);
  private readonly _formBuilder = inject(FormBuilder);
  private readonly _notificationService = inject(MFNotificationService);
  private readonly _router = inject(Router);

  protected readonly formLogin = this._formBuilder.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  });

  protected readonly buttonKindEnum = MFButtonKindEnum;
  protected readonly buttonTypeEnum = MFButtonTypeEnum;
  protected readonly inputTypeEnum = MFInputTypeEnum;
  protected isLoading = false;

  protected onClick(): void {
    this.formLogin.setErrors(null);

    if (this.formLogin.invalid) {
      this.formLogin.setErrors({ invalid: true });
      return;
    }

    const request = this.formLogin.value as LoginRequest;
    this.isLoading = true;
    this._identityService
      .login(request)
      .subscribe({
        next: () => {
          this._notificationService.success('Sucesso!', 'Login realizado com sucesso');
          this._router.navigate(['/']);
        },
        error: (error: HttpErrorResponse) => {
          const response = error.error as ErrorResponse;
          this._notificationService.error(response.title, response.message);
        },
      })
      .add(() => (this.isLoading = false));
  }
}
