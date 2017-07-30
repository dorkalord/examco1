import { Component, OnInit } from '@angular/core';

import { User, Topic, Course } from '../../_models/index';
import { UserService, CourseService } from '../../_services/index';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { Question } from '../../_models/question';
import { StateService } from '../../_services/state.service';
import { StateOfForm } from '../../_models/criterea';
import { State } from '../../_models/state';
import { Grade } from '../../_models/exam';
import { GradeService } from '../../_services/grade.service';

@Component({
    moduleId: module.id,
    selector: "exam-create",
    templateUrl: 'exam-create.component.html'

})

export class ExamCreateComponent implements OnInit {
    currentUser: User;
    public courses: Course[];
    public examForm: FormGroup;
    public critereaForm: FormGroup;
    public critereaCounter: number;
    public state: StateOfForm;
    public gradeList: Grade[];

    constructor(private userService: UserService,
        private courseService: CourseService,
        private stateService: StateService,
        private gradeService: GradeService,
        private _fb: FormBuilder, ) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.examForm = this._fb.group({
            stateID: [1, Validators.required],
            status: ["", Validators.required],
            date: ["", Validators.required],
            courseID: [null, Validators.required],
            authorID: this.currentUser.id,
            language: ['', Validators.required],
            examCritereas: this._fb.array([]),
            qestions: this._fb.array([]),
            censorIDs: this._fb.array([])
        });
        this.state = StateOfForm.List;
    }

    ngOnInit() {
        this.courseService.getAllCoursesOfUser(this.currentUser.id).subscribe(data => {
            this.stateService.getById(1).subscribe(res => {
                this.courses = data;
                this.critereaCounter = 0;
                this.examForm = this._fb.group({
                    stateID: [1, Validators.required],
                    status: [res.name, Validators.required],
                    date: ["2017-01-01T10:30", Validators.required],
                    courseID: [null, Validators.required],
                    authorID: this.currentUser.id,
                    language: ['', Validators.required],
                    examCritereas: this._fb.array([]),
                    qestions: this._fb.array([]),
                    censorIDs: this._fb.array([])
                });
            });
        });

    }



    initExamCriterea() {
        let a = this._fb.group({
            id: [this.critereaCounter],
            name: ['', Validators.required],
            advices: this._fb.array([])
        });
        this.state = StateOfForm.Loading;
        this.gradeService.getDefault().subscribe(data => {
            let ad = <FormArray>a.controls['advices']
            const control = <FormArray>this.examForm.controls['examCritereas'];
            this.gradeList = data;

            this.gradeList.forEach(element => {
                ad.push(this._fb.group({
                    grade: [element.name],
                    top: [element.top],
                    text: ["", Validators.required]
                }));
            });
            control.push(a);
            this.critereaForm = a;
            this.state = StateOfForm.Edit;
        });
    }

    initAdvice(g: Grade) {
        return this._fb.group({
            grade: [g.name],
            top: [g.top],
            text: ["", Validators.required]
        });
    }

    addExamCriterea() {
        this.critereaCounter = this.critereaCounter + 1;
        this.initExamCriterea();
    }


    removeCriterea(i: number) {
        const control = <FormArray>this.examForm.controls['examCritereas'];
        control.removeAt(i);
    }

    save(model: any) {
        // call API to update
        console.log(model);
    }


}