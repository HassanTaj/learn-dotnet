export class Todo {
  public id?: number;
  public task?: string
  public createdOn?: Date;
}


export interface TodoInput {
  id: number
  task: string
}
