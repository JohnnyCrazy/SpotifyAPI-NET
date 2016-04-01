using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SpotifyAPI.Web
{
    // ReSharper disable once InconsistentNaming
    public sealed class SpotifyWebAPI : IDisposable
    {
        [Obsolete("This Property will be removed soon. Please use SpotifyWebBuilder.APIBase")]
        public const string APIBase = SpotifyWebBuilder.APIBase;

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

        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public Boolean UseAuth { get; set; }
        public IClient WebClient { get; set; }

        public void Dispose()
        {
            WebClient.Dispose();
            GC.SuppressFinalize(this);
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
        public SearchItem SearchItems(string q, SearchType type, int limit = 20, int offset = 0, string market = "")
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
        public async Task<SearchItem> SearchItemsAsync(string q, SearchType type, int limit = 20, int offset = 0, string market = "")
        {
            return await DownloadDataAsync<SearchItem>(_builder.SearchItems(q, type, limit, offset, market));
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
        public Paging<SimpleTrack> GetAlbumTracks(string id, int limit = 20, int offset = 0, string market = "")
        {
            return DownloadData<Paging<SimpleTrack>>(_builder.GetAlbumTracks(id, limit, offset, market));
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
        public async Task<Paging<SimpleTrack>> GetAlbumTracksAsync(string id, int limit = 20, int offset = 0, string market = "")
        {
            return await DownloadDataAsync<Paging<SimpleTrack>>(_builder.GetAlbumTracks(id, limit, offset, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public FullAlbum GetAlbum(string id, string market = "")
        {
            return DownloadData<FullAlbum>(_builder.GetAlbum(id, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single album asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public async Task<FullAlbum> GetAlbumAsync(string id, string market = "")
        {
            return await DownloadDataAsync<FullAlbum>(_builder.GetAlbum(id, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public SeveralAlbums GetSeveralAlbums(List<string> ids, string market = "")
        {
            return DownloadData<SeveralAlbums>(_builder.GetSeveralAlbums(ids, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for multiple albums identified by their Spotify IDs asynchrously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public async Task<SeveralAlbums> GetSeveralAlbumsAsync(List<string> ids, string market = "")
        {
            return await DownloadDataAsync<SeveralAlbums>(_builder.GetSeveralAlbums(ids, market));
        }

        #endregion Albums

        #region Artists

        /// <summary>
        ///     Get Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public FullArtist GetArtist(string id)
        {
            return DownloadData<FullArtist>(_builder.GetArtist(id));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single artist identified by their unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public async Task<FullArtist> GetArtistAsync(string id)
        {
            return await DownloadDataAsync<FullArtist>(_builder.GetArtist(id));
        }

        /// <summary>
        ///     Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the
        ///     Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public SeveralArtists GetRelatedArtists(string id)
        {
            return DownloadData<SeveralArtists>(_builder.GetRelatedArtists(id));
        }

        /// <summary>
        ///     Get Spotify catalog information about artists similar to a given artist asynchronously. Similarity is based on analysis of the
        ///     Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public async Task<SeveralArtists> GetRelatedArtistsAsync(string id)
        {
            return await DownloadDataAsync<SeveralArtists>(_builder.GetRelatedArtists(id));
        }

        /// <summary>
        ///     Get Spotify catalog information about an artist’s top tracks by country.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code.</param>
        /// <returns></returns>
        public SeveralTracks GetArtistsTopTracks(string id, string country)
        {
            return DownloadData<SeveralTracks>(_builder.GetArtistsTopTracks(id, country));
        }

        /// <summary>
        ///     Get Spotify catalog information about an artist’s top tracks by country asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code.</param>
        /// <returns></returns>
        public async Task<SeveralTracks> GetArtistsTopTracksAsync(string id, string country)
        {
            return await DownloadDataAsync<SeveralTracks>(_builder.GetArtistsTopTracks(id, country));
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
        public Paging<SimpleAlbum> GetArtistsAlbums(string id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, string market = "")
        {
            return DownloadData<Paging<SimpleAlbum>>(_builder.GetArtistsAlbums(id, type, limit, offset, market));
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
        public async Task<Paging<SimpleAlbum>> GetArtistsAlbumsAsync(string id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, string market = "")
        {
            return await DownloadDataAsync<Paging<SimpleAlbum>>(_builder.GetArtistsAlbums(id, type, limit, offset, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns></returns>
        public SeveralArtists GetSeveralArtists(List<string> ids)
        {
            return DownloadData<SeveralArtists>(_builder.GetSeveralArtists(ids));
        }

        /// <summary>
        ///     Get Spotify catalog information for several artists based on their Spotify IDs asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns></returns>
        public async Task<SeveralArtists> GetSeveralArtistsAsync(List<string> ids)
        {
            return await DownloadDataAsync<SeveralArtists>(_builder.GetSeveralArtists(ids));
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
        public FeaturedPlaylists GetFeaturedPlaylists(string locale = "", string country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFeaturedPlaylists");
            return DownloadData<FeaturedPlaylists>(_builder.GetFeaturedPlaylists(locale, country, timestamp, limit, offset));
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
        public async Task<FeaturedPlaylists> GetFeaturedPlaylistsAsync(string locale = "", string country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFeaturedPlaylists");
            return await DownloadDataAsync<FeaturedPlaylists>(_builder.GetFeaturedPlaylists(locale, country, timestamp, limit, offset));
        }

        /// <summary>
        ///     Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public NewAlbumReleases GetNewAlbumReleases(string country = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetNewAlbumReleases");
            return DownloadData<NewAlbumReleases>(_builder.GetNewAlbumReleases(country, limit, offset));
        }

        /// <summary>
        ///     Get a list of new album releases featured in Spotify asynchronously (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<NewAlbumReleases> GetNewAlbumReleasesAsync(string country = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetNewAlbumReleases");
            return await DownloadDataAsync<NewAlbumReleases>(_builder.GetNewAlbumReleases(country, limit, offset));
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
        public CategoryList GetCategories(string country = "", string locale = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetCategories");
            return DownloadData<CategoryList>(_builder.GetCategories(country, locale, limit, offset));
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
        public async Task<CategoryList> GetCategoriesAsync(string country = "", string locale = "", int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetCategories");
            return await DownloadDataAsync<CategoryList>(_builder.GetCategories(country, locale, limit, offset));
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
        public Category GetCategory(string categoryId, string country = "", string locale = "")
        {
            return DownloadData<Category>(_builder.GetCategory(categoryId, country, locale));
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
        public async Task<Category> GetCategoryAsync(string categoryId, string country = "", string locale = "")
        {
            return await DownloadDataAsync<Category>(_builder.GetCategory(categoryId, country, locale));
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
        public CategoryPlaylist GetCategoryPlaylists(string categoryId, string country = "", int limit = 20, int offset = 0)
        {
            return DownloadData<CategoryPlaylist>(_builder.GetCategoryPlaylists(categoryId, country, limit, offset));
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
        public async Task<CategoryPlaylist> GetCategoryPlaylistsAsync(string categoryId, string country = "", int limit = 20, int offset = 0)
        {
            return await DownloadDataAsync<CategoryPlaylist>(_builder.GetCategoryPlaylists(categoryId, country, limit, offset));
        }

        /// <summary>
        ///     Create a playlist-style listening experience based on seed artists, tracks and genres.
        /// </summary>
        /// <param name="artistSeed">A comma separated list of Spotify IDs for seed artists. 
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="genreSeed">A comma separated list of any genres in the set of available genre seeds.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="trackSeed">A comma separated list of Spotify IDs for a seed track.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="target">Tracks with the attribute values nearest to the target values will be preferred.</param>
        /// <param name="min">For each tunable track attribute, a hard floor on the selected track attribute’s value can be provided</param>
        /// <param name="max">For each tunable track attribute, a hard ceiling on the selected track attribute’s value can be provided</param>
        /// <param name="limit">The target size of the list of recommended tracks. Default: 20. Minimum: 1. Maximum: 100.
        /// For seeds with unusually small pools or when highly restrictive filtering is applied, it may be impossible to generate the requested number of recommended tracks.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.
        /// Because min_*, max_* and target_* are applied to pools before relinking, the generated results may not precisely match the filters applied.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Recommendations GetRecommendations(List<string> artistSeed = null, List<string> genreSeed = null, List<string> trackSeed = null,
            TuneableTrack target = null, TuneableTrack min = null, TuneableTrack max = null, int limit = 20, string market = "")
        {
            return DownloadData<Recommendations>(_builder.GetRecommendations(artistSeed, genreSeed, trackSeed, target, min, max, limit, market));
        }

        /// <summary>
        ///     Create a playlist-style listening experience based on seed artists, tracks and genres asynchronously.
        /// </summary>
        /// <param name="artistSeed">A comma separated list of Spotify IDs for seed artists. 
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="genreSeed">A comma separated list of any genres in the set of available genre seeds.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="trackSeed">A comma separated list of Spotify IDs for a seed track.
        /// Up to 5 seed values may be provided in any combination of seed_artists, seed_tracks and seed_genres.
        /// </param>
        /// <param name="target">Tracks with the attribute values nearest to the target values will be preferred.</param>
        /// <param name="min">For each tunable track attribute, a hard floor on the selected track attribute’s value can be provided</param>
        /// <param name="max">For each tunable track attribute, a hard ceiling on the selected track attribute’s value can be provided</param>
        /// <param name="limit">The target size of the list of recommended tracks. Default: 20. Minimum: 1. Maximum: 100.
        /// For seeds with unusually small pools or when highly restrictive filtering is applied, it may be impossible to generate the requested number of recommended tracks.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.
        /// Because min_*, max_* and target_* are applied to pools before relinking, the generated results may not precisely match the filters applied.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<Recommendations> GetRecommendationsAsync(List<string> artistSeed = null, List<string> genreSeed = null, List<string> trackSeed = null,
            TuneableTrack target = null, TuneableTrack min = null, TuneableTrack max = null, int limit = 20, string market = "")
        {
            return await DownloadDataAsync<Recommendations>(_builder.GetRecommendations(artistSeed, genreSeed, trackSeed, target, min, max, limit, market));
        }

        /// <summary>
        ///     Retrieve a list of available genres seed parameter values for recommendations.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public RecommendationSeedGenres GetRecommendationSeedsGenres()
        {
            return DownloadData<RecommendationSeedGenres>(_builder.GetRecommendationSeedsGenres());
        }

        /// <summary>
        ///     Retrieve a list of available genres seed parameter values for recommendations asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<RecommendationSeedGenres> GetRecommendationSeedsGenresAsync()
        {
            return await DownloadDataAsync<RecommendationSeedGenres>(_builder.GetRecommendationSeedsGenres());
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
        public FollowedArtists GetFollowedArtists(FollowType followType, int limit = 20, string after = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFollowedArtists");
            return DownloadData<FollowedArtists>(_builder.GetFollowedArtists(limit, after));
        }

        /// <summary>
        ///     Get the current user’s followed artists asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: currently only artist is supported. </param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">The last artist ID retrieved from the previous request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<FollowedArtists> GetFollowedArtistsAsync(FollowType followType, int limit = 20, string after = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetFollowedArtists");
            return await DownloadDataAsync<FollowedArtists>(_builder.GetFollowedArtists(limit, after));
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Follow(FollowType followType, List<string> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return UploadData<ErrorResponse>(_builder.Follow(followType), ob.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> FollowAsync(FollowType followType, List<string> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return await 
                UploadDataAsync<ErrorResponse>(_builder.Follow(followType),
                    ob.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Follow(FollowType followType, string id)
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
        public async Task<ErrorResponse> FollowAsync(FollowType followType, string id)
        {
            return await FollowAsync(followType, new List<string> { id });
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Unfollow(FollowType followType, List<string> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return UploadData<ErrorResponse>(_builder.Unfollow(followType), ob.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users asynchronously.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> UnfollowAsync(FollowType followType, List<string> ids)
        {
            JObject ob = new JObject
            {
                {"ids", new JArray(ids)}
            };
            return await UploadDataAsync<ErrorResponse>(_builder.Unfollow(followType), ob.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse Unfollow(FollowType followType, string id)
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
        public async Task<ErrorResponse> UnfollowAsync(FollowType followType, string id)
        {
            return await UnfollowAsync(followType, new List<string> { id });
        }

        /// <summary>
        ///     Check to see if the current user is following one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs to check</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowing(FollowType followType, List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowing");
            JToken res = DownloadData<JToken>(_builder.IsFollowing(followType, ids));
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
        public async Task<ListResponse<Boolean>> IsFollowingAsync(FollowType followType, List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowing");
            JToken res = await DownloadDataAsync<JToken>(_builder.IsFollowing(followType, ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        /// <summary>
        ///     Check to see if the current user is following one artist or another Spotify user.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="id">Artists or the Users Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowing(FollowType followType, string id)
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
        public async Task<ListResponse<Boolean>> IsFollowingAsync(FollowType followType, string id)
        {
            return await IsFollowingAsync(followType, new List<string> { id });
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
        public ErrorResponse FollowPlaylist(string ownerId, string playlistId, bool showPublic = true)
        {
            JObject body = new JObject
            {
                {"public", showPublic}
            };
            return UploadData<ErrorResponse>(_builder.FollowPlaylist(ownerId, playlistId, showPublic), body.ToString(Formatting.None), "PUT");
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
        public async Task<ErrorResponse> FollowPlaylistAsync(string ownerId, string playlistId, bool showPublic = true)
        {
            JObject body = new JObject
            {
                {"public", showPublic}
            };
            return await UploadDataAsync<ErrorResponse>(_builder.FollowPlaylist(ownerId, playlistId, showPublic), body.ToString(Formatting.None), "PUT");
        }

        /// <summary>
        ///     Remove the current user as a follower of a playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse UnfollowPlaylist(string ownerId, string playlistId)
        {
            return UploadData<ErrorResponse>(_builder.UnfollowPlaylist(ownerId, playlistId), "", "DELETE");
        }

        /// <summary>
        ///     Remove the current user as a follower of a playlist asynchronously.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> UnfollowPlaylistAsync(string ownerId, string playlistId)
        {
            return await UploadDataAsync<ErrorResponse>(_builder.UnfollowPlaylist(ownerId, playlistId), "", "DELETE");
        }

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="ids">A list of Spotify User IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowingPlaylist(string ownerId, string playlistId, List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowingPlaylist");
            JToken res = DownloadData<JToken>(_builder.IsFollowingPlaylist(ownerId, playlistId, ids));
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
        public async Task<ListResponse<Boolean>> IsFollowingPlaylistAsync(string ownerId, string playlistId, List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for IsFollowingPlaylist");
            JToken res = await DownloadDataAsync<JToken>(_builder.IsFollowingPlaylist(ownerId, playlistId, ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="id">A Spotify User ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> IsFollowingPlaylist(string ownerId, string playlistId, string id)
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
        public async Task<ListResponse<Boolean>> IsFollowingPlaylistAsync(string ownerId, string playlistId, string id)
        {
            return await IsFollowingPlaylistAsync(ownerId, playlistId, new List<string> { id });
        }

        #endregion Follow

        #region Library

        /// <summary>
        ///     Save one or more tracks to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse SaveTracks(List<string> ids)
        {
            JArray array = new JArray(ids);
            return UploadData<ErrorResponse>(_builder.SaveTracks(), array.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Save one or more tracks to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> SaveTracksAsync(List<string> ids)
        {
            JArray array = new JArray(ids);
            return await UploadDataAsync<ErrorResponse>(_builder.SaveTracks(), array.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Save one track to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse SaveTrack(string id)
        {
            return SaveTracks(new List<string> { id });
        }

        /// <summary>
        ///     Save one track to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> SaveTrackAsync(string id)
        {
            return await SaveTracksAsync(new List<string> { id });
        }

        /// <summary>
        ///     Get a list of the songs saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<SavedTrack> GetSavedTracks(int limit = 20, int offset = 0, string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetSavedTracks");
            return DownloadData<Paging<SavedTrack>>(_builder.GetSavedTracks(limit, offset, market));
        }

        /// <summary>
        ///     Get a list of the songs saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<Paging<SavedTrack>> GetSavedTracksAsync(int limit = 20, int offset = 0, string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetSavedTracks");
            return await DownloadDataAsync<Paging<SavedTrack>>(_builder.GetSavedTracks(limit, offset, market));
        }

        /// <summary>
        ///     Remove one or more tracks from the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse RemoveSavedTracks(List<string> ids)
        {
            JArray array = new JArray(ids);
            return UploadData<ErrorResponse>(_builder.RemoveSavedTracks(), array.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove one or more tracks from the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> RemoveSavedTracksAsync(List<string> ids)
        {
            JArray array = new JArray(ids);
            return await UploadDataAsync<ErrorResponse>(_builder.RemoveSavedTracks(), array.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Check if one or more tracks is already saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> CheckSavedTracks(List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for CheckSavedTracks");
            JToken res = DownloadData<JToken>(_builder.CheckSavedTracks(ids));
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
        public async Task<ListResponse<Boolean>> CheckSavedTracksAsync(List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for CheckSavedTracks");
            JToken res = await DownloadDataAsync<JToken>(_builder.CheckSavedTracks(ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        /// <summary>
        ///     Save one or more albums to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse SaveAlbums(List<string> ids)
        {
            JArray array = new JArray(ids);
            return UploadData<ErrorResponse>(_builder.SaveAlbums(), array.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Save one or more albums to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> SaveAlbumsAsync(List<string> ids)
        {
            JArray array = new JArray(ids);
            return await UploadDataAsync<ErrorResponse>(_builder.SaveAlbums(), array.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Save one album to the current user’s “Your Music” library.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse SaveAlbum(string id)
        {
            return SaveAlbums(new List<string> { id });
        }

        /// <summary>
        ///     Save one album to the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="id">A Spotify ID</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> SaveAlbumAsync(string id)
        {
            return await SaveAlbumsAsync(new List<string> { id });
        }

        /// <summary>
        ///     Get a list of the albums saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<SavedAlbum> GetSavedAlbums(int limit = 20, int offset = 0, string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetSavedAlbums");
            return DownloadData<Paging<SavedAlbum>>(_builder.GetSavedAlbums(limit, offset, market));
        }

        /// <summary>
        ///     Get a list of the albums saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<Paging<SavedAlbum>> GetSavedAlbumsAsync(int limit = 20, int offset = 0, string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetSavedAlbumsAsync");
            return await DownloadDataAsync<Paging<SavedAlbum>>(_builder.GetSavedAlbums(limit, offset, market));
        }

        /// <summary>
        ///     Remove one or more albums from the current user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse RemoveSavedAlbums(List<string> ids)
        {
            JArray array = new JArray(ids);
            return UploadData<ErrorResponse>(_builder.RemoveSavedAlbums(), array.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove one or more albums from the current user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> RemoveSavedAlbumsAsync(List<string> ids)
        {
            JArray array = new JArray(ids);
            return await UploadDataAsync<ErrorResponse>(_builder.RemoveSavedAlbums(), array.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Check if one or more albums is already saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ListResponse<Boolean> CheckSavedAlbums(List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for CheckSavedTracks");
            JToken res = DownloadData<JToken>(_builder.CheckSavedAlbums(ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        /// <summary>
        ///     Check if one or more albums is already saved in the current Spotify user’s “Your Music” library asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ListResponse<Boolean>> CheckSavedAlbumsAsync(List<string> ids)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for CheckSavedAlbumsAsync");
            JToken res = await DownloadDataAsync<JToken>(_builder.CheckSavedAlbums(ids));
            if (res is JArray)
                return new ListResponse<Boolean> { List = res.ToObject<List<Boolean>>(), Error = null };
            return new ListResponse<Boolean> { List = null, Error = res["error"].ToObject<Error>() };
        }

        #endregion Library

        #region Personalization

        /// <summary>
        ///     Get the current user’s top tracks based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed. 
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available), 
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<FullTrack> GetUsersTopTracks(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0)
        {
            return DownloadData<Paging<FullTrack>>(_builder.GetUsersTopTracks(timeRange, limit, offest));
        }

        /// <summary>
        ///     Get the current user’s top tracks based on calculated affinity asynchronously.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed. 
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available), 
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<Paging<FullTrack>> GetUsersTopTracksAsync(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0)
        {
            return await DownloadDataAsync<Paging<FullTrack>>(_builder.GetUsersTopTracks(timeRange, limit, offest));
        }

        /// <summary>
        ///     Get the current user’s top artists based on calculated affinity.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed. 
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available), 
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<FullArtist> GetUsersTopArtists(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0)
        {
            return DownloadData<Paging<FullArtist>>(_builder.GetUsersTopArtists(timeRange, limit, offest));
        }

        /// <summary>
        ///     Get the current user’s top artists based on calculated affinity asynchronously.
        /// </summary>
        /// <param name="timeRange">Over what time frame the affinities are computed. 
        /// Valid values: long_term (calculated from several years of data and including all new data as it becomes available), 
        /// medium_term (approximately last 6 months), short_term (approximately last 4 weeks). </param>
        /// <param name="limit">The number of entities to return. Default: 20. Minimum: 1. Maximum: 50</param>
        /// <param name="offest">The index of the first entity to return. Default: 0 (i.e., the first track). Use with limit to get the next set of entities.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<Paging<FullArtist>> GetUsersTopArtistsAsync(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0)
        {
            return await DownloadDataAsync<Paging<FullArtist>>(_builder.GetUsersTopArtists(timeRange, limit, offest));
        }

        #endregion

        #region Playlists

        /// <summary>
        ///     Get a list of the playlists owned or followed by a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="limit">The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first playlist to return. Default: 0 (the first object)</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public Paging<SimplePlaylist> GetUserPlaylists(string userId, int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetUserPlaylists");
            return DownloadData<Paging<SimplePlaylist>>(_builder.GetUserPlaylists(userId, limit, offset));
        }

        /// <summary>
        ///     Get a list of the playlists owned or followed by a Spotify user asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="limit">The maximum number of playlists to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="offset">The index of the first playlist to return. Default: 0 (the first object)</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<Paging<SimplePlaylist>> GetUserPlaylistsAsync(string userId, int limit = 20, int offset = 0)
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetUserPlaylists");
            return await DownloadDataAsync<Paging<SimplePlaylist>>(_builder.GetUserPlaylists(userId, limit, offset));
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
        public FullPlaylist GetPlaylist(string userId, string playlistId, string fields = "", string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPlaylist");
            return DownloadData<FullPlaylist>(_builder.GetPlaylist(userId, playlistId, fields, market));
        }

        /// <summary>
        ///     Get a playlist owned by a Spotify user asynchronously.
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
        public async Task<FullPlaylist> GetPlaylistAsync(string userId, string playlistId, string fields = "", string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPlaylist");
            return await DownloadDataAsync<FullPlaylist>(_builder.GetPlaylist(userId, playlistId, fields, market));
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
        public Paging<PlaylistTrack> GetPlaylistTracks(string userId, string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPlaylistTracks");
            return DownloadData<Paging<PlaylistTrack>>(_builder.GetPlaylistTracks(userId, playlistId, fields, limit, offset, market));
        }

        /// <summary>
        ///     Get full details of the tracks of a playlist owned by a Spotify user asyncronously.
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
        public async Task<Paging<PlaylistTrack>> GetPlaylistTracksAsync(string userId, string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPlaylistTracks");
            return await DownloadDataAsync<Paging<PlaylistTrack>>(_builder.GetPlaylistTracks(userId, playlistId, fields, limit, offset, market));
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
        public FullPlaylist CreatePlaylist(string userId, string playlistName, Boolean isPublic = true)
        {
            JObject body = new JObject
            {
                {"name", playlistName},
                {"public", isPublic}
            };
            return UploadData<FullPlaylist>(_builder.CreatePlaylist(userId, playlistName, isPublic), body.ToString(Formatting.None));
        }

        /// <summary>
        ///     Create a playlist for a Spotify user asynchronously. (The playlist will be empty until you add tracks.)
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
        public async Task<FullPlaylist> CreatePlaylistAsync(string userId, string playlistName, Boolean isPublic = true)
        {
            JObject body = new JObject
            {
                {"name", playlistName},
                {"public", isPublic}
            };
            return await UploadDataAsync<FullPlaylist>(_builder.CreatePlaylist(userId, playlistName, isPublic), body.ToString(Formatting.None));
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
        public ErrorResponse UpdatePlaylist(string userId, string playlistId, string newName = null, Boolean? newPublic = null)
        {
            JObject body = new JObject();
            if (newName != null)
                body.Add("name", newName);
            if (newPublic != null)
                body.Add("public", newPublic);
            return UploadData<ErrorResponse>(_builder.UpdatePlaylist(userId, playlistId), body.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Change a playlist’s name and public/private state asynchronously. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="newName">The new name for the playlist, for example "My New Playlist Title".</param>
        /// <param name="newPublic">If true the playlist will be public, if false it will be private.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> UpdatePlaylistAsync(string userId, string playlistId, string newName = null, Boolean? newPublic = null)
        {
            JObject body = new JObject();
            if (newName != null)
                body.Add("name", newName);
            if (newPublic != null)
                body.Add("public", newPublic);
            return await UploadDataAsync<ErrorResponse>(_builder.UpdatePlaylist(userId, playlistId), body.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
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
        public ErrorResponse ReplacePlaylistTracks(string userId, string playlistId, List<string> uris)
        {
            JObject body = new JObject
            {
                {"uris", new JArray(uris.Take(100))}
            };
            return UploadData<ErrorResponse>(_builder.ReplacePlaylistTracks(userId, playlistId), body.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Replace all the tracks in a playlist asynchronously, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to set. A maximum of 100 tracks can be set in one request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> ReplacePlaylistTracksAsync(string userId, string playlistId, List<string> uris)
        {
            JObject body = new JObject
            {
                {"uris", new JArray(uris.Take(100))}
            };
            return await UploadDataAsync<ErrorResponse>(_builder.ReplacePlaylistTracks(userId, playlistId), body.ToString(Formatting.None), "PUT") ?? new ErrorResponse();
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
        public ErrorResponse RemovePlaylistTracks(string userId, string playlistId, List<DeleteTrackUri> uris)
        {
            JObject body = new JObject
            {
                {"tracks", JArray.FromObject(uris.Take(100))}
            };
            return UploadData<ErrorResponse>(_builder.RemovePlaylistTracks(userId, playlistId, uris), body.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">
        ///     array of objects containing Spotify URI strings (and their position in the playlist). A maximum of
        ///     100 objects can be sent at once.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> RemovePlaylistTracksAsync(string userId, string playlistId, List<DeleteTrackUri> uris)
        {
            JObject body = new JObject
            {
                {"tracks", JArray.FromObject(uris.Take(100))}
            };
            return await UploadDataAsync<ErrorResponse>(_builder.RemovePlaylistTracks(userId, playlistId, uris), body.ToString(Formatting.None), "DELETE") ?? new ErrorResponse();
        }

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">Spotify URI</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public ErrorResponse RemovePlaylistTrack(string userId, string playlistId, DeleteTrackUri uri)
        {
            return RemovePlaylistTracks(userId, playlistId, new List<DeleteTrackUri> { uri });
        }

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">Spotify URI</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> RemovePlaylistTrackAsync(string userId, string playlistId, DeleteTrackUri uri)
        {
            return await RemovePlaylistTracksAsync(userId, playlistId, new List<DeleteTrackUri> { uri });
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
        public ErrorResponse AddPlaylistTracks(string userId, string playlistId, List<string> uris, int? position = null)
        {
            JObject body = new JObject
            {
                {"uris", JArray.FromObject(uris.Take(100))}
            };
            return UploadData<ErrorResponse>(_builder.AddPlaylistTracks(userId, playlistId, uris, position), body.ToString(Formatting.None)) ?? new ErrorResponse();
        }

        /// <summary>
        ///     Add one or more tracks to a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to add</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> AddPlaylistTracksAsync(string userId, string playlistId, List<string> uris, int? position = null)
        {
            JObject body = new JObject
            {
                {"uris", JArray.FromObject(uris.Take(100))}
            };
            return await UploadDataAsync<ErrorResponse>(_builder.AddPlaylistTracks(userId, playlistId, uris, position), body.ToString(Formatting.None)) ?? new ErrorResponse();
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
        public ErrorResponse AddPlaylistTrack(string userId, string playlistId, string uri, int? position = null)
        {
            return AddPlaylistTracks(userId, playlistId, new List<string> { uri }, position);
        }

        /// <summary>
        ///     Add one or more tracks to a user’s playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uri">A Spotify Track URI</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<ErrorResponse> AddPlaylistTrackAsync(string userId, string playlistId, string uri, int? position = null)
        {
            return await AddPlaylistTracksAsync(userId, playlistId, new List<string> { uri }, position);
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
        public Snapshot ReorderPlaylist(string userId, string playlistId, int rangeStart, int insertBefore, int rangeLength = 1, string snapshotId = "")
        {
            JObject body = new JObject
            {
                {"range_start", rangeStart},
                {"range_length", rangeLength},
                {"insert_before", insertBefore}
            };
            if (!string.IsNullOrEmpty(snapshotId))
                body.Add("snapshot_id", snapshotId);
            return UploadData<Snapshot>(_builder.ReorderPlaylist(userId, playlistId), body.ToString(Formatting.None), "PUT");
        }

        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="rangeStart">The position of the first track to be reordered.</param>
        /// <param name="insertBefore">The position where the tracks should be inserted. </param>
        /// <param name="rangeLength">The amount of tracks to be reordered. Defaults to 1 if not set.</param>
        /// <param name="snapshotId">The playlist's snapshot ID against which you want to make the changes.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<Snapshot> ReorderPlaylistAsync(string userId, string playlistId, int rangeStart, int insertBefore, int rangeLength = 1, string snapshotId = "")
        {
            JObject body = new JObject
            {
                {"range_start", rangeStart},
                {"range_length", rangeLength},
                {"insert_before", insertBefore},
                {"snapshot_id", snapshotId}
            };
            if (!string.IsNullOrEmpty(snapshotId))
                body.Add("snapshot_id", snapshotId);
            return await UploadDataAsync<Snapshot>(_builder.ReorderPlaylist(userId, playlistId), body.ToString(Formatting.None), "PUT");
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
            return DownloadData<PrivateProfile>(_builder.GetPrivateProfile());
        }

        /// <summary>
        ///     Get detailed profile information about the current user asynchronously (including the current user’s username).
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<PrivateProfile> GetPrivateProfileAsync()
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for GetPrivateProfile");
            return await DownloadDataAsync<PrivateProfile>(_builder.GetPrivateProfile());
        }

        /// <summary>
        ///     Get public profile information about a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <returns></returns>
        public PublicProfile GetPublicProfile(string userId)
        {
            return DownloadData<PublicProfile>(_builder.GetPublicProfile(userId));
        }

        /// <summary>
        ///     Get public profile information about a Spotify user asynchronously.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <returns></returns>
        public async Task<PublicProfile> GetPublicProfileAsync(string userId)
        {
            return await DownloadDataAsync<PublicProfile>(_builder.GetPublicProfile(userId));
        }

        #endregion Profiles

        #region Tracks

        /// <summary>
        ///     Get Spotify catalog information for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the tracks. Maximum: 50 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public SeveralTracks GetSeveralTracks(List<string> ids, string market = "")
        {
            return DownloadData<SeveralTracks>(_builder.GetSeveralTracks(ids, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for multiple tracks based on their Spotify IDs asynchronously.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the tracks. Maximum: 50 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public async Task<SeveralTracks> GetSeveralTracksAsync(List<string> ids, string market = "")
        {
            return await DownloadDataAsync<SeveralTracks>(_builder.GetSeveralTracks(ids, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public FullTrack GetTrack(string id, string market = "")
        {
            return DownloadData<FullTrack>(_builder.GetTrack(id, market));
        }

        /// <summary>
        ///     Get Spotify catalog information for a single track identified by its unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public async Task<FullTrack> GetTrackAsync(string id, string market = "")
        {
            return await DownloadDataAsync<FullTrack>(_builder.GetTrack(id, market));
        }

        /// <summary>
        ///     Get audio feature information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public AudioFeatures GetAudioFeatures(string id)
        {
            return DownloadData<AudioFeatures>(_builder.GetAudioFeatures(id));
        }

        /// <summary>
        ///     Get audio feature information for a single track identified by its unique Spotify ID asynchronously.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<AudioFeatures> GetAudioFeaturesAsync(string id)
        {
            return await DownloadDataAsync<AudioFeatures>(_builder.GetAudioFeatures(id));
        }

        /// <summary>
        ///     Get audio features for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of Spotify Track-IDs. Maximum: 100 IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public SeveralAudioFeatures GetSeveralAudioFeatures(List<string> ids)
        {
            return DownloadData<SeveralAudioFeatures>(_builder.GetSeveralAudioFeatures(ids));
        }

        /// <summary>
        ///     Get audio features for multiple tracks based on their Spotify IDs asynchronously.
        /// </summary>
        /// <param name="ids">A list of Spotify Track-IDs. Maximum: 100 IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public async Task<SeveralAudioFeatures> GetSeveralAudioFeaturesAsync(List<string> ids)
        {
            return await DownloadDataAsync<SeveralAudioFeatures>(_builder.GetSeveralAudioFeatures(ids));
        }

        #endregion Tracks

        #region Util

        public Paging<T> GetNextPage<T>(Paging<T> paging)
        {
            if (!paging.HasNextPage())
                throw new InvalidOperationException("This Paging-Object has no Next-Page");
            return DownloadData<Paging<T>>(paging.Next);
        }

        public async Task<Paging<T>> GetNextPageAsync<T>(Paging<T> paging)
        {
            if (!paging.HasNextPage())
                throw new InvalidOperationException("This Paging-Object has no Next-Page");
            return await DownloadDataAsync<Paging<T>>(paging.Next);
        }

        public Paging<T> GetPreviousPage<T>(Paging<T> paging)
        {
            if (!paging.HasPreviousPage())
                throw new InvalidOperationException("This Paging-Object has no Previous-Page");
            return DownloadData<Paging<T>>(paging.Previous);
        }

        public async Task<Paging<T>> GetPreviousPageAsync<T>(Paging<T> paging)
        {
            if (!paging.HasPreviousPage())
                throw new InvalidOperationException("This Paging-Object has no Previous-Page");
            return await DownloadDataAsync<Paging<T>>(paging.Previous);
        }

        public T UploadData<T>(string url, string uploadData, string method = "POST")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for all Upload-Actions");
            WebClient.SetHeader("Authorization", TokenType + " " + AccessToken);
            WebClient.SetHeader("Content-Type", "application/json");
            return WebClient.UploadJson<T>(url, uploadData, method);
        }

        public Task<T> UploadDataAsync<T>(string url, string uploadData, string method = "POST")
        {
            if (!UseAuth)
                throw new InvalidOperationException("Auth is required for all Upload-Actions");
            WebClient.SetHeader("Authorization", TokenType + " " + AccessToken);
            WebClient.SetHeader("Content-Type", "application/json");
            return WebClient.UploadJsonAsync<T>(url, uploadData, method);
        }

        public T DownloadData<T>(string url)
        {
            if (UseAuth)
                WebClient.SetHeader("Authorization", TokenType + " " + AccessToken);
            else
                WebClient.RemoveHeader("Authorization");
            return WebClient.DownloadJson<T>(url);
        }

        public Task<T> DownloadDataAsync<T>(string url)
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