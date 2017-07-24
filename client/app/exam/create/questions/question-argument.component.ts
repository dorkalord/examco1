import { Component, OnInit, Input } from '@angular/core';

import { User } from '../../../_models/index';
import { UserService, CourseService } from '../../../_services/index';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Course, Topic } from '../../../_models/course';
import { ExamService } from '../../../_services/exam.service';
import { Exam, GeneralCriterea } from '../../../_models/exam';
import { Question, Argument, ArgumentCriterea } from '../../../_models/question';

@Component({
    moduleId: module.id,
    selector: "question-argument",
    templateUrl: 'question-argument.component.html'

})

export class QestionArgumentComponent implements OnInit {
    @Input('group')
    public arguments: FormArray;

    @Input('exam')
    public currentExam: Exam;

    @Input('qestionid')
    public qestionID: number;

    currentUser: User;
    public questions: Question[];
    public argumentForm: FormGroup;
    public counter: number;
    id: number;
    sub: any;

    constructor(private userService: UserService,
        private ExamService: ExamService,
        private _fb: FormBuilder,
        private route: ActivatedRoute) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));

    }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.id = +params['id'];


            this.counter = 1;
            this.questions = [];
            this.argumentForm = this.initArgument();

        });
    }

    initArgument() {
        return this._fb.group({
            id: this.counter,
            authorID: this.currentUser.id,
            parentArgumentID: null,
            qestionID: this.qestionID,

            text: ['', Validators.required],
            advice: [''],
            weight: [''],
            variable: [false, Validators.required],
            minText: [''],
            maxText: [''],
            minWeight: [0],
            maxWeight: [0],

            argumentCritereas: this._fb.array(this.initArgumentCriterea(this.counter))
        });
    }

    initArgumentCriterea(argumentid: number){
        let ac: ArgumentCriterea[] = new Array();
        let c = 0;
        this.currentExam.generalCritereas.forEach(element => {
            ac.push({
                id: this.counter *  this.currentExam.generalCritereas.length + c,
                argumentID: argumentid,
                generalCritereaID: element.id,
                severity: 0
            });
            c++;
        });
        return ac;
    }

    addArgument() {
        this.counter = this.counter + 1;
        this.arguments.push(this.argumentForm);
        this.argumentForm = this.initArgument();
    }

    removeArgument(i: number) {
        /*let deletingQestion = this.questions[i];

        this.questions.forEach(element => {
            if(element.seqenceNumber > deletingQestion.seqenceNumber)
                element.seqenceNumber -= 1;
        });

        this.questions.splice(i,1);
        
        if(this.questionForm.value.parentQestionID == deletingQestion.id)
            this.questionForm.value.parentQestionID = null;

        this.questionForm = this._fb.group({
            id: this.counter,
            examID: this.currentExam.id,
    
            seqenceNumber: [this.questions.length+1, Validators.required],
            text: [this.questionForm.value.text, Validators.required],
            parentQestionID: this.questionForm.value.parentQestionID,
            arguments: this.questionForm.controls.arguments,
            topicIDs: this.questionForm.controls.topicIDs,
        });*/
    }

    save(i: number) {
        let field: Argument[] = this.arguments.value;
        let index: number = field.findIndex(x => x.id == i);

        if (index === -1) {
            this.counter = this.counter + 1;
            this.arguments.push(this.argumentForm);
        }

        else {
            this.arguments.value[index] = this.argumentForm.value;
        }

        this.argumentForm = this.initArgument();
    }

    cancel() {
        this.argumentForm = this.initArgument();
    }

    edit(i: number) {
        let a : Argument = this.arguments.value[i];

        this.argumentForm = this._fb.group({
            id: a.id,
            authorID: this.currentUser.id,
            parentArgumentID: a.parentArgumentID,
            qestionID: a.qestionID,

            text: [a.text, Validators.required],
            advice: [a.advice],
            weight: [a.weight],
            variable: [false, Validators.required],
            minText: [a.minText],
            maxText: [a.maxText],
            minWeight: [a.minWeight],
            maxWeight: [a.maxWeight],

            argumentCritereas: this._fb.array(this.initArgumentCriterea(a.id))
        });
        
        let c = 0;
        (<ArgumentCriterea[]>this.argumentForm.value.argumentCritereas).forEach(element => {
            element.severity = a.argumentCritereas[c].severity; c++;
        });
    }

    updateCriterea(weight:number, critereaid:number){
        let ac: ArgumentCriterea[] = this.argumentForm.value.argumentCritereas;
        let index: number = ac.findIndex(a => a.generalCritereaID == critereaid);

        this.argumentForm.value.argumentCritereas[index].severity = weight;
        console.log("weight: ", weight, " criterea ID: ", critereaid);
    }

}