import { Component, OnInit } from '@angular/core';

import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { Course } from '../_models/course';
import { CourseService } from '../_services/course.service';
import { GeneralCriterea } from '../_models/criterea';

@Component({
    moduleId: module.id,
    selector: "criterea",
    templateUrl: 'criterea.component.html'

})

export class CritereaComponent implements OnInit {
    currentUser: User;
    public critereaList: GeneralCriterea[];

    constructor(private userService: UserService,
        private courseService: CourseService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.courseService.getAllCoursesOfUser(this.currentUser.id).subscribe(data => {
            this.courseList = data;
        });
    }

    ngOnInit() {

    }

    remove(id: number) {
        this.courseService.delete(id).subscribe(res => {
            this.courseService.getAllCoursesOfUser(this.currentUser.id).subscribe(data => {
                this.courseList = data;
            });
        });

    }


}