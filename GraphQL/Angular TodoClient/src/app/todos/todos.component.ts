import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Apollo, gql, Subscription } from 'apollo-angular';
import { Todo } from 'src/models/todo.model';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.scss']
})
export class TodosComponent {
  public model: Todo = new Todo();
  public todos: Todo[] = [];
  @ViewChild('form', { static: false }) form?: NgForm;

  constructor(private apollo: Apollo) {
    this.apollo.subscribe({
      query: gql`subscription todos {
        todos {
          id
          task
          createdOn
        }
      }`
    }).subscribe({
      next: (result: any) => {
        this.todos = [];
        this.todos.push(... result.data.todos);
      },
      error: (err) => {

      },
      complete: () => {

      }
    });

    this.apollo.query({
      query: gql`query getTodos{
        todos {
          id
          task
          createdOn
        }
      }`
    }).subscribe((observer: any) => {
      this.todos = observer.data.todos;
    });
  }

  onSubmit(submit: SubmitEvent) {
    this.apollo.mutate({
      mutation: gql`mutation saveTodo($todo:TodoInput!){
        save(inp:$todo) {
          id
          task
        }
      }`,
      variables: {
        todo: {
          id: this.model.id ?? 0,
          task: this.model.task
        }
      }
    }).subscribe(observer => {
      console.log(observer)
      console.log(observer.data)
      this.model = new Todo();
      this.form?.reset();
    })
  }

}
