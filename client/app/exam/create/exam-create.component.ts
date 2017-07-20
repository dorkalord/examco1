import { Component, OnInit } from '@angular/core';

import { User } from '../../_models/index';
import { UserService } from '../../_services/index';

@Component({
    moduleId: module.id,
    selector: "exam-create",
    templateUrl: 'exam-create.component.html'
    
})

export class ExamCreateComponent implements OnInit {
    currentUser: User;
    public topics: any[];

    constructor(private userService: UserService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.topics =  [
            { display: 'Topic 2' },
            { display: 'Topic 3' },
            { display: 'Topic 4' }
        ];
    }


}