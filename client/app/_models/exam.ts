import { Question } from "./question";

export class Exam {
    id: number;
    courseID: number;
    authorID: number;

    date: string;
    language: string;

    generalCritereas: GeneralCriterea[];
    questions: Question[];
    censorIDs: number[];

    constructor() {
        this.generalCritereas = [];
        this.questions = [];
        this.censorIDs = [];
    }
}

export class GeneralCriterea {
    id: number;
    name: string;
    advices: Advice[];
}

export class Advice {
    id: number;
    grade: Grade;
    advice: string;
}

export class Grade {
    id: number;
    grade: string
    min: number;
    max: number;
}