import { Component, OnInit } from '@angular/core';

import { User } from '../_models/index';
import { UserService } from '../_services/index';
import { ExamService } from '../_services/exam.service';
import { Exam } from '../_models/exam';
import { StateService } from '../_services/state.service';
import { State } from '../_models/state';
import { DatePipe } from '@angular/common';

@Component({
    moduleId: module.id,
    selector: "exam",
    templateUrl: 'exam.component.html'

})

export class ExamComponent implements OnInit {
    currentUser: User;
    examlist: any;
    states: State[]

    constructor(private userService: UserService,
                private examService: ExamService,
                private stateService: StateService
    ) {
        
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        
    }

    ngOnInit() {
        console.log("userid", this.currentUser.id);
        this.examService.getAllExamsofAuthor(this.currentUser.id).subscribe(data => {
            this.examlist = data;
            console.log(data);
            this.stateService.getAllStates().subscribe(res=>{
                this.states = res;
            })
        });
    }
}