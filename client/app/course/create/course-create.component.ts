import { Component, OnInit } from '@angular/core';

import { User } from '../../_models/index';
import { UserService } from '../../_services/index';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
    moduleId: module.id,
    selector: "course-create",
    templateUrl: 'course-create.component.html'

})

export class CourseCreateComponent implements OnInit {
    currentUser: User;
    public parentTopics: any[];
    public myForm: FormGroup;
    public counter: number;

    constructor(private userService: UserService, private _fb: FormBuilder) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.counter = 1;
        this.myForm = this._fb.group({
            lecturerID: [this.currentUser.id],
            lecturer: [this.currentUser.name],
            code: ['', [Validators.required, Validators.minLength(3)]],
            name: ['', [Validators.required, Validators.minLength(3)]],
            topics: this._fb.array([])
        });

        this.addTopic();
    }

    initTopic() {
        return this._fb.group({
            id: [this.counter],
            name: ['', Validators.required],
            parentTopic: [''],
            description: ['']
        });
    }

    addTopic() {
        this.counter = this.counter + 1;
        const control = <FormArray>this.myForm.controls['topics'];
        const addrCtrl = this.initTopic();

        control.push(addrCtrl);
    }

    removeTopic(i: number) {
        const control = <FormArray>this.myForm.controls['topics'];
        control.removeAt(i);
    }

    save(model: any) {
        
        // call API to save
        console.log(model);
    }

    
}