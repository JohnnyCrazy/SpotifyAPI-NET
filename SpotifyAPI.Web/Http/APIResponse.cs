namespace SpotifyAPI.Web.Http
{
  public class APIResponse<T> : IAPIResponse<T>
  {
    public APIResponse(IResponse response, T body = default(T))
    {
      Ensure.ArgumentNotNull(response, nameof(response));

      Body = body;
      Response = response;
    }

    public T Body { get; set; }

    public IResponse Response { get; set; }
  }
}
