import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  imports: [HttpClient],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
  standalone: true
})
export class Dashboard implements OnInit{
  tasks: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get('https://localhost:44389/api/tasks')
      .subscribe((data: any) => this.tasks = data);
  }

}
