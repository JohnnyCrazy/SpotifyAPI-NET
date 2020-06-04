namespace SpotifyAPI.Web
{
  public class CategoriesResponse
  {
    public Paging<Category, CategoriesResponse> Categories { get; set; } = default!;
  }
}

