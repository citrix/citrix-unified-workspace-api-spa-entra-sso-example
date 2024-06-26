# Citrix Unified Workspace API - Token Management Service sample backend built with .Net Core

This is a backend service implementation for an Single Page Application (SPA) / Native / Mobile client application that handles tokens.

The TMS primary responsibility is to store the Client ID and Client Secret so that the user cannot access it. The service will perform the role of client in the OIDC Authorization flow and stores the Refresh tokens and Access tokens for the user in encrypted cookies.

This is purely an example and shouldn't be used for real production services.

## Prerequisites

- You have either a Private or Public Workspace OAuth Client
- You will be running the example code in Visual Studio and can run [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

## Getting Started

### Configuration

#### Workspace OAuth Client Settings

To configure the Workspace OAuth Client settings including secrets use the dotnet user secrets feature. See https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows.

Example:

```json
{
  "Client": {
    "ClientId": "clientId==",
    "ClientSecret": null,
    "ApplicationId": null,
    "CallbackPath": "/callback",
    "UsePkce": true,
    "UseOfflineAccess": true
  }
}
```

- [Required] `ClientId`: The Public or Private client ID returned during client creation.
- [Required] `ApplicationId`: The application ID shown during client creation.
- [Optional] `ClientSecret`: Only provide this for Private Clients, should have been returned during creation.
- [Optional] `CallbackPath`: Set to `/callback` by default, this is used to formulate the 'redirect url' that is required to be set on the client, e.g. the host for this application is `https://localhost:7182` and therefore the allowed redirect URL set on the client must be `https://localhost:7182/callback`.
- [Optional] `UsePkce`: Set to `true` by default, this must match what you set during client creation.
- [Optional] `UseOfflineAccess`: Set to `true` by default, this must match what you set during client creation.

## Running the example

This example is a backend, and therefore runs in the background awaiting client calls.

### General flow for implementing client

- Client application is loaded

- Client application makes a call to `Session/CheckSession` endpoint to determine if a session exists. This will also provide the antiforgery token which will be used to prevent CSRF.

- If the session is not logged in, the client application will direct a browser to `Auth/Domains/{customerDomain}/BeginLogin` to begin the login flow. Once the flow is complete and the user is authenticated it will redirect back to the client application's associated redirect url.

- Client application makes a call to `Session/RetrieveAccessToken` to retrieve the access token, with an antiforgery token in the header. This token will allow the application to call the Citrix API. The token will be short-lived and should only be stored in secure memory, and not stored in browser storage.

- Client application then uses the access token to call the Citrix Workspace API.

- Once a token has expired or is close to expiration, the application can call `Session/RetrieveAccessToken` to refresh the token.

- When the Client application performs a logout, it makes a call to `Auth/LogOut` to invalidate auth cookies.  

## License

Copyright © 2024. Cloud Software Group, Inc. All Rights Reserved.
