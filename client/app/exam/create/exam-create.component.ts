import { Component, OnInit } from '@angular/core';

import { User, Topic, Course } from '../../_models/index';
import { UserService, CourseService } from '../../_services/index';
import { FormGroup, FormControl, FormBuilder, FormArray, Validators } from '@angular/forms';

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
        this.courses = this.courseService.getAllCoursesOfUser(this.currentUser.id);
        this.critereaCounter = 0;
        this.examForm = this._fb.group({
            date: ['', Validators.required],
            courseID: ['', Validators.required],
            language: ['', Validators.required],
            generalCritereas: this._fb.array([])
        });
        this.addGeneralCriterea();
    }

    initGeneralCriterea() {
        let a = this._fb.group({
            id: [this.critereaCounter],
            name: ['', Validators.required],
            advices: this._fb.array([])
        });
        let mam = <FormArray>a.controls['advices']
        mam.push(this.initAdvice());
        return a;
    }

    initAdvice() {
        return this._fb.group({
            id: [this.critereaCounter],
            grade: ['', Validators.required],
            advice: ['', Validators.required],
            min: ['', Validators.required],
            max: ['', Validators.required]
        });
    }

    addGeneralCriterea() {
        this.critereaCounter = this.critereaCounter + 1;
        const control = <FormArray>this.examForm.controls['generalCritereas'];
        const criteraCtrl = this.initGeneralCriterea();

        control.push(criteraCtrl);
    }

    addAdvice(i: number)
    {
        this.critereaCounter = this.critereaCounter + 1;
        const control = <FormArray>this.examForm.controls['generalCritereas'].controls[i].controls.advices.controls;
        control.push(this.initAdvice());
    }

    removeTopic(i: number) {
        const control = <FormArray>this.examForm.controls['generalCritereas'];
        control.removeAt(i);
    }

    save(model: any) {
        // call API to update
        console.log(model);
    }


}