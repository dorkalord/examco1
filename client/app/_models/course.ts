
export class Course {
    id: number;
    lecturerID: number;
    lecturer: string;

    name: string;
    code: string;

    topics: Topic[];
}

export class Topic {
    id: number;
    courseID: number;

    name: string;
    description: string;
    parentTopic: number;
}