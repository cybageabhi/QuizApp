import { Component, OnInit } from '@angular/core';
import { QuizService } from '../../services/quiz.service';
import { ToastrService } from 'ngx-toastr';
import { QuizResponse, QuizQuestion, QuizAnswer } from '../../Model/quiz-question.model';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  showToast: boolean = false;
  questions: QuizQuestion[] = []; // Store questions
  total: number = 0;
  answer: number[] = [];
  correctOnce: number[] = [];

  constructor(private quizService: QuizService, private toastr: ToastrService) {}

  ngOnInit(): void {
    // Pass the dataSource query parameter as 'file'
    const queryParams = { dataSource: 'db' }; // You can change this to 'db' if needed
    this.quizService.getQuestions(queryParams).subscribe(
      (data: QuizQuestion[]) => { 
        this.questions = data;
         
        // Loop through questions to get the correct answers
        this.questions.forEach((question, index) => {
          // console.log(question);
          
          const correctOption = question.answers.find(option => option.isCorrect);
          if (correctOption) {
            // console.log("the option is "+JSON.stringify(correctOption.id));
            this.correctOnce[index] = correctOption.id % 4; // Assuming you meant to use 'id' instead of 'answerId'
          }
        });

        console.log("Correct answers:", this.correctOnce);
      },
      (error) => {
        console.error('Error fetching questions', error);
      }
    );
  }

  handleOptionSelected(event: { selectedOption: number, questionNo: number }) {
    const { selectedOption, questionNo } = event;
    this.answer[questionNo - 1] = selectedOption;
    console.log(this.answer)
  }

  evaluate() {
    this.total = 0;
    for (let i = 0; i < this.correctOnce.length; i++) {
      console.log(this.correctOnce[i],this.answer[i]);
      if (this.correctOnce[i] === this.answer[i]) {
        this.total++;
      }
    }
    console.log("Total correct answers are " + this.total);
  }

  handlevalue(value: boolean) {
    this.showToast = value;
    setTimeout(() => {
      this.showToast = false;
    }, 3000);
  }
}
