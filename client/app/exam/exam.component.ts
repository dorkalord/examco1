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
    examlist: Exam[];
    censorExams: Exam[];
    states: State[];
    loading: boolean;

    constructor(private userService: UserService,
        private examService: ExamService,
        private stateService: StateService
    ) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.examlist = new Array();
        this.censorExams = new Array();
        this.loading = false;
    }

    ngOnInit() {
        this.loadData();
    }

    loadData(){
        this.loading = true;
        this.examService.getAllExamsofAuthor(this.currentUser.id).subscribe(data => {
            this.examlist = data;
            this.stateService.getAllStates().subscribe(res => {
                this.states = res;
                this.examService.getAllExamsofCensor(this.currentUser.id).subscribe(res => {
                    this.censorExams = res;
                    this.loading = false;
                });
            });
        });
    }

    edit(id: number) {
        alert("Waiting for implentation")
    }

    chanegeState(id: number, state: number) {
        this.loading = true;
        this.examService.updateExamState(id, state).subscribe(data => {
            this.loadData();
        });
    }
    
    censor(id: number) {
        alert("Waiting for implentation")
    }
    grade(id: number) {
        alert("Waiting for implentation")
    }
    generateReports(id: number) {
        alert("Waiting for implentation")
    }
    exportCensorship(id: number) {
        alert("Waiting for implentation")
    }
    export(id: number) {
        alert("Waiting for implentation")
    }
}