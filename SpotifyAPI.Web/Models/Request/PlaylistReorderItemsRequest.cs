namespace SpotifyAPI.Web
{
  public class PlaylistReorderItemsRequest : RequestParams
  {
    [BodyParam("range_start")]
    public int? RangeStart { get; set; }

    [BodyParam("insert_before")]
    public int? InsertBefore { get; set; }

    [BodyParam("range_length")]
    public int? RangeLength { get; set; }

    [BodyParam("snapshot_id")]
    public string SnapshotId { get; set; }

    protected override void CustomEnsure()
    {
      Ensure.ArgumentNotNull(RangeStart, nameof(RangeStart));
      Ensure.ArgumentNotNull(InsertBefore, nameof(InsertBefore));
    }
  }
}
