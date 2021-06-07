import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-my-form',
  templateUrl: './my-form.component.html',
  styleUrls: ['./my-form.component.css']
})
export class MyFormComponent implements OnInit {
// Объект реактивной формы
form: FormGroup;
entries: FormArray;
  constructor(private _formBuilder: FormBuilder, private http: HttpClient) {}
/**
   * Инициализация компонента
   */
  ngOnInit() {
    // Создать форму
    this.createForm();
  }

  /**
   * Создать объект реактивной формы
   * Пример работы с реактивной формой
   * здесь https://alligator.io/angular/reactive-forms-formarray-dynamic-fields/
   */
   
  /**
   *   createForm() {
    this.form = this._formBuilder.group({     
      autor_name: this._formBuilder.group({
        lastname: ['', [Validators.required, Validators.pattern(/^[A-z]*$/),
      Validators.minLength(2)]],
        firstname: ['', [Validators.required, Validators.pattern(/^[A-z]*$/)]],
        middlename: ['', [Validators.required, Validators.pattern(/^[A-z]*$/)]]
      }),
      book: this._formBuilder.group({
      book_name: ['', [Validators.required]],
      publication: ['', [Validators.required]],
      year_publication: ['', [Validators.required, Validators.pattern(/[0-9]/)]],
      })
      });
  }
   */
  createForm() {
    this.form = this._formBuilder.group({

      autor_name: this._formBuilder.group({
        lastname: ['', [Validators.required, Validators.pattern(/^[а-яА-ЯёЁa-zA-Z]+$/),
      Validators.minLength(2)]],
        firstname: ['', [Validators.required, Validators.pattern(/^[а-яА-ЯёЁa-zA-Z]+$/)]],
        middlename: ['', [Validators.required, Validators.pattern(/^[а-яА-ЯёЁa-zA-Z]+$/)]]
      }),
      autors: this._formBuilder.array([]),

      book: this._formBuilder.group({
      book_name: ['', [Validators.required]],
      publication: ['', [Validators.required]],
      year_publication: ['', [Validators.required, Validators.pattern(/[0-9]/)]],
      })
      });
  }

  get autors() : FormArray {
    return this.form.get("autors" ) as FormArray
  }

  newAutors(): FormGroup {
    return this._formBuilder.group({
      id:[''],
      lastname_i: ['', [Validators.required, Validators.pattern(/^[а-яА-ЯёЁa-zA-Z]+$/),
      Validators.minLength(2)]],
        firstname_i: ['', [Validators.required, Validators.pattern(/^[а-яА-ЯёЁa-zA-Z]+$/)]],
        middlename_i: ['', [Validators.required, Validators.pattern(/^[а-яА-ЯёЁa-zA-Z]+$/)]]
    });
  }
  addAutors(event) {         
    this.autors.push(this.newAutors());   
    
    
 }
 removeAutors(i:number) {
  this.autors.removeAt(i);
}

onSubmit() {
  console.log(this.form.value);
}
  
  isControlInvalid(controlName: string): boolean {
    const control = this.form.controls[controlName];
    const result = control.invalid && control.touched;
    return result;
  }

  sendToAPI() {
    const formObj = this.form.getRawValue();
    const serializedForm = JSON.stringify(formObj);

    this.http.post( '', serializedForm).subscribe(
      data => console.log('success!', data),
      error => console.log('couldn`t post because', error)
      );
  }

  submit() {
    const resource = JSON.stringify(this.form.value);
console.log('Добавлено:' + resource);
  }


}
