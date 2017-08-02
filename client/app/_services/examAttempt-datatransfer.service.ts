import { Injectable } from '@angular/core';
import { Exam } from '../_models/exam';
import { ExamAttemt } from '../_models/examAttempt';

@Injectable()
export class ExamAttemptDataTransferService {
    constructor() { }

    public examAttempts: ExamAttemt[];
    public currentExam: Exam;
    
}