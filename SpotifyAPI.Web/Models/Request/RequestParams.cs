using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
namespace SpotifyAPI.Web
{
  public abstract class RequestParams
  {
    public Dictionary<string, string> BuildQueryParams()
    {
      // Make sure everything is okay before building query params
      Ensure();

      var queryProps = GetType().GetProperties()
        .Where(prop => prop.GetCustomAttributes(typeof(QueryParamAttribute), true).Length > 0);

      var queryParams = new Dictionary<string, string>();
      foreach (var prop in queryProps)
      {
        var attribute = prop.GetCustomAttribute(typeof(QueryParamAttribute)) as QueryParamAttribute;
        object value = prop.GetValue(this);
        if (value != null)
        {
          queryParams.Add(attribute.Key ?? prop.Name, value.ToString());
        }
      }

      AddCustomQueryParams(queryParams);

      return queryParams;
    }

    protected virtual void Ensure() { }
    protected virtual void AddCustomQueryParams(Dictionary<string, string> queryParams) { }
  }

  public class QueryParamAttribute : Attribute
  {
    public string Key { get; set; }

    public QueryParamAttribute() { }
    public QueryParamAttribute(string key)
    {
      Key = key;
    }
  }

  public class BodyParamAttribute : Attribute
  {
    public BodyParamAttribute() { }
  }
}
