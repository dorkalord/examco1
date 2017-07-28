export class GeneralCriterea {
    id: number;
    name: string;
    advices: Advice[];
}

export class Advice {
    id: number;
    gradeID: number;
    advice: string;
    grade: string;
    min: number;
    max: number;
    top: number;
}

