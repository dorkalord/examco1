import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';


@Component({
    moduleId: module.id,
    selector: 'advice',
    templateUrl: 'generalCriterea.component.html',
})
export class GeneralCritereaComponent {
    @Input('group')
    public advice: FormGroup;

    ngOnInit()
    {
        
    }
    constructor(){

    }
}