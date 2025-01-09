import { Component, inject } from '@angular/core';
import { MFContainerComponent } from '../../../../shared/components/mf-container/mf-container.component';
import { IdentityService } from '../../services/indetity.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterUserRequest } from '../../services/requests/register-user-request.interface';
import { RouterLink } from '@angular/router';
import { MFButtonComponent } from '../../../../shared/components/mf-button/mf-button.component';
import { MFInputComponent } from '../../../../shared/components/mf-input/mf-input.component';

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
  providers: [IdentityService],
})
export class RegisterComponent {
  private readonly _identityService = inject(IdentityService);
  private readonly _fb = inject(FormBuilder);

  protected form = this._fb.group({
    email: ['', Validators.required],
    name: ['', [Validators.required, Validators.minLength(10)]],
    password: ['', Validators.required],
    confirmationPassword: ['', Validators.required],
  });

  protected registerUser(): void {
    console.log(this.form.value);
    return;

    const request = this.form.value as RegisterUserRequest;
    this._identityService.registerUser(request).subscribe({
      next: (response) => {
        console.log(response);
      },
    });
  }
}
