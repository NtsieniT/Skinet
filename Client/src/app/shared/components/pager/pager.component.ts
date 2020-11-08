import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {
  // input recieves info from parent to child component
  @Input() totalCount: number;
  @Input() pageSize: number;

  // used to emit info out from component to other component
  // child component sends info to parent component
  @Output() pageChanged = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }


  onPagerChange(event: any){
    this.pageChanged.emit(event.page);
  }

}
