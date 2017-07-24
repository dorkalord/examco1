import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/index';
import { LoginComponent } from './login/index';
import { RegisterComponent } from './register/index';
import { AuthGuard } from './_guards/index';
import { CourseComponent, CourseCreateComponent, CourseEditComponent } from "./course/index";
import { ExamComponent } from './exam/exam.component';
import { ExamCreateComponent } from './exam/create/exam-create.component';
import { ExamQuestionsComponent } from './exam/create/questions/exam-questions.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'course', component: CourseComponent, canActivate: [AuthGuard]  },
    { path: 'course/create', component: CourseCreateComponent, canActivate: [AuthGuard]  },
    { path: 'course/edit/:id', component: CourseEditComponent, canActivate: [AuthGuard]  },
    { path: 'exam', component: ExamComponent, canActivate: [AuthGuard]  },
    { path: 'exam/create', component: ExamCreateComponent, canActivate: [AuthGuard]  },
    { path: 'exam/create/:id/question', component: ExamQuestionsComponent, canActivate: [AuthGuard]  },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);