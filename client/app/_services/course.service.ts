import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { AppConfig } from '../app.config';
import { Course } from '../_models/course';

@Injectable()
export class CourseService {
    constructor(private http: Http, private config: AppConfig) { }

    getAllCoursesOfUser(userID: number): Course[] {
        return [{
            id: 1,
            "lecturerID": 1,
            "code": "INF220",
            "name": "Informatics",
            "topics": [
                { "courseID": 1, "id": 1, "name": "topic 1", "parentTopic": 0, "description": "" },
                { "courseID": 1, "id": 2, "name": "topic 2", "parentTopic": 1, "description": "" },
                { "courseID": 1, "id": 4, "name": "topic 3", "parentTopic": 0, "description": "asdsadasd" }
            ]
        },
        {
            id: 2,
            "lecturerID": 1,
            "code": "INF223",
            "name": "Informatics1",
            "topics": [
                { "courseID": 1, "id": 11, "name": "topic 11", "parentTopic": 0, "description": "" },
                { "courseID": 1, "id": 21, "name": "topic 21", "parentTopic": 1, "description": "" },
                { "courseID": 1, "id": 41, "name": "topic 31", "parentTopic": 0, "description": "asdsadasd" }
            ]
        }
        ]

        //return this.http.get(this.config.apiUrl + '/users', this.jwt()).map((response: Response) => response.json());
    }

    getById(id: number): Course {

        return {
            id: 1,
            "lecturerID": 1,
            "code": "INF220",
            "name": "Informatics",
            "topics": [
                { "courseID": 1, "id": 1, "name": "topic 1", "parentTopic": 0, "description": "" },
                { "courseID": 1, "id": 2, "name": "topic 2", "parentTopic": 1, "description": "" },
                { "courseID": 1, "id": 4, "name": "topic 3", "parentTopic": 0, "description": "asdsadasd" }
            ]
        }
        //return this.http.get(this.config.apiUrl + '/users/' + id, this.jwt()).map((response: Response) => response.json());
    }

    create(course: Course) {
        return this.http.post(this.config.apiUrl + '/users', course, this.jwt());
    }

    update(course: Course) {
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