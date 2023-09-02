import { gql } from 'apollo-angular';
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
  message?: Maybe<Message>;
  type: EventType;
};

export enum EventType {
  ClearMessages = 'CLEAR_MESSAGES',
  DeleteMessage = 'DELETE_MESSAGE',
  NewMessage = 'NEW_MESSAGE'
}

export type Message = {
  __typename?: 'Message';
  from: Scalars['String']['output'];
  id: Scalars['ID']['output'];
  message: Scalars['String']['output'];
  sent: Scalars['DateTime']['output'];
};

export type MessageInput = {
  from: Scalars['String']['input'];
  message: Scalars['String']['input'];
};

export type Mutation = {
  __typename?: 'Mutation';
  addMessage: Message;
  clearMessages: Scalars['Int']['output'];
  deleteMessage?: Maybe<Message>;
};


export type MutationAddMessageArgs = {
  message: MessageInput;
};


export type MutationDeleteMessageArgs = {
  id: Scalars['ID']['input'];
};

export type Query = {
  __typename?: 'Query';
  allMessages: Array<Message>;
  count: Scalars['Int']['output'];
  lastMessage?: Maybe<Message>;
};


export type QueryAllMessagesArgs = {
  from?: InputMaybe<Scalars['String']['input']>;
};

export type Subscription = {
  __typename?: 'Subscription';
  events: Event;
  newMessages: Message;
};


export type SubscriptionNewMessagesArgs = {
  from?: InputMaybe<Scalars['String']['input']>;
};
