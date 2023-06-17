import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { UserRoutingModule } from './user-routing.module';
import { NewuserComponent } from './newuser/newuser.component';



@NgModule({
  declarations: [
    NewuserComponent,
    

  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    ReactiveFormsModule

  ]
})
export class UserModule { }
