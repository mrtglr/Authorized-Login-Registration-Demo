import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  private readonly baseUrl = 'https://localhost:5001/api';

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })
  });

  comparePasswords(fb: FormGroup) : ValidationErrors | null {
    let confirmPswdCtrl = fb.get('ConfirmPassword');
    if(confirmPswdCtrl?.errors == null || 'passwordMismatch' in confirmPswdCtrl.errors){
      if(fb.get('Password')?.value != confirmPswdCtrl?.value)
        confirmPswdCtrl?.setErrors({passwordMismatch: true});
        else
        confirmPswdCtrl?.setErrors(null); 
        
    }
    return null;
  }

  register() {
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password,
      Fullname: this.formModel.value.Fullname
    };
    return this.http.post(this.baseUrl + '/ApplicationUser/Register', body);
  }

  login(formData: any) {
    return this.http.post(this.baseUrl + '/ApplicationUser/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.baseUrl+'/UserProfile');
  }
}
