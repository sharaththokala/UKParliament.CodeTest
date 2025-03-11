import { Component, Input } from '@angular/core';
import { PersonListItemModel } from '../../../../app/shared/interface/person-list-item-model';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrl: './person-list.component.scss'
})
export class PersonListComponent {
  @Input() people: PersonListItemModel[] | undefined;
}
