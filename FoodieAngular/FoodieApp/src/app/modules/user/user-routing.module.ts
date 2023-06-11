import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewuserComponent } from './newuser/newuser.component';

const routes: Routes = [

  //new user registration
  {path: 'newuser', component:NewuserComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
