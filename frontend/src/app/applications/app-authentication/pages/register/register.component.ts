import { Component, inject } from "@angular/core";
import { MFContainerComponent } from "../../../../shared/components/mf-container/mf-container.component";
import { IdentityService } from "../../services/indetity.service";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { RegisterUserRequest } from "../../services/requests/register-user-request.interface";
import { RouterLink } from "@angular/router";

@Component({
    selector: "app-register",
    templateUrl: "./register.component.html",
    styleUrls: ["./register.component.scss"],
    imports: [MFContainerComponent, ReactiveFormsModule, RouterLink],
    providers: [IdentityService]
})
export class RegisterComponent {
    private readonly _identityService = inject(IdentityService);
    private readonly _fb = inject(FormBuilder);

    protected form = this._fb.group({
        email: [''],
        name: [''],
        password: [''],
        confirmationPassword: ['']
    });

    protected onClick() : void {
        let request = this.form.value as RegisterUserRequest;
        this._identityService.registerUser(request).subscribe({
            next: response => {
                console.log(response);
            }
        })
    }
}