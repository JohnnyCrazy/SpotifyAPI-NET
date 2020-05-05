namespace SpotifyAPI.Web
{
  public class PlaylistReorderItemsRequest : RequestParams
  {
    public PlaylistReorderItemsRequest(int rangeStart, int insertBefore)
    {
      RangeStart = rangeStart;
      InsertBefore = insertBefore;
    }

    [BodyParam("range_start")]
    public int RangeStart { get; set; }

    [BodyParam("insert_before")]
    public int InsertBefore { get; set; }

    [BodyParam("range_length")]
    public int? RangeLength { get; set; }

    [BodyParam("snapshot_id")]
    public string SnapshotId { get; set; }
  }
}
