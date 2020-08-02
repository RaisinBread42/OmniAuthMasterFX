# OmniAuthMasterFX
 IdentityServer4 Authentication MicroService Template

### Motivation
Wanted to understand more on Identity Server. And if I didn't save a template, pretty sure I would've forgotten all about this stuff :p 

### Capabilities
Allows for JWTBearer header token authorization and traditional cookie authentication.

### Testing Authentication
To use any authentication, ensure that you have a registered account. Can POST to the following endpoint with body payload to register.
https://localhost:44315/api/account/register
``` json
{
	"UserName":"yourusername",
	"Password":"password123.",
	"PhoneNumber":"+1234567",
	"Email":"email1@email.com",
	"FirstName":"fname",
	"LastName":"lname"
}
```
### Using Cookie Based Authentication
Using either your client application or a request tool like PostMan, make a POST request to signin https://localhost:44315/api/account/signin with the following params.
```json
{
	"username":"yourusername",
	"password":"password123.",
	"Email":"email1@email.com"
}
```
If sign in was successfull, then the response will contain the .AspNetCore.Cookies.
```json
.AspNetCore.Cookies=CfDJ8NGdAURLW21DhugE4qd7Y5gYLjBCynmDpLglL-9u7uWtqFoF-jY0V2609ZJpzsNE2g5pnQKEpIBNLohc_coiyxmm_CZ5lFTZTHFx5nf7zvl7ZFB84pgjOcpPkiUtBxrW0pwDRK_6dAYJXikv-PWtrETysGeTPkJS9dBQ_aUhVMBatji1Xb3RDs9itUR3wifuQT1LLLhRKnJHCrMF7pcXt21TSAu3OzSMFmitbJEuVuUFEzbqEkD2WGVBSZqutqrOCJA04_V1blGoyo3t8wQa760CN47AjnBxgyAETLbAZJeDk2z088dQIFNkQs-R8TeSBS0c7s7P5pSqIw8XVymwG1uZrm3NdhJoMjfii6SpOxZSjCWwTyOms5uk1unUY4SxJ_UXWt-4KAh91kc3ksEnlTpox7itAp4K7v31exkf5TvNQDVPV5Awp-aTbBRemmvmwahDayv6QQclRjqp3aDuJTPIYMscbs1pXVM1Fih-8UHC9LaIwJOn7WccDHJ1qWIduGLB26dAEfIptln9VEF_Ns1lgaG3yrBKcHNECKln4629esLMDn5dYVjKRm9VEO_f-w
```
In future requests, simply include that cookie and you will be considered authorized for methods with the `[Authorize(Policy = "Cookie")]` attribute. As a test you can make a plain GET request, with the cookie, to the test endpoint https://localhost:44315/api/account/testauth, and if successfull you will recieve the number 1 in the resposne body.

### Using JwtBearer Authentication
Using either your client application or a request tool like PostMan, make a POST request to the openID discovery document endpoint https://localhost:44315/connect/token with the following form-data body.
```json
Username:yourusername
Password:password123.
grant_type:password
scope:api1 openid
client_id:ro.react
client_secret:secret
```
In response you will get the access token
```json
{
    "access_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6IkV1NlFpcldVdWRHcHlEcDFqakd1WUEiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1OTYzMzEzNDEsImV4cCI6MTU5NjMzNDk0MSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMTUiLCJhdWQiOiJhcGkxIiwiY2xpZW50X2lkIjoicm8ucmVhY3QiLCJzdWIiOiJjODhjY2MyZC04MTk0LTQwZTAtOTQ3ZS1lNzQ5ZjE2NTI4YzIiLCJhdXRoX3RpbWUiOjE1OTYzMzEzNDEsImlkcCI6ImxvY2FsIiwic2NvcGUiOlsib3BlbmlkIiwiYXBpMSJdLCJhbXIiOlsicHdkIl19.mDQJUElTkc0IfY0y22gpzlK9ejjAawIwkQXITyumA2YRGgXKSlepGdf_RaWk7dmIEhaC4yiFN_wAzn6IqcUEOUEsWYnWqCWrHcNiR9gadEicg5yc0kkgOxjOiTlaM5WkDy-MvXhbXgl8UuMI1Wpl8KrECEzfigGHSV-X6yrulWMpgRzoN-X_LA8fyeUUCgKMLfOxNrYPHDmIkiUQo--kaNWbs2LZHT4bKaWYbgvhhVLWbLhVEggpTGtJCqMfkrHEzzu61nvRSzcijtRHG5D3I91CmHp3P-XcH8LN8CkLYJaESHqql6u4hNGg6Kgug3Iuq6AQN2hJlozMiMzbELDRFQ",
    "expires_in": 3600,
    "token_type": "Bearer",
    "scope": "api1 openid"
}
```

After simply include the token within future requests within the Authorization key in the request header. 
```json
...
Authorization: Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IkV1NlFpcldVdWRHcHlEcDFqakd1WUEiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1OTYzMzEzNDEsImV4cCI6MTU5NjMzNDk0MSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMTUiLCJhdWQiOiJhcGkxIiwiY2xpZW50X2lkIjoicm8ucmVhY3QiLCJzdWIiOiJjODhjY2MyZC04MTk0LTQwZTAtOTQ3ZS1lNzQ5ZjE2NTI4YzIiLCJhdXRoX3RpbWUiOjE1OTYzMzEzNDEsImlkcCI6ImxvY2FsIiwic2NvcGUiOlsib3BlbmlkIiwiYXBpMSJdLCJhbXIiOlsicHdkIl19.mDQJUElTkc0IfY0y22gpzlK9ejjAawIwkQXITyumA2YRGgXKSlepGdf_RaWk7dmIEhaC4yiFN_wAzn6IqcUEOUEsWYnWqCWrHcNiR9gadEicg5yc0kkgOxjOiTlaM5WkDy-MvXhbXgl8UuMI1Wpl8KrECEzfigGHSV-X6yrulWMpgRzoN-X_LA8fyeUUCgKMLfOxNrYPHDmIkiUQo--kaNWbs2LZHT4bKaWYbgvhhVLWbLhVEggpTGtJCqMfkrHEzzu61nvRSzcijtRHG5D3I91CmHp3P-XcH8LN8CkLYJaESHqql6u4hNGg6Kgug3Iuq6AQN2hJlozMiMzbELDRFQ
...
```
To confirm you successfully got a valid token, can make a GET request to the test controller method https://localhost:44315/api/account/testauth2. You will receive the number 1 if the request was considered authorized. I.E. a valid token was used.
