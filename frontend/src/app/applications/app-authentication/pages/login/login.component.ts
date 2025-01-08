import { Component } from "@angular/core";
import { MFContainerComponent } from "../../../../shared/components/mf-container/mf-container.component";
import { RouterLink } from "@angular/router";
import { MFButtonComponent, MFButtonKindEnum, MFButtonTypeEnum } from "../../../../shared/components/mf-button/mf-button.component";

@Component({
    selector: "app-login",
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.scss"],
    imports: [MFContainerComponent, MFButtonComponent, RouterLink, MFButtonComponent]
})
export class LoginComponent {
    protected readonly buttonKindEnum = MFButtonKindEnum;
    protected readonly buttonTypeEnum = MFButtonTypeEnum;

    protected onClick(): void {
        console.log("clicou");
    }
}