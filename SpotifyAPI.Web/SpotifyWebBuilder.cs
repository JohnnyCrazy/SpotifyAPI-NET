using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyAPI.Web
{
    /// <summary>
    /// SpotifyAPI URL-Generator
    /// </summary>
    public class SpotifyWebBuilder
    {
        public const string APIBase = "https://api.spotify.com/v1";

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
        public string SearchItems(string q, SearchType type, int limit = 20, int offset = 0, string market = "")
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder(APIBase + "/search");
            builder.Append("?q=" + q);
            builder.Append("&type=" + type.GetStringAttribute(","));
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
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
        public string GetAlbumTracks(string id, int limit = 20, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/albums/" + id + "/tracks");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        /// <summary>
        ///     Get Spotify catalog information for a single album.
        /// </summary>
        /// <param name="id">The Spotify ID for the album.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public string GetAlbum(string id, string market = "")
        {
            return string.IsNullOrEmpty(market) ? $"{APIBase}/albums/{id}" : $"{APIBase}/albums/{id}?market={market}";
        }

        /// <summary>
        ///     Get Spotify catalog information for multiple albums identified by their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the albums. Maximum: 20 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public string GetSeveralAlbums(List<string> ids, string market = "")
        {
            return string.IsNullOrEmpty(market)
                ? $"{APIBase}/albums?ids={string.Join(",", ids.Take(20))}"
                : $"{APIBase}/albums?market={market}&ids={string.Join(",", ids.Take(20))}";
        }

        #endregion Albums

        #region Artists

        /// <summary>
        ///     Get Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public string GetArtist(string id)
        {
            return $"{APIBase}/artists/{id}";
        }

        /// <summary>
        ///     Get Spotify catalog information about artists similar to a given artist. Similarity is based on analysis of the
        ///     Spotify community’s listening history.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <returns></returns>
        public string GetRelatedArtists(string id)
        {
            return $"{APIBase}/artists/{id}/related-artists";
        }

        /// <summary>
        ///     Get Spotify catalog information about an artist’s top tracks by country.
        /// </summary>
        /// <param name="id">The Spotify ID for the artist.</param>
        /// <param name="country">The country: an ISO 3166-1 alpha-2 country code.</param>
        /// <returns></returns>
        public string GetArtistsTopTracks(string id, string country)
        {
            return $"{APIBase}/artists/{id}/top-tracks?country={country}";
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
        public string GetArtistsAlbums(string id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/artists/" + id + "/albums");
            builder.Append("?album_type=" + type.GetStringAttribute(","));
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        /// <summary>
        ///     Get Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the artists. Maximum: 50 IDs.</param>
        /// <returns></returns>
        public string GetSeveralArtists(List<string> ids)
        {
            return $"{APIBase}/artists?ids={string.Join(",", ids.Take(50))}";
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
        public string GetFeaturedPlaylists(string locale = "", string country = "", DateTime timestamp = default(DateTime), int limit = 20, int offset = 0)
        {
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/browse/featured-playlists");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(locale))
                builder.Append("&locale=" + locale);
            if (!string.IsNullOrEmpty(country))
                builder.Append("&country=" + country);
            if (timestamp != default(DateTime))
                builder.Append("&timestamp=" + timestamp.ToString("yyyy-MM-ddTHH:mm:ss"));
            return builder.ToString();
        }

        /// <summary>
        ///     Get a list of new album releases featured in Spotify (shown, for example, on a Spotify player’s “Browse” tab).
        /// </summary>
        /// <param name="country">A country: an ISO 3166-1 alpha-2 country code.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first item to return. Default: 0</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetNewAlbumReleases(string country = "", int limit = 20, int offset = 0)
        {
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/browse/new-releases");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(country))
                builder.Append("&country=" + country);
            return builder.ToString();
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
        public string GetCategories(string country = "", string locale = "", int limit = 20, int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder(APIBase + "/browse/categories");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(country))
                builder.Append("&country=" + country);
            if (!string.IsNullOrEmpty(locale))
                builder.Append("&locale=" + locale);
            return builder.ToString();
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
        public string GetCategory(string categoryId, string country = "", string locale = "")
        {
            StringBuilder builder = new StringBuilder(APIBase + "/browse/categories/" + categoryId);
            if (!string.IsNullOrEmpty(country))
                builder.Append("?country=" + country);
            if (!string.IsNullOrEmpty(locale))
                builder.Append((country == "" ? "?locale=" : "&locale=") + locale);
            return builder.ToString();
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
        public string GetCategoryPlaylists(string categoryId, string country = "", int limit = 20, int offset = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder(APIBase + "/browse/categories/" + categoryId + "/playlists");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(country))
                builder.Append("&country=" + country);
            return builder.ToString();
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
        public string GetRecommendations(List<string> artistSeed = null, List<string> genreSeed = null, List<string> trackSeed = null,
            TuneableTrack target = null, TuneableTrack min = null, TuneableTrack max = null, int limit = 20, string market = "")
        {
            limit = Math.Min(100, limit);
            StringBuilder builder = new StringBuilder($"{APIBase}/recommendations");
            builder.Append("?limit=" + limit);
            if (artistSeed?.Count > 0)
                builder.Append("&seed_artists=" + string.Join(",", artistSeed));
            if (genreSeed?.Count > 0)
                builder.Append("&seed_genres=" + string.Join(",", genreSeed));
            if (trackSeed?.Count > 0)
                builder.Append("&seed_tracks=" + string.Join(",", trackSeed));
            if (target != null)
                builder.Append(target.BuildUrlParams("target"));
            if (min != null)
                builder.Append(min.BuildUrlParams("min"));
            if (max != null)
                builder.Append(max.BuildUrlParams("max"));
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        /// <summary>
        ///     Retrieve a list of available genres seed parameter values for recommendations.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetRecommendationSeedsGenres()
        {
            return $"{APIBase}/recommendations/available-genre-seeds";
        }

        #endregion Browse

        #region Follow

        /// <summary>
        ///     Get the current user’s followed artists.
        /// </summary>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">The last artist ID retrieved from the previous request.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetFollowedArtists(int limit = 20, string after = "")
        {
            limit = Math.Min(limit, 50);
            const FollowType followType = FollowType.Artist; //currently only artist is supported.
            StringBuilder builder = new StringBuilder(APIBase + "/me/following?type=" + followType.GetStringAttribute());
            builder.Append("&limit=" + limit);
            if (!string.IsNullOrEmpty(after))
                builder.Append("&after=" + after);
            return builder.ToString();
        }

        /// <summary>
        ///     Add the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string Follow(FollowType followType)
        {
            return $"{APIBase}/me/following?type={followType.GetStringAttribute()}";
        }

        /// <summary>
        ///     Remove the current user as a follower of one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string Unfollow(FollowType followType)
        {
            return $"{APIBase}/me/following?type={followType.GetStringAttribute()}";
        }

        /// <summary>
        ///     Check to see if the current user is following one or more artists or other Spotify users.
        /// </summary>
        /// <param name="followType">The ID type: either artist or user.</param>
        /// <param name="ids">A list of the artist or the user Spotify IDs to check</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string IsFollowing(FollowType followType, List<string> ids)
        {
            return $"{APIBase}/me/following/contains?type={followType.GetStringAttribute()}&ids={string.Join(",", ids)}";
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
        public string FollowPlaylist(string ownerId, string playlistId, bool showPublic = true)
        {
            return $"{APIBase}/users/{ownerId}/playlists/{playlistId}/followers";
        }

        /// <summary>
        ///     Remove the current user as a follower of a playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist that is to be no longer followed.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string UnfollowPlaylist(string ownerId, string playlistId)
        {
            return $"{APIBase}/users/{ownerId}/playlists/{playlistId}/followers";
        }

        /// <summary>
        ///     Check to see if one or more Spotify users are following a specified playlist.
        /// </summary>
        /// <param name="ownerId">The Spotify user ID of the person who owns the playlist.</param>
        /// <param name="playlistId">The Spotify ID of the playlist.</param>
        /// <param name="ids">A list of Spotify User IDs</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string IsFollowingPlaylist(string ownerId, string playlistId, List<string> ids)
        {
            return $"{APIBase}/users/{ownerId}/playlists/{playlistId}/followers/contains?ids={string.Join(",", ids)}";
        }

        #endregion Follow

        #region Library

        /// <summary>
        ///     Save one or more tracks to the current user’s “Your Music” library.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string SaveTracks()
        {
            return APIBase + "/me/tracks/";
        }

        /// <summary>
        ///     Get a list of the songs saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetSavedTracks(int limit = 20, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/me/tracks");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        /// <summary>
        ///     Remove one or more tracks from the current user’s “Your Music” library.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string RemoveSavedTracks()
        {
            return APIBase + "/me/tracks/";
        }

        /// <summary>
        ///     Check if one or more tracks is already saved in the current Spotify user’s “Your Music” library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string CheckSavedTracks(List<string> ids)
        {
            return APIBase + "/me/tracks/contains?ids=" + string.Join(",", ids);
        }

        /// <summary>
        ///     Save one or more albums to the current user’s "Your Music" library.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string SaveAlbums()
        {
            return $"{APIBase}/me/albums";
        }

        /// <summary>
        ///     Get a list of the albums saved in the current Spotify user’s "Your Music" library.
        /// </summary>
        /// <param name="limit">The maximum number of objects to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <param name="offset">The index of the first object to return. Default: 0 (i.e., the first object)</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetSavedAlbums(int limit = 20, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/me/albums");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        /// <summary>
        ///     Remove one or more albums from the current user’s "Your Music" library.
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string RemoveSavedAlbums()
        {
            return APIBase + "/me/albums/";
        }

        /// <summary>
        ///     Check if one or more albums is already saved in the current Spotify user’s "Your Music" library.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string CheckSavedAlbums(List<string> ids)
        {
            return APIBase + "/me/albums/contains?ids=" + string.Join(",", ids);
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
        public string GetUsersTopTracks(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder($"{APIBase}/me/top/tracks");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offest);
            builder.Append("&time_range=" + timeRange.GetStringAttribute());
            return builder.ToString();
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
        public string GetUsersTopArtists(TimeRangeType timeRange = TimeRangeType.MediumTerm, int limit = 20, int offest = 0)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder($"{APIBase}/me/top/artists");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offest);
            builder.Append("&time_range=" + timeRange.GetStringAttribute());
            return builder.ToString();
        }

        /// <summary>
        ///     Get tracks from the current user’s recent play history.
        /// </summary>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50. </param>
        /// <param name="after">A Unix timestamp in milliseconds. Returns all items after (but not including) this cursor position. If after is specified, before must not be specified.</param>
        /// <param name="before">A Unix timestamp in milliseconds. Returns all items before (but not including) this cursor position. If before is specified, after must not be specified.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetUsersRecentlyPlayedTracks(int limit = 20, DateTime? after = null, DateTime? before = null)
        {
            limit = Math.Min(50, limit);
            StringBuilder builder = new StringBuilder($"{APIBase}/me/player/recently-played");
            builder.Append("?limit=" + limit);
            if (after.HasValue)
                builder.Append("&after=" + after.Value.ToUnixTimeMillisecondsPoly());
            if (before.HasValue)
                builder.Append("&before=" + before.Value.ToUnixTimeMillisecondsPoly());
            return builder.ToString();
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
        public string GetUserPlaylists(string userId, int limit = 20, int offset = 0)
        {
            limit = Math.Min(limit, 50);
            StringBuilder builder = new StringBuilder(APIBase + "/users/" + userId + "/playlists");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            return builder.ToString();
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
        public string GetPlaylist(string userId, string playlistId, string fields = "", string market = "")
        {
            StringBuilder builder = new StringBuilder(APIBase + "/users/" + userId + "/playlists/" + playlistId);
            builder.Append("?fields=" + fields);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        /// <summary>
        ///     Get a playlist owned by a Spotify user.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="fields">
        ///     Filters for the query: a comma-separated list of the fields to return. If omitted, all fields are
        ///     returned.
        /// </param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetPlaylist(string playlistId, string fields = "", string market = "")
        {
            StringBuilder builder = new StringBuilder(APIBase + "/playlists/" + playlistId);
            builder.Append("?fields=" + fields);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
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
        public string GetPlaylistTracks(string userId, string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 100);
            StringBuilder builder = new StringBuilder(APIBase + "/users/" + userId + "/playlists/" + playlistId + "/tracks");
            builder.Append("?fields=" + fields);
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        /// <summary>
        ///     Get full details of the tracks of a playlist owned by a Spotify user.
        /// </summary>
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
        public string GetPlaylistTracks(string playlistId, string fields = "", int limit = 100, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 100);
            StringBuilder builder = new StringBuilder(APIBase + "/playlists/" + playlistId + "/tracks");
            builder.Append("?fields=" + fields);
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
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
        public string CreatePlaylist(string userId, string playlistName, bool isPublic = true)
        {
            return $"{APIBase}/users/{userId}/playlists";
        }

        /// <summary>
        ///     Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string UpdatePlaylist(string userId, string playlistId)
        {
            return $"{APIBase}/users/{userId}/playlists/{playlistId}";
        }

        /// <summary>
        ///     Change a playlist’s name and public/private state. (The user must, of course, own the playlist.)
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string UpdatePlaylist(string playlistId)
        {
            return $"{APIBase}/playlists/{playlistId}";
        }

        /// <summary>
        ///     Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string ReplacePlaylistTracks(string userId, string playlistId)
        {
            return $"{APIBase}/users/{userId}/playlists/{playlistId}/tracks";
        }

        /// <summary>
        ///     Replace all the tracks in a playlist, overwriting its existing tracks. This powerful request can be useful for
        ///     replacing tracks, re-ordering existing tracks, or clearing the playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string ReplacePlaylistTracks(string playlistId)
        {
            return $"{APIBase}/playlists/{playlistId}/tracks";
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
        public string RemovePlaylistTracks(string userId, string playlistId, List<DeleteTrackUri> uris)
        {
            return $"{APIBase}/users/{userId}/playlists/{playlistId}/tracks";
        }

        /// <summary>
        ///     Remove one or more tracks from a user’s playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">
        ///     array of objects containing Spotify URI strings (and their position in the playlist). A maximum of
        ///     100 objects can be sent at once.
        /// </param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string RemovePlaylistTracks(string playlistId, List<DeleteTrackUri> uris)
        {
            return $"{APIBase}/playlists/{playlistId}/tracks";
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
        public string AddPlaylistTracks(string userId, string playlistId, List<string> uris, int? position = null)
        {
            return position == null
                ? $"{APIBase}/users/{userId}/playlists/{playlistId}/tracks"
                : $"{APIBase}/users/{userId}/playlists/{playlistId}/tracks?position={position}";
        }

        /// <summary>
        ///     Add one or more tracks to a user’s playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">A list of Spotify track URIs to add</param>
        /// <param name="position">The position to insert the tracks, a zero-based index</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string AddPlaylistTracks(string playlistId, List<string> uris, int? position = null)
        {
            return position == null
                ? $"{APIBase}/playlists/{playlistId}/tracks"
                : $"{APIBase}/playlists/{playlistId}/tracks?position={position}";
        }

        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string ReorderPlaylist(string userId, string playlistId)
        {
            return $"{APIBase}/users/{userId}/playlists/{playlistId}/tracks";
        }
        
        /// <summary>
        ///     Reorder a track or a group of tracks in a playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string ReorderPlaylist(string playlistId)
        {
            return $"{APIBase}/playlists/{playlistId}/tracks";
        }

        /// <summary>
        ///     Upload an image for a playlist.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string UploadPlaylistImage(string userId, string playlistId)
        {
            return $"{APIBase}/users/{userId}/playlists/{playlistId}/images";
        }

        /// <summary>
        ///     Upload an image for a playlist.
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string UploadPlaylistImage(string playlistId)
        {
            return $"{APIBase}/playlists/{playlistId}/images";
        }

        #endregion Playlists

        #region Profiles

        /// <summary>
        ///     Get detailed profile information about the current user (including the current user’s username).
        /// </summary>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetPrivateProfile()
        {
            return $"{APIBase}/me";
        }

        /// <summary>
        ///     Get public profile information about a Spotify user.
        /// </summary>
        /// <param name="userId">The user's Spotify user ID.</param>
        /// <returns></returns>
        public string GetPublicProfile(string userId)
        {
            return $"{APIBase}/users/{userId}";
        }

        #endregion Profiles

        #region Tracks

        /// <summary>
        ///     Get Spotify catalog information for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of the Spotify IDs for the tracks. Maximum: 50 IDs.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public string GetSeveralTracks(List<string> ids, string market = "")
        {
            return string.IsNullOrEmpty(market)
                ? $"{APIBase}/tracks?ids={string.Join(",", ids.Take(50))}"
                : $"{APIBase}/tracks?market={market}&ids={string.Join(",", ids.Take(50))}";
        }

        /// <summary>
        ///     Get Spotify catalog information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public string GetTrack(string id, string market = "")
        {
            return string.IsNullOrEmpty(market) ? $"{APIBase}/tracks/{id}" : $"{APIBase}/tracks/{id}?market={market}";
        }

        /// <summary>
        ///     Get a detailed audio analysis for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetAudioAnalysis(string id)
        {
            return $"{APIBase}/audio-analysis/{id}";
        }

        /// <summary>
        ///     Get audio feature information for a single track identified by its unique Spotify ID.
        /// </summary>
        /// <param name="id">The Spotify ID for the track.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetAudioFeatures(string id)
        {
            return $"{APIBase}/audio-features/{id}";
        }

        /// <summary>
        ///     Get audio features for multiple tracks based on their Spotify IDs.
        /// </summary>
        /// <param name="ids">A list of Spotify Track-IDs. Maximum: 100 IDs.</param>
        /// <returns></returns>
        /// <remarks>AUTH NEEDED</remarks>
        public string GetSeveralAudioFeatures(List<string> ids)
        {
            return $"{APIBase}/audio-features?ids={string.Join(",", ids.Take(100))}";
        }

        #endregion Tracks

        #region Player

        /// <summary>
        ///     Get information about a user’s available devices.
        /// </summary>
        /// <returns></returns>
        public string GetDevices()
        {
            return $"{APIBase}/me/player/devices";
        }

        /// <summary>
        ///     Get information about the user’s current playback state, including track, track progress, and active device.
        /// </summary>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public string GetPlayback(string market = "")
        {
            return string.IsNullOrEmpty(market) ? $"{APIBase}/me/player" : $"{APIBase}/me/player?market={market}";
        }

        /// <summary>
        ///     Get the object currently being played on the user’s Spotify account.
        /// </summary>
        /// <param name="market">An ISO 3166-1 alpha-2 country code. Provide this parameter if you want to apply Track Relinking.</param>
        /// <returns></returns>
        public string GetPlayingTrack(string market = "")
        {
            return string.IsNullOrEmpty(market)
                ? $"{APIBase}/me/player/currently-playing"
                : $"{APIBase}/me/player/currently-playing?market={market}";
        }

        /// <summary>
        ///     Transfer playback to a new device and determine if it should start playing.
        /// </summary>
        /// <returns></returns>
        public string TransferPlayback()
        {
            return $"{APIBase}/me/player";
        }

        /// <summary>
        ///     Start a new context or resume current playback on the user’s active device.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string ResumePlayback(string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/play"
                : $"{APIBase}/me/player/play?device_id={deviceId}";
        }

        /// <summary>
        ///     Pause playback on the user’s account.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string PausePlayback(string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/pause"
                : $"{APIBase}/me/player/pause?device_id={deviceId}";
        }

        /// <summary>
        ///     Skips to next track in the user’s queue.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string SkipPlaybackToNext(string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/next"
                : $"{APIBase}/me/player/next?device_id={deviceId}";
        }

        /// <summary>
        ///     Skips to previous track in the user’s queue.
        ///     Note that this will ALWAYS skip to the previous track, regardless of the current track’s progress.
        ///     Returning to the start of the current track should be performed using the https://api.spotify.com/v1/me/player/seek endpoint.
        /// </summary>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string SkipPlaybackToPrevious(string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/previous"
                : $"{APIBase}/me/player/previous?device_id={deviceId}";
        }

        /// <summary>
        ///     Seeks to the given position in the user’s currently playing track.
        /// </summary>
        /// <param name="positionMs">The position in milliseconds to seek to. Must be a positive number. 
        /// Passing in a position that is greater than the length of the track will cause the player to start playing the next song.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string SeekPlayback(int positionMs, string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/seek?position_ms={positionMs}"
                : $"{APIBase}/me/player/seek?position_ms={positionMs}&device_id={deviceId}";
        }

        /// <summary>
        ///     Set the repeat mode for the user’s playback. Options are repeat-track, repeat-context, and off.
        /// </summary>
        /// <param name="repeatState">track, context or off.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string SetRepeatMode(RepeatState repeatState, string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/repeat?state={repeatState.GetStringAttribute()}"
                : $"{APIBase}/me/player/repeat?state={repeatState.GetStringAttribute()}&device_id={deviceId}";
        }

        /// <summary>
        ///     Set the volume for the user’s current playback device.
        /// </summary>
        /// <param name="volumePercent">Integer. The volume to set. Must be a value from 0 to 100 inclusive.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string SetVolume(int volumePercent, string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/volume?volume_percent={volumePercent}"
                : $"{APIBase}/me/player/volume?volume_percent={volumePercent}&device_id={deviceId}";
        }

        /// <summary>
        ///     Toggle shuffle on or off for user’s playback.
        /// </summary>
        /// <param name="shuffle">True of False.</param>
        /// <param name="deviceId">The id of the device this command is targeting. If not supplied, the user's currently active device is the target.</param>
        /// <returns></returns>
        public string SetShuffle(bool shuffle, string deviceId = "")
        {
            return string.IsNullOrEmpty(deviceId)
                ? $"{APIBase}/me/player/shuffle?state={shuffle}"
                : $"{APIBase}/me/player/shuffle?state={shuffle}&device_id={deviceId}";
        }
        #endregion
    }
}
