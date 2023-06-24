import { Component } from '@angular/core';
import {FormControl, FormGroup,Validators } from '@angular/forms';
import {OnInit} from '@angular/core'
import {newUser} from 'src/app/models/newuser'
import {Communication} from 'src/app/services/CScommunication'
@Component({
  selector: 'app-newuser',
  templateUrl: './newuser.component.html',
  styleUrls: ['./newuser.component.css']
})
export class NewuserComponent implements OnInit {

constructor(private communication:Communication)
{

}
userRegistration: any;
showErrorMessage:boolean = false;
Errortext:string = "";
  ngOnInit(): void {
  
    this.userRegistration = new FormGroup({
      name: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', Validators.required),
      phone: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
    });
  }

  submitForm(){
    
    const newuser :newUser ={
      Name:this.name.value,
      Phone:this.phone.value,
      Address :this.address.value,
      Email:this.email.value,
      Password:this.password.value
    }

   this.communication.newUserRequest(newuser).subscribe(r=>{
    if(r.status !== 200)
    {
      this.showErrorMessage = true;
      this.Errortext = r.Message;
    }else{
      
    }
   }
  
   
   )

    
  }
   // Accessor methods for form controls

   get name() {
    return this.userRegistration.get('name');
  }

  get email() {
    return this.userRegistration.get('email');
  }

  get password() {
    return this.userRegistration.get('password');
  }

  get address() {
    return this.userRegistration.get('password');
  }

  get phone() {
    return this.userRegistration.get('password');
  }
  
}
