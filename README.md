# GlobalPoCTest

Architecture

This project has been based in a clean architecture. All dependencies flow inwards and our Core layer has not dependencies of any other layer.  
Presentation and Infrastructure layer depend on Core but not on one another. Except when these layer have a runtime-only dependency regarding with the dependencies container. 
The layers are:

- Core layers:
  
  - Domain layer:

    - Domain layer is based on DDD. I has the domain entities and should have the domain logic trying to avoid an anemic model. Also, it has domain events to notify inprocess events to another domain parts.
 
  - Application layer

    - Application layer has business logic and bussines dtos. Also it’s only have a dependency with domain layer. 
      In this project we are using some libraries like Automapper (for mapping the domain entities to application DTO), 
      FluentValidation (for validating the incoming values from the request) or Mediatr for handling the calls to our application services (this library implements a Mediator pattern) and also this library handle the common behaviors like logging or request validation using Mediatr pipelines (Chain of responsability design pattern). 
      
      When we are calling to our repository we are developing over the abstractions declared here and this abstractions will implemented 
      in the infrastructure layer to achieve the inversion dependency principle. We have inverted our dependencies 
      decoupling our application layer from the infrastructure layer.
      
      Also we have separated command and query concerns (CQRS Pattern).
 
 - External layers  
 
   - Infrastructure layer.
   
     In the infrastructure layer we will have the classes for accessing to the repositories. These classes will implement the abstractions declared in application layer.
     I'm using a memory repository. it has separated queries and commands. Also, it notifies all unpublished events to handler with Mediatr and it implements a repository pattern for CRUD operations. 
     We could use DAPPER ORM for queries and EF for commands. The Database could be for example an SQLLite DB and we arecould use a code first approach.
     
   - Presentation layer
   
     Regarding with the presentation layer We have an API Rest. I'm using Mediatr to make a call to our application’s services.
     
- Unit test layer (following AAA pattern) for unit testing purposes for each layer except Presentation Layer(API REST). For this layer, we can use WebApplicationFactory class to realize a end-to-end test. Joining with the HTTPClient class and implementing a xunit's interface (IClassFixture) we can make our integration unit tests.
    

Other considerations:

- In this development, I've tried to follow concerns regarding with clean code and i've tried to following some design principle like KISS (for example trying to make simple the api's controllers using MediatR library) and avoiding to repeat code in all layers (DRY principle). Also, I've followed SOLID principles trying to mantain one concern of change in my classes (single responsability), extends my classes with DI (open/close principle), trying to avoid having interfaces whose methods are not implemented (following the Liskov substitution's principle), trying to avoid having fat interfaces (implementing CQRS for example) to follow interface segregation's principle. At last, I'm using the dependency inversion principle to build a clean architecture as i said before. Also, this implementation let me develop over abstractions instead of concretions favoring the decoupling of the core layers over external layers.

- The DDD entities's creation are encapsulated, instead of using many parameters in the Create method, I could use a build pattern to avoid a telescopic parameters in the creation of the entity.

- In the presentation layer, i have no time to develope some methods regarding with funcionality like:
    -  Update an inventory (UPDATE HTTP VERB)
    -  Add a item to an existing inventory (POST HTTP VERB)
    -  Partial updatings (PATCH HTTP VERB)

- In the infraestructure layer i'm moking the event's tracking with a notification service in the absence of being able to do it with an ORM.
Tools and technologies used.

- The API'security should be a JWT token's security, following an identity roles for authorization or something like that.


Technologies:

  - Visual Studio 2022
  - .NET 6
  - C#
  - AutoMapper (third part nuget for mapping an object in another object).
  - MediatR (third party nuget thats implementing a mediator pattern for communicating each service of my application. Also it lets me implementing the publication of  my domain events) 
  - ASP.NET Core Web API
  - FluentAssertions (third party nuget to assert the result of mi unit tests)
  - FluentValidation (third party nuget to validate the request to my services)
  - Xunit (third party nuget to implement my unit test)
  - AutoFixture (third party nuget to generate fake data for my unit test)
  - Moq (third party nuget to mock functionality in my unit tests)
  - Swagger (third party nuget to facilitate end-to-end test and document my API following OpenAPI standard).
  - Serilog (Third nuget party to help me to trace my application)
  
  
