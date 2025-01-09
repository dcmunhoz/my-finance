import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { RegisterUserRequest } from './requests/register-user-request.interface';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class IdentityService {
  private _api = environment.apiEndpoint + '/api/auth';

  constructor(private readonly _http: HttpClient) {}

  public registerUser(request: RegisterUserRequest): Observable<string> {
    return this._http.post<string>(`${this._api}/register`, request);
  }
}
