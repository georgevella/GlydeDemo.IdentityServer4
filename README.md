# GlydeDemo.IdentityServer4
Experiments with IdentityServer4

## Notes

- IdentityServer4 host is set up with in-memory clients and API resources.  Dumb implementation of Profile and ResourceOwnerValidators are set up for the time being.
- Auth against the `/connect/token` endpoint (more info here http://docs.identityserver.io/en/release/endpoints/token.html)
![alt Accessing Authenticated Resource](https://raw.githubusercontent.com/georgevella/GlydeDemo.IdentityServer4/master/docs/img/get_token.PNG)
- Pass access token to the endpoint needing authentication in the `sessionToken` header.  This overrides the default behaviour defined by the `IdentityServer4.AccessTokenValidation` package, which is to read the `Authorization` header.  Behaviour is overridden by setting a custom `TokenRetriever` method when invoking `UseIdentityServerAuthentication` in `Startup`.
![alt Accessing Authenticated Resource](https://raw.githubusercontent.com/georgevella/GlydeDemo.IdentityServer4/master/docs/img/access_authenticatedresource.PNG)