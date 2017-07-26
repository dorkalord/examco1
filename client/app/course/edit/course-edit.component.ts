import { Component, OnInit } from '@angular/core';

import { User } from '../../_models/index';
import { UserService, CourseService } from '../../_services/index';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Course } from '../../_models/course';

@Component({
    moduleId: module.id,
    selector: "course-edit",
    templateUrl: 'course-edit.component.html'

})

export class CourseEditComponent implements OnInit {
    currentUser: User;
    public parentTopics: any[];
    public myForm: FormGroup;
    public counter: number;
    id: number;
    sub: any;

    constructor(private userService: UserService,
        private courseService: CourseService,
        private _fb: FormBuilder,
        private route: ActivatedRoute) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));

        this.sub = this.route.params.subscribe(params => {
            this.id = +params['id'];
            this.courseService.getById(this.id).subscribe(data => {
                let currentCourse: Course = data;
                this.counter = 0;
                this.myForm = this._fb.group({
                    lecturerID: [currentCourse.lecturerID],
                    lecturer: [currentCourse.lecturer],
                    code: [currentCourse.code, [Validators.required, Validators.minLength(3)]],
                    name: [currentCourse.name, [Validators.required, Validators.minLength(3)]],
                    topics: this._fb.array([])
                });

                let max: number = 0;
                const control = <FormArray>this.myForm.controls['topics'];

                currentCourse.topics.forEach(item => {
                    if (max < item.id)
                        max = item.id;

                    control.push(this._fb.group({
                        id: item.id,
                        name: item.name,
                        parentTopic: item.parentTopic,
                        description: item.description
                    }));

                });

                this.counter = max;
            });
        });

    }

    ngOnInit() {
        
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
        const topicCtrl = this.initTopic();

        control.push(topicCtrl);
    }

    removeTopic(i: number) {
        const control = <FormArray>this.myForm.controls['topics'];
        control.removeAt(i);
    }

    save(model: any) {
        // call API to update
        console.log(model);
    }

}