import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';


@Component({
    moduleId: module.id,
    selector: 'generalCriterea',
    templateUrl: 'generalCriterea.component.html',
})
export class GeneralCritereaComponent {
    @Input('group')
    public topicForm: FormGroup;
    @Input('topics')
    public topics:any;

    ngOnInit()
    {
        
    }
    constructor(){

    }
}