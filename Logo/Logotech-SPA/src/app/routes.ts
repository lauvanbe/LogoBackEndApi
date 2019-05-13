import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListePatientsComponent } from './patients/liste-patients/liste-patients.component';
import { AgendaComponent } from './agenda/agenda.component';
import { AuthGuard } from './_guards/auth.guard';
import { ListePraticiensComponent } from './praticiens/liste-praticiens/liste-praticiens.component';
import { PraticienDetailComponent } from './praticiens/praticien-detail/praticien-detail.component';
import { PraticienDetailResolver } from './_resolvers/praticien-detail.resolver';
import { PraticienListeResolver } from './_resolvers/liste-praticien.resolver';
import { PatientListeResolver } from './_resolvers/liste-patient.resolver';
import { PatientDetailComponent } from './patients/patient-detail/patient-detail.component';
import { PatientDetailResolver } from './_resolvers/patient-detail.resolver';
import { PatientEditComponent } from './patients/patient-edit/patient-edit.component';
import { PatientEditResolver } from './_resolvers/patient-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver.1';
import { UserEditResolver } from './_resolvers/user-edit.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'user/edit', component: UserEditComponent, resolve: {user: UserEditResolver}},
            { path: 'liste-praticiens', component: ListePraticiensComponent,
                resolve: { praticiens: PraticienListeResolver }},
            { path: 'liste-praticiens/:id', component: PraticienDetailComponent,
                resolve: { praticien: PraticienDetailResolver }},
            { path: 'liste-patients', component: ListePatientsComponent,
                resolve: { patients: PatientListeResolver }},
            { path: 'liste-patients/:id', component: PatientDetailComponent,
                resolve: { patient: PatientDetailResolver }},
            { path: 'liste-patients/edit/:id', component: PatientEditComponent,
                resolve: { patient: PatientEditResolver }, canDeactivate: [PreventUnsavedChanges]},
            { path: 'agenda', component: AgendaComponent},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
