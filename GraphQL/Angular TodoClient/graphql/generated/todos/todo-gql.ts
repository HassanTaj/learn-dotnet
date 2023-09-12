import { gql } from 'apollo-angular';
import { Injectable } from '@angular/core';
import * as Apollo from 'apollo-angular';
export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
export type MakeEmpty<T extends { [key: string]: unknown }, K extends keyof T> = { [_ in K]?: never };
export type Incremental<T> = T | { [P in keyof T]?: P extends ' $fragmentName' | '__typename' ? T[P] : never };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: { input: string; output: string; }
  String: { input: string; output: string; }
  Boolean: { input: boolean; output: boolean; }
  Int: { input: number; output: number; }
  Float: { input: number; output: number; }
  /** The `DateTime` scalar type represents a date and time. `DateTime` expects timestamps to be formatted in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard. */
  DateTime: { input: any; output: any; }
};

export type Event = {
  __typename?: 'Event';
  items: Array<Maybe<Todo>>;
  type: EventTypes;
};

export enum EventTypes {
  Create = 'CREATE',
  Delete = 'DELETE',
  Read = 'READ',
  RemoveAll = 'REMOVE_ALL',
  Update = 'UPDATE'
}

export type Mutation = {
  __typename?: 'Mutation';
  remove?: Maybe<Todo>;
  removeAll?: Maybe<Scalars['Boolean']['output']>;
  save: Todo;
};


export type MutationRemoveArgs = {
  id: Scalars['ID']['input'];
};


export type MutationSaveArgs = {
  inp: TodoInput;
};

export type Query = {
  __typename?: 'Query';
  todo?: Maybe<Todo>;
  todos: Array<Todo>;
};


export type QueryTodoArgs = {
  id: Scalars['ID']['input'];
};

export type Subscription = {
  __typename?: 'Subscription';
  events: Event;
  getAll: Array<Todo>;
  todos: Array<Todo>;
};

export type Todo = {
  __typename?: 'Todo';
  createdOn: Scalars['DateTime']['output'];
  id: Scalars['Int']['output'];
  task?: Maybe<Scalars['String']['output']>;
};

export type TodoInput = {
  id?: InputMaybe<Scalars['Int']['input']>;
  task?: InputMaybe<Scalars['String']['input']>;
};

export type TodosSubscriptionVariables = Exact<{ [key: string]: never; }>;


export type TodosSubscription = { __typename?: 'Subscription', todos: Array<{ __typename?: 'Todo', id: number, task?: string | null, createdOn: any }> };

export type GetTodosQueryVariables = Exact<{ [key: string]: never; }>;


export type GetTodosQuery = { __typename?: 'Query', todos: Array<{ __typename?: 'Todo', id: number, task?: string | null, createdOn: any }> };

export type SaveTodoMutationVariables = Exact<{
  todo: TodoInput;
}>;


export type SaveTodoMutation = { __typename?: 'Mutation', save: { __typename?: 'Todo', id: number, task?: string | null } };

export const TodosDocument = gql`
    subscription todos {
  todos {
    id
    task
    createdOn
  }
}
    `;

  @Injectable({
    providedIn: 'root'
  })
  export class TodosGQL extends Apollo.Subscription<TodosSubscription, TodosSubscriptionVariables> {
    document = TodosDocument;
    
    constructor(apollo: Apollo.Apollo) {
      super(apollo);
    }
  }
export const GetTodosDocument = gql`
    query getTodos {
  todos {
    id
    task
    createdOn
  }
}
    `;

  @Injectable({
    providedIn: 'root'
  })
  export class GetTodosGQL extends Apollo.Query<GetTodosQuery, GetTodosQueryVariables> {
    document = GetTodosDocument;
    
    constructor(apollo: Apollo.Apollo) {
      super(apollo);
    }
  }
export const SaveTodoDocument = gql`
    mutation saveTodo($todo: TodoInput!) {
  save(inp: $todo) {
    id
    task
  }
}
    `;

  @Injectable({
    providedIn: 'root'
  })
  export class SaveTodoGQL extends Apollo.Mutation<SaveTodoMutation, SaveTodoMutationVariables> {
    document = SaveTodoDocument;
    
    constructor(apollo: Apollo.Apollo) {
      super(apollo);
    }
  }