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
    path: '',
    loadComponent: () =>
      import('./shared/components/mf-host/mf-host.component').then((c) => c.MFHostComponent),
    children: [
      {
        path: 'categories',
        loadComponent: () =>
          import('./applications/app-categories/categories/categories.component').then(
            (c) => c.CategoriesComponent,
          ),
      },
    ],
  },
  {
    path: '**',
    redirectTo: 'login',
  },
];
