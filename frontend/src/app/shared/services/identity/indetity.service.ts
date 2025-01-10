import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { map, Observable } from 'rxjs';
import { RegisterUserRequest } from './requests/register-user-request.interface';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from './requests/login-request.interface';
import { LoginResponse } from './responses/login-response.interface';

@Injectable({ providedIn: 'root' })
export class IdentityService {
  private _api = environment.apiEndpoint + '/api/auth';

  constructor(private readonly _http: HttpClient) {}

  public registerUser(request: RegisterUserRequest): Observable<string> {
    return this._http.post<string>(`${this._api}/register`, request);
  }

  public login(request: LoginRequest): Observable<LoginResponse> {
    return this._http.post<LoginResponse>(`${this._api}/login`, request).pipe(
      map((response) => {
        localStorage.setItem('authToken', JSON.stringify(response));
        return response;
      }),
    );
  }

  public getToken(): LoginResponse | null {
    const token = localStorage.getItem('authToken');

    if (token == null) return null;

    return JSON.parse(token);
  }
}
