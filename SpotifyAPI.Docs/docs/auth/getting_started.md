# Getting Started

## Auth-Methods

Before you can use the Web API full functional, you need the user to authenticate your Application.
If you want to know more, you can read to the whole auth-process [here](https://developer.spotify.com/web-api/authorization-guide/).

Before you start, install `SpotifyAPI.Web.Auth` and create an application at Spotify: [Your Applications](https://developer.spotify.com/my-applications/#!/applications)

After you created your Application, you will have following important values:
|Name|Description|
|--------------|-------------------------|-------------------------|
| **Client_Id** | This is your client_id, you don't have to hide it|
| **Client_Secret** | Never use this in one of your client-side apps! Keep it secret! |
| **Redirect URIs** | Some of auth flows require that you set the correct redirect URI |

Now you can start with the user-authentication, Spotify provides 3 ways (4 if you consider different implementations):

* [ImplicitGrantAuth](/auth/implicit_grant.md)

* [TokenSwapAuth](/auth/token_swap.md) (**Recommended**, server-side code mandatory, most secure method. The necessary code is shown here so you do not have to code it yourself.)

* [AutorizationCodeAuth](/auth/autorization_code.md) (Not recommended, server-side code needed, else it's unsecure)

* [ClientCredentialsAuth](/auth/client_credentials_auth.md) (Not recommended, server-side code needed, else it's unsecure)

Overview:
![Overview](http://i.imgur.com/uf3ahTl.png)
