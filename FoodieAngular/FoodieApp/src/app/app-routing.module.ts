import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';

const routes: Routes = [

  //default path 

  {path: '', component: HomeComponent},
 //for the student related things
//lazy loading
{path:"user",loadChildren:()=>import('./modules/user/user.module').then(mod=>mod.UserModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
