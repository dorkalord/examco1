import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { AppConfig } from './app.config';

import { AlertComponent } from './_directives/index';
import { AuthGuard } from './_guards/index';
import { AlertService, AuthenticationService, UserService } from './_services/index';
import { HomeComponent } from './home/index';
import { LoginComponent } from './login/index';
import { RegisterComponent } from './register/index';
import { CourseComponent, CourseCreateComponent, CourseEditComponent } from './course/index';
import { HeaderComponent } from "./header/header.component";
import { ExamComponent } from './exam/exam.component';
import { ExamCreateComponent } from './exam/create/exam-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TopicComponent } from './course/create/topic.component';
import { CourseService } from './_services/course.service';
import { GeneralCritereaComponent } from './exam/create/generealCriterea.component';
import { AdviceCritereaComponent } from './exam/create/adviceCriterea.component';
import { ExamService } from './_services/exam.service';
import { QuestionService } from './_services/question.service';
import { ExamQuestionsComponent } from './exam/create/questions/exam-questions.component';
import { QestionArgumentComponent } from './exam/create/questions/question-argument.component';
import { ExamEvaluatorComponent } from './exam/create/evaluators/exam-evaluator.component';
import { TopicService } from './_services/topic.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        routing
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
        LoginComponent,
        RegisterComponent,
        CourseComponent,
        CourseCreateComponent,
        CourseEditComponent,
        ExamComponent,
        ExamCreateComponent,
        GeneralCritereaComponent,
        AdviceCritereaComponent,
        ExamQuestionsComponent,
        QestionArgumentComponent,
        ExamEvaluatorComponent,
        TopicComponent,
        HeaderComponent
    ],
    providers: [
        AppConfig,
        AuthGuard,
        AlertService,
        AuthenticationService,
        UserService,
        CourseService,
        TopicService,
        ExamService,
        QuestionService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }