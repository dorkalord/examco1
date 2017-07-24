import { Question } from "./question";

export class Exam {
    id: number;
    courseID: number;
    authorID: number;

    date: Date;
    language: string;

    generalCritereas: GeneralCriterea[];
    qetions: Question[];
    censorIDs: number[];

    constructor(){
        this.generalCritereas = [];
        this.qetions = [];
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
    gradeID: string;

    advice: string;
    min: number;
    max: number;
}
