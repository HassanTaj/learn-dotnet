
import type { CodegenConfig } from '@graphql-codegen/cli';

const config: CodegenConfig = {
  generates: {

    "./graphql/generated/cats/cats-scheme.json": {
      overwrite: true,
      // documents: "src/**/*.ts",
      schema: "http://localhost:13034/cats/graphql",
      plugins: ["introspection"]
    },
    "./graphql/generated/todos/todo-gql.ts": {
      overwrite: true,
      documents: "src/**/*.ts",
      schema: "http://localhost:13034/todos/graphql",
      plugins: ['typescript', 'typescript-operations', 'typescript-apollo-angular']
    },
    "./graphql/generated/cats/cats-gql.ts": {
      overwrite: true,
      // documents: "**/*.{gql,graphql}",
      schema: "http://localhost:13034/cats/graphql",
      plugins: ['typescript', 'typescript-operations', 'typescript-apollo-angular']
    },
    "./graphql/generated/chat/chat-gql.ts": {
      overwrite: true,
      // documents: "**/*.{gql,graphql}",
      schema: "http://localhost:13034/chat/graphql",
      plugins: ['typescript', 'typescript-operations', 'typescript-apollo-angular']
    },
  }


};

export default config;
