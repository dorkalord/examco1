import { Component, OnInit } from '@angular/core';

import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { Course } from '../_models/course';
import { CourseService } from '../_services/course.service';
import { GeneralCriterea, Advice, State } from '../_models/criterea';
import { Grade } from '../_models/exam';
import { GradeService } from '../_services/grade.service';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { GeneralCritereaService } from '../_services/criterea.service';

@Component({
    moduleId: module.id,
    selector: "criterea",
    templateUrl: 'criterea.component.html'

})
export class CritereaComponent implements OnInit {

    currentUser: User;
    public critereaList: GeneralCriterea[];
    public gradeList: Grade[];
    public critereaForm: FormGroup;
    public state: State;


    constructor(private userService: UserService,
        private gradeService: GradeService,
        private _fb: FormBuilder,
        private critereaService: GeneralCritereaService
    ) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.critereaForm = this.initForm();
    }

    ngOnInit() {
        this.state = State.Loading;
        this.critereaService.geAll().subscribe(data => {
            this.critereaList = data;
            this.state = State.List;
        });
    }

    initForm() {
        return this._fb.group({
            name: ['', [Validators.required]],
            advices: this._fb.array([])
        });
    }

    initAdvice(a: Advice) {
        return this._fb.group({
            id: [a.id],
            grade: [a.grade],
            top: [a.top],
            text: [a.text, Validators.required]
        });
    }


    add() {
        this.state = State.Loading;
        this.gradeService.getDefault().subscribe(data => {
            this.gradeList = data;
            this.critereaForm = this.initForm();

            const control = <FormArray>this.critereaForm.controls['advices'];

            this.gradeList.forEach(element => {
                control.push(this._fb.group({
                    grade: [element.name],
                    top: [element.top],
                    text: ["", Validators.required]
                }));
            });
            this.state = State.Create;
        });
    }

    save() {
        console.log("saving");
        if (this.state == State.Create) {
            this.critereaService.create(this.critereaForm.value).subscribe(data => {
                this.state = State.List;
                this.ngOnInit();
            });
        }

        if (this.state == State.Edit) {
            this.critereaService.update(this.critereaForm.value).subscribe(data => {
                this.state = State.List;
                 this.ngOnInit();
            });
        }


    }

    edit(id: number) {
        this.state = State.Loading;
        this.critereaService.getById(id).subscribe(data => {

            this.critereaForm = this._fb.group({
                id: [data.id],
                name: [data.name, [Validators.required]],
                advices: this._fb.array([])
            });

            const control = <FormArray>this.critereaForm.controls['advices'];
            (<Advice[]>data.advices).forEach(ad => {
                control.push(this.initAdvice(ad));
            });
            this.state = State.Edit;
        });
    }

    cancel() {
        this.state = State.List;
    }

    remove(id: number) {

    }


}