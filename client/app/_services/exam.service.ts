import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { AppConfig } from '../app.config';
import { Exam } from '../_models/exam';

@Injectable()
export class ExamService {
    constructor(private http: Http, private config: AppConfig) { }

    getAllExamsofUser(userID: number){
        //return this.http.get(this.config.apiUrl + '/users', this.jwt()).map((response: Response) => response.json());
    }

    getById(id: number): Exam {

        return {
            "id": 1,
            "date": "2017-07-30T20:44:55",
            "courseID": 1,
            "authorID": 1,
            "language": "English",
            "questions": [],
            "censorIDs": [],
            "examCritereas": [
                {
                    "id": 1,
                    "name": "Use of wrong method",
                    "generalCritereaID": null,
                    "gnerealCriterea": null,
                    "advices": [
                        {
                            "id": 1,
                            "advice": "In publishing and graphic design, lorem ipsum is a filler text or greeking commonly used to demonstrate ",
                            "top":10,
                            "grade": "A",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 2,
                            "top":17.5,
                            "grade": "B",
                            "min": 0,
                            "max": 100,
                            "advice": "The lorem ipsum text is typically a scrambled section of De finibus bonorum et malorum, a 1st-century oper Latin."
                        },
                        {
                            "id": 3,
                            "advice": "A variation of the ordinary lorem ipsum text has been used in typesetting since the 1960s or earlier, when it ",
                            "top":10,
                            "grade": "C",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 4,
                            "advice": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut ",
                            "top":10,
                            "grade": "D",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 5,
                            "advice": "It is not known exactly when the text obtained its current standard form; it may have been as late as the ",
                            "top":10,
                            "grade": "E",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 6,
                            "advice": "It is not known exactly when the text obtained its current standard form; it may have been as late as ",
                            "top":10,
                            "grade": "F",
                            "min": 0,
                            "max": 100
                        }
                    ]
                },
                {
                    "id": 2,
                    "name": "Time spent on task",
                    "generalCritereaID": null,
                    "gnerealCriterea": null,
                    "advices": [
                        {
                            "id": 1,
                            "advice": "In publishing and graphic design, lorem ipsum is a filler text or greeking commonly used to demonstrate ",
                            "top":10,
                            "grade": "A",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 2,
                            "top":17.5,
                            "grade": "B",
                            "min": 0,
                            "max": 100,
                            "advice": "The lorem ipsum text is typically a scrambled section of De finibus bonorum et malorum, a 1st-century oper Latin."
                        },
                        {
                            "id": 3,
                            "advice": "A variation of the ordinary lorem ipsum text has been used in typesetting since the 1960s or earlier, when it ",
                            "top":10,
                            "grade": "C",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 4,
                            "advice": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut ",
                            "top":10,
                            "grade": "D",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 5,
                            "advice": "It is not known exactly when the text obtained its current standard form; it may have been as late as the ",
                            "top":10,
                            "grade": "E",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 6,
                            "advice": "It is not known exactly when the text obtained its current standard form; it may have been as late as ",
                            "top":10,
                            "grade": "F",
                            "min": 0,
                            "max": 100
                        }
                    ]
                },
                {
                    "id": 3,
                    "name": "Ability to express yourself academicaly",
                    "generalCritereaID": null,
                    "gnerealCriterea": null,
                    "advices": [
                        {
                            "id": 1,
                            "advice": "In publishing and graphic design, lorem ipsum is a filler text or greeking commonly used to demonstrate ",
                            "top":10,
                            "grade": "A",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 2,
                            "top":17.5,
                            "grade": "B",
                            "min": 0,
                            "max": 100,
                            "advice": "The lorem ipsum text is typically a scrambled section of De finibus bonorum et malorum, a 1st-century oper Latin."
                        },
                        {
                            "id": 3,
                            "advice": "A variation of the ordinary lorem ipsum text has been used in typesetting since the 1960s or earlier, when it ",
                            "top":10,
                            "grade": "C",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 4,
                            "advice": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut ",
                            "top":10,
                            "grade": "D",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 5,
                            "advice": "It is not known exactly when the text obtained its current standard form; it may have been as late as the ",
                            "top":10,
                            "grade": "E",
                            "min": 0,
                            "max": 100
                        },
                        {
                            "id": 6,
                            "advice": "It is not known exactly when the text obtained its current standard form; it may have been as late as ",
                            "top":10,
                            "grade": "F",
                            "min": 0,
                            "max": 100
                        }
                    ]
                }
            ]
        };

        //return this.http.get(this.config.apiUrl + '/users/' + id, this.jwt()).map((response: Response) => response.json());
    }

    create(course: Exam) {
        return this.http.post(this.config.apiUrl + '/users', course, this.jwt());
    }

    update(course: Exam) {
        return this.http.put(this.config.apiUrl + '/users/' + course.id, course, this.jwt());
    }

    delete(id: number) {
        return this.http.delete(this.config.apiUrl + '/users/' + id, this.jwt());
    }

    // private helper methods

    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }
}