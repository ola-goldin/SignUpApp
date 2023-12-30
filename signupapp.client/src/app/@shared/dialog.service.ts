import { Injectable, Injector } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { EditUserComponent } from '../users/edit-users/edit-user.component';
@Injectable({
  providedIn: 'root',
})
export class DinamicDialogService {
  ref: DynamicDialogRef | undefined;
  private dialogService: DialogService;

  constructor(private injector: Injector) {
    this.dialogService = this.injector.get(DialogService);
  }

  show(data?: any) {
    const dialogConfig = {
      header: data ? 'Edit Item' : 'Add item',
      data,
    };
    this.ref = this.dialogService.open(EditUserComponent, dialogConfig);
  }
}
