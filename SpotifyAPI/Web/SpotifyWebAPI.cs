using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
    public sealed class SpotifyWebAPI : IDisposable
    {
        [Obsolete("This Property will be removed soon. Please use SpotifyWebBuilder.APIBase")]
        public const String APIBase = SpotifyWebBuilder.APIBase;

        private readonly SpotifyWebBuilder _builder;

        public SpotifyWebAPI()
        {
            _builder = new SpotifyWebBuilder();
            UseAuth = true;
            WebClient = new SpotifyWebClient
            {
                JsonSettings =
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        TypeNameHandling = TypeNameHandling.All
                    }
            };
        }

        public String TokenType { get; set; }
        public String AccessToken { get; set; }
        public Boolean UseAuth { get; set; }
        public IClient WebClient { get; set; }

        public void Dispose()
        {
            WebClient.Dispose();
            GC.SuppressFinalize(this); //TODO
        }

        #region Search

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code or the string from_token.</param>
        /// <returns></returns>
        public SearchItem SearchItems(String q, SearchType type, int limit = 20, int offset = 0, String market = "")
        {
            return DownloadData<SearchItem>(_builder.SearchItems(q, type, limit, offset, market));
        }

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string asynchronously.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first result to return. Default: 0</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code or the string from_token.</param>
        /// <returns></returns>
        public Task<SearchItem> SearchItemsAsync(String q, SearchType type, int limit = 20, int offset = 0, String market = "")
        {
            return DownloadDataAsync<SearchItem>(_builder.SearchItems(q, type, limit, offset, market));
        }

        #endregion Search

        #region Albums

        /// <summary>
        ///     Get Spotify catalog information about an album’s tracks. Optional parameters can be used to limit the number of
        ///     tracks returned.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first track to return. Default: 0 (the first object).</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public Paging<SimpleTrack> GetAlbumTracks(String id, int limit = 20, int offset = 0, String market = "")
        {
            return DownloadData<Paging<SimpleTrack>>(_builder.SearchItems(id, limit, offset, market));
        }

        /// <summary>
        ///     Get Spotify catalog information about an album’s tracks asynchronously. Optional parameters can be used to limit the number of
        ///     tracks returned.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first track to return. Default: 0 (the first object).</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public Task<Paging<SimpleTrack>> GetAlbumTracksAsync(String id, int limit = 20, int offset = 0, String market = "")
        {
            return DownloadDataAsync<Paging<SimpleTrack>>(_builder.SearchItems(id, limit, offset, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public FullAlbum GetAlbum(String id, String market = "")
        {
            if (String.IsNullOrEmpty(market))
                return DownloadData<FullAlbum>(_builder.SearchItems(id));
            return DownloadData<FullAlbum>(_builder.SearchItems(id, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single album asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public Task<FullAlbum> GetAlbumAsync(String id, String market = "")
        {
            if (String.IsNullOrEmpty(market))
                return DownloadDataAsync<FullAlbum>(_builder.SearchItems(id));
            return DownloadDataAsync<FullAlbum>(_builder.SearchItems(id, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public SeveralAlbums GetSeveralAlbums(List<String> ids, String market = "")
        {
            if (String.IsNullOrEmpty(market))
                return DownloadData<SeveralAlbums>(_builder.SearchItems(ids));
            return DownloadData<SeveralAlbums>(_builder.SearchItems(ids, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for multiple albums identified by their Spotify IDs asynchrously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public Task<SeveralAlbums> GetSeveralAlbumsAsync(List<String> ids, String market = "")
        {
            if (String.IsNullOrEmpty(market))
                return DownloadDataAsync<SeveralAlbums>(_builder.SearchItems(ids));
            return DownloadDataAsync<SeveralAlbums>(_builder.SearchItems(ids, market));
        }

        #endregion Albums

        #region Artists

        /// <summary>
        ///     Get Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public FullArtist GetArtist(String id)
        {
            return DownloadData<FullArtist>(_builder.SearchItems(id));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single artist identified by their unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public Task<FullArtist> GetArtistAsync(String id)
        {
            return DownloadDataAsync<FullArtist>(_builder.SearchItems(id));
        }

        /// <summary>
        ///     Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the
        ///     Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public SeveralArtists GetRelatedArtists(String id)
        {
            return DownloadData<SeveralArtists>(_builder.SearchItems(id));
        }

        /// <summary>
        ///     Get Spotify catalog information about artists similar to a given artist asynchronously. Similarity is based on analysis of the
        ///     Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public Task<SeveralArtists> GetRelatedArtistsAsync(String id)
        {
            return DownloadDataAsync<SeveralArtists>(_builder.SearchItems(id));
        }

        /// <summary>
        ///     Get Spotify catalog information about an artist’s top tracks by country.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code.</param>
        /// <returns></returns>
        public SeveralTracks GetArtistsTopTracks(String id, String country)
        {
            return DownloadData<SeveralTracks>(_builder.SearchItems(id, country));
        }

        /// <summary>
        ///     Get Spotify catalog information about an artist’s top tracks by country asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code.</param>
        /// <returns></returns>
        public Task<SeveralTracks> GetArtistsTopTracksAsync(String id, String country)
        {
            return DownloadDataAsync<SeveralTracks>(_builder.SearchItems(id, country));
        }

        /// <summary>
        ///     Get Spotify catalog information about an artist’s albums. Optional parameters can be specified in the query string
        ///     to filter and sort the response.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="type">
        ///     A list of keywords that will be used to filter the response. If not supplied, all album types will
        ///     be returned
        /// </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first album to return. Default: 0</param>
        /// <param name="market">
        ///     An ISO 3166-1 alpha-2 country code. Supply this parameter to limit the response to one particular
        ///     geographical market
        /// </param>
        /// <returns></returns>
        public Paging<SimpleAlbum> GetArtistsAlbums(String id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, String market = "")
        {
            return DownloadData<Paging<SimpleAlbum>>(_builder.SearchItems(id, type, limit, offset, market));
        }

        /// <summary>
        ///     Get Spotify catalog information about an artist’s albums asynchronously. Optional parameters can be specified in the query string
        ///     to filter and sort the response.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="type">
        ///     A list of keywords that will be used to filter the response. If not supplied, all album types will
        ///     be returned
        /// </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first album to return. Default: 0</param>
        /// <param name="market">
        ///     An ISO 3166-1 alpha-2 country code. Supply this parameter to limit the response to one particular
        ///     geographical market
        /// </param>
        /// <returns></returns>
        public Task<Paging<SimpleAlbum>> GetArtistsAlbumsAsync(String id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, String market = "")
        {
            return DownloadDataAsync<Paging<SimpleAlbum>>(_builder.SearchItems(id, type, limit, offset, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns></returns>
        public SeveralArtists GetSeveralArtists(List<String> ids)
        {
            return DownloadData<SeveralArtists>(_builder.SearchItems(ids));
        }

        /// <summary>
        ///     Get Spotify catalog information for several artists based on their Spotify IDs asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns></returns>
        public Task<SeveralArtists> GetSeveralArtistsAsync(List<String> ids)
        {
            return DownloadDataAsync<SeveralArtists>(_builder.SearchItems(ids));
        }

        #endregion Artists

        #region Browse

        /// <summary>
        ///     Get a list of Spotify featured playlists (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="locale">
        ///     The desired language, consisting of a lowercase ISO 639 language code and an uppercase ISO 3166-1
        ///     alpha-2 country code, joined by an underscore.
        /// </param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="timestamp">A timestamp in ISO 8601 format</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <remarks>AUTH NEEDED</remarks>
        public FeaturedPlaylists GetFeaturedPlaylists(String locale = "", String country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFeaturedPlaylists");
            return DownloadData<FeaturedPlaylists>(_builder.SearchItems(locale, country, timestamp, limit, offset));
        }

        /// <summary>
        ///     Get a list of Spotify featured playlists asynchronously (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="locale">
        ///     The desired language, consisting of a lowercase ISO 639 language code and an uppercase ISO 3166-1
        ///     alpha-2 country code, joined by an underscore.
        /// </param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="timestamp">A timestamp in ISO 8601 format</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<FeaturedPlaylists> GetFeaturedPlaylistsAsync(String locale = "", String country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFeaturedPlaylists");
            return DownloadDataAsync<FeaturedPlaylists>(_builder.SearchItems(locale, country, timestamp, limit, offset));
        }

        /// <summary>
        ///     Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public NewAlbumReleases GetNewAlbumReleases(String country = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetNewAlbumReleases");
            return DownloadData<NewAlbumReleases>(_builder.SearchItems(country, limit, offset));
        }

        /// <summary>
        ///     Get a list of new album releases featured in Spotify asynchronously (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<NewAlbumReleases> GetNewAlbumReleasesAsync(String country = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetNewAlbumReleases");
            return DownloadDataAsync<NewAlbumReleases>(_builder.SearchItems(country, limit, offset));
        }

        /// <summary>
        ///     Get a list of categories used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter if you want to narrow the
        ///     list of returned categories to those relevant to a particular country
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <param name="limit">The maximum number of categories to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first item to return. Default: 0 (the first object).</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public CategoryList GetCategories(String country = "", String locale = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetCategories");
            return DownloadData<CategoryList>(_builder.SearchItems(country, locale, limit, offset));
        }

        /// <summary>
        ///     Get a list of categories used to tag items in Spotify asynchronously (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter if you want to narrow the
        ///     list of returned categories to those relevant to a particular country
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <param name="limit">The maximum number of categories to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first item to return. Default: 0 (the first object).</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<CategoryList> GetCategoriesAsync(String country = "", String locale = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetCategories");
            return DownloadDataAsync<CategoryList>(_builder.SearchItems(country, locale, limit, offset));
        }

        /// <summary>
        ///     Get a single category used to tag items in Spotify (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter to ensure that the category
        ///     exists for a particular country.
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Category GetCategory(String categoryId, String country = "", String locale = "")
        {
            return DownloadData<Category>(_builder.SearchItems(categoryId, country, locale));
        }

        /// <summary>
        ///     Get a single category used to tag items in Spotify asynchronously (on, for example, the Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">
        ///     A country: an ISO 3166-1 alpha-2 country code. Provide this parameter to ensure that the category
        ///     exists for a particular country.
        /// </param>
        /// <param name="locale">
        ///     The desired language, consisting of an ISO 639 language code and an ISO 3166-1 alpha-2 country
        ///     code, joined by an underscore
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<Category> GetCategoryAsync(String categoryId, String country = "", String locale = "")
        {
            return DownloadDataAsync<Category>(_builder.SearchItems(categoryId, country, locale));
        }

        /// <summary>
        ///     Get a list of Spotify playlists tagged with a particular category.
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public CategoryPlaylist GetCategoryPlaylists(String categoryId, String country = "", int limit = 20, int offset = 0)
        {
            return DownloadData<CategoryPlaylist>(_builder.SearchItems(categoryId, country, limit, offset));
        }

        /// <summary>
        ///     Get a list of Spotify playlists tagged with a particular category asynchronously.
        /// </summary>
        /// <param name="categoryId">The Spotify category ID for the category.</param>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<CategoryPlaylist> GetCategoryPlaylistsAsync(String categoryId, String country = "", int limit = 20, int offset = 0)
        {
            return DownloadDataAsync<CategoryPlaylist>(_builder.SearchItems(categoryId, country, limit, offset));
        }

        #endregion Browse

        #region Follow

        /// <summary>
        ///     Get the current user’s followed artists.
        /// </summary>
        /// <param name="followType">The ID type: currently only artist is supported. </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">The last artist ID retrieved from the previous request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public FollowedArtists GetFollowedArtists(FollowType followType, int limit = 20, String after = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFollowedArtists");
            return DownloadData<FollowedArtists>(_builder.SearchItems(followType, limit, after));
        }

        /// <summary>
        ///     Get the current user’s followed artists asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: currently only artist is supported. </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">The last artist ID retrieved from the previous request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<FollowedArtists> GetFollowedArtistsAsync(FollowType followType, int limit = 20, String after = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFollowedArtists");
            return DownloadDataAsync<FollowedArtists>(_builder.SearchItems(followType, limit, after));
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Follow(FollowType followType, List<String> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return UploadData<ErrorResponse>(_builder.SearchItems(followType, ids), ob.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> FollowAsync(FollowType followType, List<String> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return
                UploadDataAsync<ErrorResponse>(_builder.SearchItems(followType, ids),
                    ob.ToString(Formatting.None), "PUT") ?? Task.FromResult(new ErrorResponse());
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Follow(FollowType followType, String id)
        {
            return Follow(followType, new List<string> { id });
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> FollowAsync(FollowType followType, String id)
        {
            return FollowAsync(followType, new List<string> { id });
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Unfollow(FollowType followType, List<String> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return UploadData<ErrorResponse>(_builder.SearchItems(followType, ids), ob.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> UnfollowAsync(FollowType followType, List<String> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return UploadDataAsync<ErrorResponse>(_builder.SearchItems(followType, ids), ob.ToString(Formatting.None), "DELETE") ?? Task.FromResult(new ErrorResponse());
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Unfollow(FollowType followType, String id)
        {
            return Unfollow(followType, new List<string> { id });
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> UnfollowAsync(FollowType followType, String id)
        {
            return UnfollowAsync(followType, new List<string> { id });
        }

        /// <summary>
        ///     Check to see if the current user is following one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs to check</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowing(FollowType followType, List<String> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowing");
            JToken res = DownloadData<JToken>(_builder.SearchItems(followType, ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        /// <summary>
        ///     Check to see if the current user is following one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs to check</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ListResponse<Boolean>> IsFollowingAsync(FollowType followType, List<String> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowing");
            JToken res = DownloadDataAsync<JToken>(_builder.SearchItems(followType, ids));
            if (res is JArray) //todo expression is always false
                return Task.FromResult(new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null });
            return Task.FromResult(new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() });
        }

        /// <summary>
        ///     Check to see if the current user is following one artist or another Spotify user.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowing(FollowType followType, String id)
        {
            return IsFollowing(followType, new List<string> { id });
        }

        /// <summary>
        ///     Check to see if the current user is following one artist or another Spotify user asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ListResponse<Boolean>> IsFollowingAsync(FollowType followType, String id)
        {
            return IsFollowingAsync(followType, new List<string> { id });
        }

        /// <summary>
        ///     Add the current user as a follower of a playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">
        ///     The Spotify ID of the playlist. Any playlist can be followed, regardless of its public/private
        ///     status, as long as you know its playlist ID.
        /// </param>
        /// <param name="showPublic">
        ///     If true the playlist will be included in user's public playlists, if false it will remain
        ///     private.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse FollowPlaylist(String ownerId, String playlistId, bool showPublic = true)
        {
            JObject body = new JObject
            {
                {"public", showPublic}
            };
            return UploadData<ErrorResponse>(_builder.SearchItems(ownerId, playlistId, showPublic), body.ToString(Formatting.None), "PUT");
        }

        /// <summary>
        ///     Add the current user as a follower of a playlist asynchronously.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">
        ///     The Spotify ID of the playlist. Any playlist can be followed, regardless of its public/private
        ///     status, as long as you know its playlist ID.
        /// </param>
        /// <param name="showPublic">
        ///     If true the playlist will be included in user's public playlists, if false it will remain
        ///     private.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> FollowPlaylistAsync(String ownerId, String playlistId, bool showPublic = true)
        {
            JObject body = new JObject
            {
                {"public", showPublic}
            };
            return UploadDataAsync<ErrorResponse>(_builder.SearchItems(ownerId, playlistId, showPublic), body.ToString(Formatting.None), "PUT");
        }

        /// <summary>
        ///     Remove the current user as a follower of a playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse UnfollowPlaylist(String ownerId, String playlistId)
        {
            return UploadData<ErrorResponse>(_builder.SearchItems(ownerId, playlistId), "", "DELETE");
        }

        /// <summary>
        ///     Remove the current user as a follower of a playlist asynchronously.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> UnfollowPlaylistAsync(String ownerId, String playlistId)
        {
            return UploadDataAsync<ErrorResponse>(_builder.SearchItems(ownerId, playlistId), "", "DELETE");
        }

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="ids">A list of Spotify User IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowingPlaylist(String ownerId, String playlistId, List<String> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowingPlaylist");
            JToken res = DownloadData<JToken>(_builder.SearchItems(ownerId, playlistId, ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist asynchronously.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="ids">A list of Spotify User IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ListResponse<Boolean>> IsFollowingPlaylistAsync(String ownerId, String playlistId, List<String> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowingPlaylist");
            JToken res = DownloadDataAsync<JToken>(_builder.SearchItems(ownerId, playlistId, ids));
            if (res is JArray) //todo expression is always false
                return Task.FromResult(new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null });
            return Task.FromResult(new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() });
        }

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="id">A Spotify User ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowingPlaylist(String ownerId, String playlistId, String id)
        {
            return IsFollowingPlaylist(ownerId, playlistId, new List<string> { id });
        }

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist asynchronously.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="id">A Spotify User ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ListResponse<Boolean>> IsFollowingPlaylistAsync(String ownerId, String playlistId, String id)
        {
            return IsFollowingPlaylistAsync(ownerId, playlistId, new List<string> { id });
        }

        #endregion Follow

        #region Library

        /// <summary>
        ///     Save one or more tracks to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse SaveTracks(List<String> ids)
        {
            JArray array = new JArray(ids);
            return UploadData<ErrorResponse>(SpotifyWebBuilder.APIBase + "/me/tracks/", array.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Save one or more tracks to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> SaveTracksAsync(List<String> ids)
        {
            JArray array = new JArray(ids);
            return UploadDataAsync<ErrorResponse>(SpotifyWebBuilder.APIBase + "/me/tracks/", array.ToString(Formatting.None), "PUT") ?? Task.FromResult(new ErrorResponse());
        }

        /// <summary>
        ///     Save one track to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse SaveTrack(String id)
        {
            return SaveTracks(new List<string> { id });
        }

        /// <summary>
        ///     Save one track to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> SaveTrackAsync(String id)
        {
            return SaveTracksAsync(new List<string> { id });
        }

        /// <summary>
        ///     Get a list of the songs saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<SavedTrack> GetSavedTracks(int limit = 20, int offset = 0, String market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetSavedTracks");
            return DownloadData<Paging<SavedTrack>>(_builder.SearchItems(limit, offset, market));
        }

        /// <summary>
        ///     Get a list of the songs saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<Paging<SavedTrack>> GetSavedTracksAsync(int limit = 20, int offset = 0, String market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetSavedTracks");
            return DownloadDataAsync<Paging<SavedTrack>>(_builder.SearchItems(limit, offset, market));
        }

        /// <summary>
        ///     Remove one or more tracks from the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse RemoveSavedTracks(List<String> ids)
        {
            JArray array = new JArray(ids);
            return UploadData<ErrorResponse>(SpotifyWebBuilder.APIBase + "/me/tracks/", array.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove one or more tracks from the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ErrorResponse> RemoveSavedTracksAsync(List<String> ids)
        {
            JArray array = new JArray(ids);
            return UploadDataAsync<ErrorResponse>(SpotifyWebBuilder.APIBase + "/me/tracks/", array.ToString(Formatting.None), "DELETE") ?? Task.FromResult(new ErrorResponse());
        }

        /// <summary>
        ///     Check if one or more tracks is already saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> CheckSavedTracks(List<String> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for CheckSavedTracks");
            JToken res = DownloadData<JToken>(APIBase + "/me/tracks/contains?ids=" + string.Join(",", ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        /// <summary>
        ///     Check if one or more tracks is already saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Task<ListResponse<Boolean>> CheckSavedTracksAsync(List<String> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for CheckSavedTracks");
            JToken res = DownloadDataAsync<JToken>(SpotifyWebBuilder.APIBase + "/me/tracks/contains?ids=" + string.Join(",", ids));
            if (res is JArray) //todo expression is always false
                return Task.FromResult(new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null });
            return Task.FromResult(new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() });
        }

        #endregion Library

        #region Playlists

        /// <summary>
        ///     Get a list of the playlists owned or followed by a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="limit">The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first playlist to return. Default: 0 (the first object)</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<SimplePlaylist> GetUserPlaylists(String userId, int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetUserPlaylists");
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/users/" + userId + "/playlists");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            return DownloadData<Paging<SimplePlaylist>>(builder.ToString());
        }

        /// <summary>
        ///     Get a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public FullPlaylist GetPlaylist(String userId, String playlistId, String fields = "", String market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPlaylist");
            StringBuilder builder = new StringBuilder(APIBase + "/users/" + userId + "/playlists/" + playlistId);
            builder.Append("?fields=" + fields);
            if (!String.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return DownloadData<FullPlaylist>(builder.ToString());
        }

        /// <summary>
        ///     Get full details of the tracks of a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="limit">The maximum number of tracks to return. Default: 100. Minimum: 1. Maximum: 100.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<PlaylistTrack> GetPlaylistTracks(String userId, String playlistId, String fields = "", int limit = 100, int offset = 0, String market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPlaylistTracks");
            limit = Math.Max(limit, 100);
            StringBuilder builder = new StringBuilder(APIBase + "/users/" + userId + "/playlists/" + playlistId + "/tracks");
            builder.Append("?fields=" + fields);
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!String.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return DownloadData<Paging<PlaylistTrack>>(builder.ToString());
        }

        /// <summary>
        ///     Create a playlist for a Spotify user. (The playlist will be empty until you add tracks.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistName">
        ///     The name for the new playlist, for example "Your Coolest Playlist". This name does not need
        ///     to be unique.
        /// </param>
        /// <param name="isPublic">
        ///     default true. If true the playlist will be public, if false it will be private. To be able to
        ///     create private playlists, the user must have granted the playlist-modify-private scope.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public FullPlaylist CreatePlaylist(String userId, String playlistName, Boolean isPublic = true)
        {
            JObject body = new JObject
            {
                {"name", playlistName},
                {"public", isPublic}
            };
            return UploadData<FullPlaylist>(APIBase + "/users/" + userId + "/playlists", body.ToString(Formatting.None));
        }

        /// <summary>
        ///     Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="newName">The new name for the playlist, for example "My New Playlist Title".</param>
        /// <param name="newPublic">If true the playlist will be public, if false it will be private.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse UpdatePlaylist(String userId, String playlistId, String newName = null, Boolean? newPublic = null)
        {
            JObject body = new JObject();
            if (newName != null)
                body.Add("name", newName);
            if (newPublic != null)
                body.Add("public", newPublic);
            return UploadData<ErrorResponse>(APIBase + "/users/" + userId + "/playlists/" + playlistId, body.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse ReplacePlaylistTracks(String userId, String playlistId, List<String> uris)
        {
            JObject body = new JObject
            {
                {"uris", new JArray(uris.Take(100))}
            };
            return UploadData<ErrorResponse>(APIBase + "/users/" + userId + "/playlists/" + playlistId + "/tracks", body.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">
        ///     array of objects containing Spotify URI strings (and their position in the playlist). A maximum of
        ///     100 objects can be sent at once.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse RemovePlaylistTracks(String userId, String playlistId, List<DeleteTrackUri> uris)
        {
            JObject body = new JObject
            {
                {"tracks", JArray.FromObject(uris.Take(100))}
            };
            return UploadData<ErrorResponse>(APIBase + "/users/" + userId + "/playlists/" + playlistId + "/tracks", body.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">Spotify URI</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse RemovePlaylistTrack(String userId, String playlistId, DeleteTrackUri uri)
        {
            return RemovePlaylistTracks(userId, playlistId, new List<DeleteTrackUri> { uri });
        }

        /// <summary>
        ///     Add one or more tracks to a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to add</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse AddPlaylistTracks(String userId, String playlistId, List<String> uris, int? position = null)
        {
            JObject body = new JObject
            {
                {"uris", JArray.FromObject(uris.Take(100))}
            };
            if (position == null)
                return UploadData<ErrorResponse>(APIBase + "/users/" + userId + "/playlists/" + playlistId + "/tracks", body.ToString(Formatting.None)) ?? new ErrorResponse();
            return UploadData<ErrorResponse>(APIBase + "/users/" + userId + "/playlists/" + playlistId + "/tracks?position=" + position, body.ToString(Formatting.None)) ?? new ErrorResponse();
        }

        /// <summary>
        ///     Add one or more tracks to a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">A Spotify Track URI</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse AddPlaylistTrack(String userId, String playlistId, String uri, int? position = null)
        {
            return AddPlaylistTracks(userId, playlistId, new List<string> { uri }, position);
        }

        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="rangeStart">The position of the first track to be reordered.</param>
        /// <param name="insertBefore">The position where the tracks should be inserted. </param>
        /// <param name="rangeLength">The amount of tracks to be reordered. Defaults to 1 if not set.</param>
        /// <param name="snapshotId">The playlist's snapshot ID against which you want to make the changes.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Snapshot ReorderPlaylist(String userId, String playlistId, int rangeStart, int insertBefore, int rangeLength = 1, String snapshotId = "")
        {
            JObject body = new JObject
            {
                {"range_start", rangeStart},
                {"range_length", rangeLength},
                {"insert_before", insertBefore}
            };
            if (!String.IsNullOrEmpty(snapshotId))
                body.Add("snapshot_id", snapshotId);
            return UploadData<Snapshot>(APIBase + "/users/" + userId + "/playlists/" + playlistId + "/tracks", body.ToString(Formatting.None), "PUT");
        }

        #endregion Playlists

        #region Profiles

        /// <summary>
        ///     Get detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public PrivateProfile GetPrivateProfile()
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPrivateProfile");
            return DownloadData<PrivateProfile>(APIBase + "/me");
        }

        /// <summary>
        ///     Get public profile information about a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <returns></returns>
        public PublicProfile GetPublicProfile(String userId)
        {
            return DownloadData<PublicProfile>(APIBase + "/users/" + userId);
        }

        #endregion Profiles

        #region Tracks

        /// <summary>
        ///     Get Spotify catalog information for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the tracks. Maximum: 50 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public SeveralTracks GetSeveralTracks(List<String> ids, String market = "")
        {
            if (String.IsNullOrEmpty(market))
                return DownloadData<SeveralTracks>(APIBase + "/tracks?ids=" + string.Join(",", ids.Take(50)));
            return DownloadData<SeveralTracks>(APIBase + "/tracks?market=" + market + "&ids=" + string.Join(",", ids.Take(50)));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public FullTrack GetTrack(String id, String market = "")
        {
            if (String.IsNullOrEmpty(market))
                return DownloadData<FullTrack>(APIBase + "/tracks/" + id);
            return DownloadData<FullTrack>(APIBase + "/tracks/" + id + "?market=" + market);
        }

        #endregion Tracks

        #region Util

        public T UploadData<T>(String url, String uploadData, String method = "POST")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for all Upload-Actions");
            WebClient.SetHeader("Authorization", TokenType + " " + AccessToken);
            WebClient.SetHeader("Content-Type", "application/json");
            return WebClient.UploadJson<T>(url, uploadData, method);
        }

        public Task<T> UploadDataAsync<T>(String url, String uploadData, String method = "POST")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for all Upload-Actions");
            WebClient.SetHeader("Authorization", TokenType + " " + AccessToken);
            WebClient.SetHeader("Content-Type", "application/json");
            return WebClient.UploadJsonAsync<T>(url, uploadData, method);
        }

        public T DownloadData<T>(String url)
        {
            if (UseAuth)
                WebClient.SetHeader("Authorization", TokenType + " " + AccessToken);
            else
                WebClient.RemoveHeader("Authorization");
            return WebClient.DownloadJson<T>(url);
        }

        public Task<T> DownloadDataAsync<T>(String url)
        {
            if (UseAuth)
                WebClient.SetHeader("Authorization", TokenType + " " + AccessToken);
            else
                WebClient.RemoveHeader("Authorization");
            return WebClient.DownloadJsonAsync<T>(url);
        }

        #endregion Util
    }
}