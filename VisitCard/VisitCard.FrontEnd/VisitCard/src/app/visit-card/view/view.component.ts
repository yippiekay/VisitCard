import { Component, OnInit } from '@angular/core';
import {VisitCardService} from '../visit-card.service';
import {Router} from '@angular/router';
import {VisitCard} from '../card';

@Component({
  selector: 'app-view-card',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  isLoading = false;
  visitCard = new VisitCard();

  constructor(private visitCardService: VisitCardService, private router: Router) { }

  ngOnInit(): void {
    this.getCard();
  }

  async getCard(): Promise<void> {
    try {
      this.isLoading = true;
      this.visitCard = await this.visitCardService.getCard().toPromise();
    } finally {
      this.isLoading = false;
    }
  }

  goToCreatePage(): void {
    this.router.navigate(['']);
  }
}
