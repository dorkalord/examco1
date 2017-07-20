import { Component, OnInit } from '@angular/core';

import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { Course } from '../_models/course';

@Component({
    moduleId: module.id,
    selector: "course",
    templateUrl: 'course.component.html'
    
})

export class CourseComponent implements OnInit {
    currentUser: User;
    courseList: Course[];

    constructor(private userService: UserService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.courseList = [
            {id: 1, code: "inf220", name:"informatics", lecturerID:1, topics:[]},
            {id: 2, code: "inf223", name:"informatics1", lecturerID:1, topics:[]}
        ]
    }


}