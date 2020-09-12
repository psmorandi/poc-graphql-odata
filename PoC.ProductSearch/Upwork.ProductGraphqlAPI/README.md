Links:
- https://graphql.org/code/#c-net
- https://hotchocolate.io/
- https://graphql-dotnet.github.io/docs/getting-started/introduction
- https://github.com/SimonCropp/GraphQL.EntityFramework

Schema:

type Product {
    id: String!
    name: String!    
    description: String!
    color: Color!
    category: Category!
}

type Category {
    name: String!
    code: Int!
}

type Color {
    name: String!
    code: Int!
}

type Query {
    product(id: String!): Product
}