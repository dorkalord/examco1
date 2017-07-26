import { Component, OnInit } from '@angular/core';

import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { Course } from '../_models/course';
import { CourseService } from '../_services/course.service';

@Component({
    moduleId: module.id,
    selector: "course",
    templateUrl: 'course.component.html'

})

export class CourseComponent implements OnInit {
    currentUser: User;
    courseList: Course[];

    constructor(private userService: UserService,
        private courseService: CourseService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.courseService.getAllCoursesOfUser(this.currentUser.id).subscribe(data => {
            this.courseList = data;
        });
    }

    ngOnInit() {
        
    }


}