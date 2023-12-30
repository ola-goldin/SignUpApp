import { Component, OnInit } from '@angular/core';
import { UsersService } from '../@shared/users.service';
import { Gender, User } from './user.model';
import { Router } from '@angular/router';
import { DinamicDialogService } from '../@shared/dialog.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {
  constructor(private readonly httpService: UsersService, private router: Router, private dialog: DinamicDialogService) { }
  users: User[] = [];
  genders = Gender;

  ngOnInit(): void {
    this.httpService.getUsers().subscribe();
    this.httpService.allUsers.subscribe(x=>this.users = x)
  }

  onRowEditSave(user?: User) {
    this.dialog.show(user);
  }

  onRowDelete(id: number, index: number) {
    this.httpService.deleteUser(id).subscribe(x => {
     this.users = this.users.filter(x=> x.id !== id)
    });
  }
}
