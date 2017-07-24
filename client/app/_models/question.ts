export class Question{
    id: number;
    examID: number;
    parentQestionID: number;

    seqenceNumber: number;
    text: string;
    
    arguments: Argument[];
    topicIDs: number[];
}

export class Argument{
    id: number;
    authorID: number;
    parentArgumentID: number;
    qestionID: number;

    text: string;
    advice: string;
    weight: number;
    variable: boolean;
    minText: string;
    maxText: string;
    minWeight: number;
    maxWeight: number;

    argumentCritereas: ArgumentCriterea[];
}

export class ArgumentCriterea{
    id: number;
    argumentID: number;
    generalCritereaID: number;

    severity: number;
}