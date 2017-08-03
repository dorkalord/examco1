import { Component, OnInit } from '@angular/core';

import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { Course } from '../_models/course';
import { CourseService } from '../_services/course.service';
import { ExamAttempt } from '../_models/examAttempt';
import { ExamAttemptService } from '../_services/examAttempt.service';
import { ExamService } from '../_services/exam.service';
import { ExamAttemptDataTransferService } from '../_services/examAttempt-datatransfer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    moduleId: module.id,
    selector: "examAttempt-list",
    templateUrl: 'examAttempt-list.html'

})

export class ExamAttemptListComponent implements OnInit {
    currentUser: User;
    public examAttemptList: ExamAttempt[];

    constructor(private userService: UserService,
                private courseService: ExamAttemptService,
                private examService: ExamService,
                private route: ActivatedRoute,
                private examAttemptDataTransferService: ExamAttemptDataTransferService
    ) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
      
    }

    ngOnInit() {

    }

    edit(id: number){

    }

    create(id: number){
        
    }

    remove(id: number) {
        alert("not implemented jet");
    }


}