import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-page-navigator',
  templateUrl: './page-navigator.component.html',
  styleUrls: ['./page-navigator.component.css']
})
export class PageNavigatorComponent implements OnInit {

  @Input() currentPage: number = 1;
  @Input() navigatorSize: number = 5;
  @Input() totalPages: number = 0;
  @Output() pageChange: EventEmitter<number> = new EventEmitter<number>();

  public get getPages(): number[] {
    let startPage: number = this.currentPage - Math.floor(this.navigatorSize / 2);
    startPage = startPage < 1 ? 1 : startPage;
    let endPage: number = this.currentPage + Math.floor(this.navigatorSize / 2);
    endPage = endPage > this.totalPages ? this.totalPages : endPage;

    if(endPage - startPage < this.navigatorSize) {
      if(startPage > 1) {
        startPage = startPage - (this.navigatorSize - (endPage - startPage));
        startPage = startPage < 1 ? 1 : startPage;
      } else {
        endPage = endPage + (this.navigatorSize - (endPage - startPage));
        endPage = endPage > this.totalPages ? this.totalPages : endPage;
      }
    }
    
    return Array.from(Array(endPage - startPage + 1).keys()).map(i => i + startPage);
  }

  constructor() { }

  ngOnInit(): void {
  }

  public onPageChange(page: number): void {
    this.currentPage = page;
    this.pageChange.emit(page);
  }

  public onPrevious(): void {
    if (this.currentPage > 1) {
      this.onPageChange(this.currentPage - 1);
    }
  }

  public onNext(): void {
    if (this.currentPage < this.totalPages) {
      this.onPageChange(this.currentPage + 1);
    }
  }

  public onFirst(): void {
    this.onPageChange(1);
  }

  public onLast(): void {
    this.onPageChange(this.totalPages);
  }
}
