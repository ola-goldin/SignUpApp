import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users.component';
import { EditUserComponent } from './edit-users/edit-user.component';

const routes: Routes = [
    {
        path: '',
        component: UsersComponent,
     
    },  {
        path: 'edit/:userId',
        component: UsersComponent,
    },
    {
        path: 'add',
        component: UsersComponent,
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UsersRoutingModule { }