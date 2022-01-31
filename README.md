# SportzerMediaPro Api

## Design Decisions

It is assumed that that model structure of the product varies and there is possiblity to always add new product which will request some code modification

A generic decision was made to have `MetaData` field in the Order DTO so that any Partner can add as much as possible properties that is particular and unique to them.
## Project Structure
This project is structured in two folder on solution level. The first folder is `src` and it contains `SportzerMediaPro.Common`, `SportzerMediaPro.Contracts`, `SportzerMediaPro.Domain`, `SportzerMediaPro.Services`, `SportzerMediaPro.WebAPI`
> `SportzerMediaPro.WebAPI` references `SportzerMediaPro.Common`, `SportzerMediaPro.Contracts`, `SportzerMediaPro.Domain`, `SportzerMediaPro.Services`

```.
├── src
│   ├── SportzerMediaPro.Sln
│      ├── SportzerMediaPro.Common
│      ├── SportzerMediaPro.Contracts
│      ├── SportzerMediaPro.Domain
│      ├── SportzerMediaPro.Services
│      └── SportzerMediaPro.WebAPI
│    
├── tests
        ├── SportzerMediaPro.Tests
    
  

 ```
 
## Logging
 
NLog was used for logging operations. A generic LoggerService is created in `SportzerMediaPro.Common` so that its available for all other project to log it operations. It's gathering all logs from Microsoft logging extensions and store it in specific log file. You can also configure file path by using NLog.config file.

## Security

Basic authentication was implemented that required the client the add Authorization header to the request. It works like bearer token, but in this case, `ApiKey` from the Channel table is checked against the key gotten from the header. If `ApiKey` is not added to the request, you get Status Code 400 and if `ApiKey` does not match, you get Status Code 401. The Attribute is added on each Controller that needed to be authorized
Sample security token for test `spotzer_test_51JUu1MGNU5r3gGaDKd4aZKlcgy0IWF1px7EjZQlnNwfC9IRMy2uPQj3c0ZLhCLhyoHdhSFUXgewCXCN2nJeRWpro00W1qWBesM`

## Exception Handling
A global exception handler middleware was written to handle all error and was used in the request pipeline.

## Testing
xUnit was used for the unit testing and every services was tested

