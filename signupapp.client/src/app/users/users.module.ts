import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './users.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ThemeModule } from '../@shared/theme/theme.module';
import { UsersRoutingModule } from './user.routing.module';
import { EditUserComponent } from './edit-users/edit-user.component';
import { DinamicDialogService } from '../@shared/dialog.service';

@NgModule({
  declarations: [UsersComponent, EditUserComponent],
  providers: [ DinamicDialogService],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ThemeModule,
    UsersRoutingModule,
  ]
})
export class UsersModule { }
