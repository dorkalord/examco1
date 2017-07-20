﻿import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/index';
import { LoginComponent } from './login/index';
import { RegisterComponent } from './register/index';
import { AuthGuard } from './_guards/index';
import { CourseComponent, CourseCreateComponent } from "./course/index";
import { ExamComponent } from './exam/exam.component';
import { ExamCreateComponent } from './exam/create/exam-create.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'course', component: CourseComponent, canActivate: [AuthGuard]  },
    { path: 'course/create', component: CourseCreateComponent, canActivate: [AuthGuard]  },
    { path: 'exam', component: ExamComponent, canActivate: [AuthGuard]  },
    { path: 'exam/create', component: ExamCreateComponent, canActivate: [AuthGuard]  },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);