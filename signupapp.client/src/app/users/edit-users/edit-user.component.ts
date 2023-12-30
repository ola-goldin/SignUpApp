import { Component, OnDestroy } from '@angular/core';

import { Gender, User } from '../user.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsersService } from 'src/app/@shared/users.service';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',

  styleUrls: ['./edit-user.component.scss'],
})
export class EditUserComponent implements OnDestroy {


  constructor(
    private formBuilder: FormBuilder, private userService: UsersService, public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }
  data: User | null = null;
  form: FormGroup = this.formBuilder.group({});;
  genders = Gender;
  ngOnInit(): void {
    this.data = this.config.data;
    this.form = this.formBuilder.group({
      identityNumber: [this.data?.identityNumber, [Validators.required, Validators.pattern('^[0-9]+$'), Validators.minLength(6),
      Validators.maxLength(9)]],
      firstName: [this.data?.firstName, [Validators.required, Validators.pattern(/^[A-Za-z\s' -]*$/)]],
      lastName: [this.data?.lastName, [Validators.required, Validators.pattern(/^[A-Za-z\s' -]*$/)]],
      email: [this.data?.email, [Validators.email]],
      dateOfBirth: [
        this.data?.dateOfBirth ? new Date(this.data.dateOfBirth).toISOString().split('T')[0] : null,
        [Validators.required],
      ],
      gender: [this.data?.gender ?? null],
      phoneNumber: [
        this.data?.phoneNumber,
        [
          Validators.pattern('^[0-9]+$'),
          Validators.minLength(6),
          Validators.maxLength(10),
        ],
      ],
    });
  }

  onSubmit() {
    const user = { id: this.data?.id || '0', ...this.form.value }
    this.userService.addOrUpdateUser(user).subscribe(updatedUser => {
      const { value } = this.userService.allUsers;
    
      if (!updatedUser) {
        const idx = value.findIndex(x => x.id === user.id);
        value[idx] = user;
      } else {
        value.unshift(updatedUser);
      }
    
      this.userService.allUsers.next([...value]); // Creating a new array to trigger BehaviorSubject update
      this.ref.close();
    });

  }

  ngOnDestroy(): void {
    
  }

}
