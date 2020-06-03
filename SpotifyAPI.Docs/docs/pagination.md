---
id: pagination
title: Pagination
---

When working with spotify responses, you will often encounter the `Paging<T>` type.

> The offset-based paging object is a container for a set of objects. It contains a key called items (whose value is an array of the requested objects) along with other keys like previous, next and limit that can be useful in future calls.

It allows to receive only a subset of all available data and dynamically check if more requests are required. The library supports `Paging<T>` responses in two ways:

## PaginateAll

`PaginateAll` will query all remaining elements based on a first page and return all of them in a `IList`. This method should not be used for a huge amount of pages (e.g `Search` Endpoint), since it stores every response in memory.

```csharp
// we need the first page, every syntax can be used for pagination
var page = await spotify.Playlists.CurrentUsers();
var page = spotify.Playlists.CurrentUsers();
var page = () => spotify.Playlists.CurrentUsers();

// allPages will include the first page retrived before
var allPages = await spotify.PaginateAll(page);
```

## Paginate

:::info .NET Standard >= 2.1 required
:::

`Paginate` is based on `IAsyncEnumerable` and streams pages instead of returning them all in one list. This allows to break the fetching early and keeps only 1 page in memory at a time. This method should always be preferred to `PaginateAll`

```csharp
// we need the first page, every syntax can be used for pagination
var page = await spotify.Playlists.CurrentUsers();
var page = spotify.Playlists.CurrentUsers();
var page = () => spotify.Playlists.CurrentUsers();

await foreach(var item in spotify.Paginate(page))
{
  Console.WriteLine(item.Name);
  // you can use "break" here!
}
```

Some endpoints have nested and/or multiple paginations objects. When requesting the next page, it will not return the actual paging object but rather the root level endpoint object. A good example is the `Search` endpoint, which contains up to 5 Paging objects. Requesting the next page of the nested `Artists` paging object will return another `Search` response, instead of just `Artists`. You will need to supply a mapper function to the `Paginate` call, which returns the correct paging object:

```csharp
var search = await spotify.Search.Item(new SearchRequest(
  SearchRequest.Types.All, "Jake"
));

await foreach(var item in spotify.Paginate(search.Albums, (s) => s.Albums))
{
  Console.WriteLine(item.Name);
  // you can use "break" here!
}
```

## Paginators

Via the interface [`IPaginator`](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/Interfaces/IPaginator.cs), it can be configured how pages are fetched. It can be configured on a global level:

```csharp
var config = SpotifyClientConfig
  .CreateDefault()
  .WithPaginator(new YourCustomPaginator());
```

or on method level:

```csharp
await foreach(var item in spotify.Paginate(page, new YourCustomPaginator()))
{
  Console.WriteLine(item.Name);
  // you can use "break" here!
}
```

By default, [`SimplePaginator`](https://github.com/JohnnyCrazy/SpotifyAPI-NET/blob/master/SpotifyAPI.Web/Clients/SimplePaginator.cs) is used. It fetches pages without any delay.
