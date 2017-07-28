import { Question } from "./question";
import { GeneralCriterea, Advice } from './criterea';

export class Exam {
    id: number;
    courseID: number;
    authorID: number;

    date: string;
    language: string;

    examCriterea: ExamCriterea[];
    questions: Question[];
    censorIDs: number[];

    constructor() {
        this.examCriterea = [];
        this.questions = [];
        this.censorIDs = [];
    }
}

export class ExamCriterea{
    id:number;
    generalCritereaID : number
    gnerealCriterea: GeneralCriterea;

    advices: Advice[];
}

export class Grade {
    id: number;
    grade: string;
    min: number;
    max: number;
    top: number;
}