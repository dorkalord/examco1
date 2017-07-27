import { Component, OnInit } from '@angular/core';

import { User, Topic, Course } from '../../_models/index';
import { UserService, CourseService } from '../../_services/index';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';
import { Question } from '../../_models/question';

@Component({
    moduleId: module.id,
    selector: "exam-create",
    templateUrl: 'exam-create.component.html'

})

export class ExamCreateComponent implements OnInit {
    currentUser: User;
    public courses: Course[];
    public examForm: FormGroup;
    public critereaCounter: number;

    constructor(private userService: UserService,
        private courseService: CourseService,
        private _fb: FormBuilder, ) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));

    }

    ngOnInit() {
        this.courseService.getAllCoursesOfUser(this.currentUser.id).subscribe(data => {
            this.courses = data;
            this.critereaCounter = 0;
            this.examForm = this._fb.group({
                date: ['', Validators.required],
                courseID: [null, Validators.required],
                authorID: this.currentUser.id,
                language: ['', Validators.required],
                generalCritereas: this._fb.array([]),
                qestions: this._fb.array([]),
                censorIDs: this._fb.array([])
            });
            this.addGeneralCriterea();
        });
        
    }

    initGeneralCriterea() {
        let a = this._fb.group({
            id: [this.critereaCounter],
            name: ['', Validators.required],
            advices: this._fb.array([])
        });
        let mam = <FormArray>a.controls['advices']
        mam.push(this.initAdvice("A"));
        mam.push(this.initAdvice("B"));
        mam.push(this.initAdvice("C"));
        mam.push(this.initAdvice("D"));
        mam.push(this.initAdvice("E"));
        mam.push(this.initAdvice("F"));
        return a;
    }

    initAdvice(g: string) {
        return this._fb.group({
            id: [this.critereaCounter],
            grade: g,
            advice: ['', Validators.required],
        });
    }

    addGeneralCriterea() {
        this.critereaCounter = this.critereaCounter + 1;
        const control = <FormArray>this.examForm.controls['generalCritereas'];
        control.push(this.initGeneralCriterea());
    }


    removeCriterea(i: number) {
        const control = <FormArray>this.examForm.controls['generalCritereas'];
        control.removeAt(i);
    }

    save(model: any) {
        // call API to update
        console.log(model);
    }


}