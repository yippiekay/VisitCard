import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {VisitCardService} from '../visit-card.service';
import {IVisitCard} from '../../shared/models/visitCard';
import { VisitCard } from '../card';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [VisitCardService]
})
export class CreateComponent implements OnInit {
  isLoading = false;
  visitCard: IVisitCard = new VisitCard();

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

  async updateCard(): Promise<void> {
    try {
      this.isLoading = true;
      await this.visitCardService.updateCard(this.visitCard).toPromise();
      await this.router.navigate(['view']);
    } finally {
      this.isLoading = false;
    }
  }
}




