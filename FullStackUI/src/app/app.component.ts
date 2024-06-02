import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { employee } from '../models/employeeModels';
import { AsyncPipe, CommonModule } from '@angular/common';
import { FormGroup, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, AsyncPipe, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FullStackUI';

  http = inject(HttpClient);

  // add new emp
  employeeForm = new FormGroup({
    name: new FormControl<string>(''),
    email: new FormControl<string | null>(null),
    phone: new FormControl<number | null>(null),
    age: new FormControl<number | null>(null),
    salary: new FormControl<number | null>(null),
    department: new FormControl<string>(''),
  });

  Employee$ = this.getEmployee();
  onDelete(id: string): void {
    this.http.delete(`https://localhost:7048/api/Employees/${id}`)
      .subscribe({
        next: (value) => {
          alert('Item Deleted');
          this.Employee$ = this.getEmployee(); // Ensure to use 'this' to access component properties
        }
      });
  }


  onFormSubmit(){
    // console.log(this.employeeForm.value);
    const addEmployeeRequest = {
      name: this.employeeForm.value.name,
      email: this.employeeForm.value.email,
      phone: this.employeeForm.value.phone,
      age: this.employeeForm.value.age,
      salary: this.employeeForm.value.salary,
      department: this.employeeForm.value.department
    }

    this.http.post('https://localhost:7048/api/Employees',addEmployeeRequest).subscribe({
      next: (value) => {
        console.log(value);
        // table refresh
        this.Employee$ = this.getEmployee();
        // reset form
        this.employeeForm.reset();
      }
    })

  }

  private getEmployee(): Observable<employee[]> {
    return this.http.get<employee[]>('https://localhost:7048/api/Employees');
  }
}
