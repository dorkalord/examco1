export class Course {
    id: number;
    name: string;
    code: string;
    lecturerID: number;
    topics: Topic[];
}

export class Topic{
    id: number;
    name: string;
    description: string;
    parentTopic: number;
    courseID: number;
}