import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () =>
      import('./applications/app-authentication/pages/login/login.component').then(
        (c) => c.LoginComponent,
      ),
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./applications/app-authentication/pages/register/register.component').then(
        (c) => c.RegisterComponent,
      ),
  },
  {
    path: '**',
    redirectTo: 'login',
  },
];
