##GetFeaturedPlaylists
<span class="label label-warning">AUTH REQUIRED</span>
> Get a list of Spotify featured playlists (shown, for example, on a Spotify player’s “Browse” tab).

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[locale]| The desired language, consisting of a lowercase ISO 639 language code and an uppercase ISO 3166-1 alpha-2 country code, joined by an underscore. | `"de_DE" //Germany`
|[country]| A country: an ISO 3166-1 alpha-2 country code. | `"DE"`
|[timestamp]| A timestamp in ISO 8601 format | `DateTime.Now`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first item to return. Default: 0 | `0`

Returns a **FeaturedPlaylists** object, which has 2 properties. `String Message` and `Paging<SimplePlaylist> Playlists`

**Usage**  
```cs
FeaturedPlaylists playlists = _spotify.GetFeaturedPlaylists();
Console.WriteLine(playlists.Message);
playlists.Playlists.Items.ForEach(playlist => Console.WriteLine(playlist.Name));
```

---
##GetNewAlbumReleases
<span class="label label-warning">AUTH REQUIRED</span>
> Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[country]| A country: an ISO 3166-1 alpha-2 country code. | `"DE"`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first item to return. Default: 0 | `0`

Returns a **NewAlbumReleases** object, which has the property `Paging<SimpleAlbum> Albums`.

**Usage**  
```cs
NewAlbumReleases newAlbums = _spotify.GetNewAlbumReleases();
newAlbums.Albums.Items.ForEach(album => Console.WriteLine(album.Name));
```

---
##GetCategories
<span class="label label-warning">AUTH REQUIRED</span>
> Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|[country]| A country: an ISO 3166-1 alpha-2 country code. Provide this parameter if you want to narrow the list of returned categories to those relevant to a particular country | `"DE"`
|[locale]| The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore | `"de_DE"`
|[limit]| The maximum number of categories to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first item to return. Default: 0 (the first object). | `0`

Returns a **CategoryList** object, which has the property `Paging<Category> Categories`.

**Usage**  
```cs
CategoryList categoryList = _spotify.GetCategories();
categoryList.Categories.Items.ForEach(category => Console.WriteLine(category.Name));
```

---
##GetCategory
<span class="label label-warning">AUTH REQUIRED</span>
> Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|categoryId| The Spotify category ID for the category. | `"party"`
|[country]| A country: an ISO 3166-1 alpha-2 country code. Provide this parameter to ensure that the category exists for a particular country. | `"DE"`
|[locale]| The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country code, joined by an underscore | `"de_DE"`

Returns a [Category](https://developer.spotify.com/web-api/object-model/#category-object)

**Usage**  
```cs
Category cat = _spotify.GetCategory("party");
Console.WriteLine(cat.Name);
```

---
##GetCategoryPlaylists
<span class="label label-warning">AUTH REQUIRED</span>
> Get a list of Spotify playlists tagged with a particular category.

**Paramters**  

|Name|Description|Example|
|--------------|-------------------------|-------------------------|
|categoryId| The Spotify category ID for the category. | `"party"`
|[country]| A country: an ISO 3166-1 alpha-2 country code. | `"DE"`
|[limit]| The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. | `20`
|[offset]| The index of the first item to return. Default: 0 | `0`

Returns a **CategoryPlaylist** object, which has the property `Paging<SimplePlaylist> Playlists`

**Usage**  
```cs
CategoryPlaylist playlists = _spotify.GetCategoryPlaylists("party");
playlists.Playlists.Items.ForEach(playlist => Console.WriteLine(playlist.Name));
```

---
