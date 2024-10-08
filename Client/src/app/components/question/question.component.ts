import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css'] 
})
export class QuestionComponent {
  @Input() question: any;
  @Output() optionSelected = new EventEmitter<{selectedOption:number,questionNo:number}>();
  ngOnInit(){
    console.log("we havev question as "+JSON.stringify(  this.question.answers[1].id))
  }
  selectedOption: { [key: number]: number } = {};
  onOptionSelect(selectedOption: number,questionNo:number) {
    console.log('Selected option is: ' + selectedOption,questionNo);
    this.selectedOption[questionNo] = selectedOption; 
    this.optionSelected.emit({selectedOption,questionNo});
  }
}
