import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { NewuserComponent } from './newuser/newuser.component';
import { HeaderComponent } from 'src/app/Components/header/header.component';
import { AppModule } from 'src/app/app.module';


@NgModule({
  declarations: [
    NewuserComponent,
    

  ],
  imports: [
    CommonModule,
    UserRoutingModule,

  ]
})
export class UserModule { }
