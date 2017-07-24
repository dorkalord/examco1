import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { AppConfig } from '../app.config';
import { Exam } from '../_models/exam';

@Injectable()
export class ExamService {
    constructor(private http: Http, private config: AppConfig) { }

    getAllCoursesOfUser(userID: number): Exam[] {
        return [];

        //return this.http.get(this.config.apiUrl + '/users', this.jwt()).map((response: Response) => response.json());
    }

    getById(id: number): Exam {

        return null;        //return this.http.get(this.config.apiUrl + '/users/' + id, this.jwt()).map((response: Response) => response.json());
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