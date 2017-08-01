import { Component, OnInit } from '@angular/core';

import { User } from '../../../_models/index';
import { UserService, CourseService } from '../../../_services/index';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Course, Topic } from '../../../_models/course';
import { ExamService } from '../../../_services/exam.service';
import { Exam } from '../../../_models/exam';
import { Question } from '../../../_models/question';
import { ExamDataTransferService } from '../../../_services/exam-datatransfer.service';

@Component({
    moduleId: module.id,
    selector: "exam-questions",
    templateUrl: 'exam-questions.component.html'

})

export class ExamQuestionsComponent implements OnInit {
    currentUser: User;
    currentExam: Exam;
    currentCourse: Course
    public questions: Question[];
    public questionForm: FormGroup;
    public counter: number;
    //id: number;
    sub: any;

    constructor(private userService: UserService,
        private examService: ExamService,
        private courseService: CourseService,
        private _fb: FormBuilder,
        private route: ActivatedRoute,
        private dataTransfer: ExamDataTransferService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));

        this.counter = 1;
        this.questions = [];
        
        this.currentExam = this.dataTransfer.currentExam;
        this.currentCourse = this.dataTransfer.currentCourse;
        
        this.questionForm = this.initQestion(this.currentExam.id);
    }

    ngOnInit() {

    }

    initQestion(examID: number) {
        return this._fb.group({
            id: this.counter,
            examID: examID,

            seqenceNumber: [this.questions.length + 1, Validators.required],
            text: ['', Validators.required],
            parentQestionID: "",
            arguments: this._fb.array([]),
            topicIDs: this._fb.array([]),
        });
    }

    addQuestion() {
        this.counter = this.counter + 1;
        this.questions.push(this.questionForm.value);
        this.questionForm = this.initQestion(this.currentExam.id);
    }

    removeQuestion(i: number) {
        let deletingQestion = this.questions[i];

        this.questions.forEach(element => {
            if (element.seqenceNumber > deletingQestion.seqenceNumber)
                element.seqenceNumber -= 1;
            if (element.parentQestionID == deletingQestion.id)
                element.parentQestionID = null;
        });

        this.questions.splice(i, 1);

        if (this.questionForm.value.parentQestionID == deletingQestion.id)
            this.questionForm.value.parentQestionID = null;

        this.questionForm = this._fb.group({
            id: this.counter,
            examID: this.currentExam.id,

            seqenceNumber: [this.questions.length + 1, Validators.required],
            text: [this.questionForm.value.text, Validators.required],
            parentQestionID: this.questionForm.value.parentQestionID,
            arguments: this.questionForm.controls.arguments,
            topicIDs: this._fb.array(this.questionForm.value.topicIDs),
        });
    }

    save(i: number) {
        let index = this.questions.findIndex(x => x.id == i)
        if (index === -1)
            this.addQuestion()
        else {
            this.questions[index] = this.questionForm.value;
            this.questionForm = this.initQestion(this.currentExam.id);
        }
    }

    cancel() {
        this.questionForm = this.initQestion(this.currentExam.id);
    }

    edit(i: number) {
        let q = this.questions[i];

        this.questionForm = this._fb.group({
            id: q.id,
            examID: q.examID,

            seqenceNumber: [q.seqenceNumber, Validators.required],
            text: [q.text, Validators.required],
            parentQestionID: q.parentQestionID,
            arguments: this._fb.array(q.arguments),
            topicIDs: this._fb.array(q.topicIDs),
        });
    }

}