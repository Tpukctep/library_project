import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';

@Component({
  selector: 'app-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.css']
})
export class EditFormComponent implements OnInit {

  /*Объект реактивной формы*/
  registrationForm: FormGroup;
    constructor() { }

  ngOnInit() { this.registrationForm = new FormGroup ({
autor_name: new FormGroup({
  lastname: new FormControl(),
  firstname: new FormControl(),
    middlename: new FormControl()
}),
book: new FormGroup ({
book_name: new FormControl(),
publication: new FormControl(),
year_publication: new FormControl()
})
});


  }

}
