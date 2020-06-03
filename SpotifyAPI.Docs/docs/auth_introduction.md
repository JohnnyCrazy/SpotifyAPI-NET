---
id: auth_introduction
title: Introduction
---

Spotify does not allow unauthorized access to the api. Thus, you need an access token to make requets. This access token can be gathered via multiple schemes, all following the OAuth2 spec. Since it's important to choose the correct scheme for your usecase, make sure you have a grasp of the following terminology/docs:

* OAuth2
* [Spotify Authorization Flows](https://developer.spotify.com/documentation/general/guides/authorization-guide/#authorization-code-flow)

Since every auth flow also needs an application in the [spotify dashboard](https://developer.spotify.com/dashboard/), make sure you have the necessary values (like `Client Id` and `Client Secret`).

Then, continue with the docs of the specific auth flows:

* [Client Credentials](client_credentials)
* [Implicit Grant](implicit_grant)
* [Authorization Code](authorization_code)
* Token Swap

![auth comparison](/img/auth_comparison.png)
