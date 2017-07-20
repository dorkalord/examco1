import { Component, OnInit } from '@angular/core';

import { User, Topic, Course } from '../../_models/index';
import { UserService, CourseService } from '../../_services/index';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';

@Component({
    moduleId: module.id,
    selector: "exam-create",
    templateUrl: 'exam-create.component.html'
    
})

export class ExamCreateComponent implements OnInit {
    currentUser: User;
    public courses: Course[];
    public examForm: FormGroup;

    constructor(private userService: UserService,
                private courseService: CourseService,
                private _fb: FormBuilder,) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        
    }
 
    ngOnInit() {
        this.courses = this.courseService.getAllCoursesOfUser(this.currentUser.id);
        this.examForm = this._fb.group({
            date: "",
            courseID :"",
            language: "",
            generalCriterea: this._fb.array([])
        });

        console.log("courses", this.courses);
    }

    



}