# DotNETCore_DuendeIdentityServer

This project uses Duende IdentityServer for OIDC authentication and OAuth 2.0.

The solution consists of a web application and a console application:

Web Application: Run the command https://localhost:7235/.well-known/openid-configuration in your browser or API testing tool. This endpoint provides the OpenID Connect discovery document, which includes details for requesting or generating tokens.

Console Application: Contains the code for requesting tokens from the IdentityServer.
