import { Question } from "./question";
import { GeneralCriterea, Advice } from './criterea';

export class Exam {
    id: number;
    courseID: number;
    authorID: number;
    stateID: number;

    date: string;
    language: string;
    status: string;

    examCritereas: ExamCriterea[];
    questions: Question[];
    censorIDs: number[];

    constructor() {
        this.examCritereas = [];
        this.questions = [];
        this.censorIDs = [];
    }
}

export class ExamCriterea{
    id:number;
    name: string;
    generalCritereaID : number
    gnerealCriterea: GeneralCriterea;

    advices: Advice[];
}

export class Grade {
    id: number;
    name: string;
    min: number;
    max: number;
    top: number;
}