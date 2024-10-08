import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css']
})
export class ToastComponent {
  @Input() message: string = '';
  @Input() duration: number = 3000;
  @Input() score=0;
  @Output() toastvalue=new EventEmitter<boolean>();
  showToast: boolean = false;

  displayToast() {
    // this.message = message;
    this.showToast = true;
  
    setTimeout(() => {
      this.showToast = false;
    }, this.duration);
      this.toastvalue.emit(true);
  }
}
