using System.Collections.Concurrent;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace SpotifyAPI.Web
{
  public abstract class RequestParams
  {
    private static readonly ConcurrentDictionary<PropertyInfo, BodyParamAttribute> _bodyParamsCache =
      new ConcurrentDictionary<PropertyInfo, BodyParamAttribute>();
    public JObject BuildBodyParams()
    {
      // Make sure everything is okay before building body params
      CustomEnsure();

      var body = new JObject();
      if (!_bodyParamsCache.IsEmpty)
      {
        foreach (var bodyParam in _bodyParamsCache)
        {
          AddBodyParam(body, bodyParam.Key, bodyParam.Value);
        }
      }
      else
      {
        var bodyProps = GetType()
          .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
          .Where(prop => prop.GetCustomAttributes(typeof(BodyParamAttribute), true).Length > 0);

        foreach (var prop in bodyProps)
        {
          var attribute = (BodyParamAttribute)prop.GetCustomAttribute(typeof(BodyParamAttribute));
          _bodyParamsCache[prop] = attribute;
          AddBodyParam(body, prop, attribute);
        }
      }

      return body;
    }

    private void AddBodyParam(JObject body, PropertyInfo prop, BodyParamAttribute attribute)
    {
      object value = prop.GetValue(this);
      if (value != null)
      {
        body[attribute.Key ?? prop.Name] = JToken.FromObject(value);
      }
    }

    private static readonly ConcurrentDictionary<PropertyInfo, QueryParamAttribute> _queryParamsCache =
      new ConcurrentDictionary<PropertyInfo, QueryParamAttribute>();
    public Dictionary<string, string> BuildQueryParams()
    {
      // Make sure everything is okay before building query params
      CustomEnsure();

      var queryParams = new Dictionary<string, string>();

      if (!_queryParamsCache.IsEmpty)
      {
        foreach (var queryParam in _queryParamsCache)
        {
          AddQueryParam(queryParams, queryParam.Key, queryParam.Value);
        }
      }
      else
      {
        var queryProps = GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
        .Where(prop => prop.GetCustomAttributes(typeof(QueryParamAttribute), true).Length > 0);

        foreach (var prop in queryProps)
        {
          var attribute = (QueryParamAttribute)prop.GetCustomAttribute(typeof(QueryParamAttribute));
          _queryParamsCache[prop] = attribute;
          AddQueryParam(queryParams, prop, attribute);
        }
      }

      AddCustomQueryParams(queryParams);

      return queryParams;
    }

    private void AddQueryParam(Dictionary<string, string> queryParams, PropertyInfo prop, QueryParamAttribute attribute)
    {
      object value = prop.GetValue(this);
      if (value != null)
      {
        if (value is IList<string> list && list.Count > 0)
        {
          var str = string.Join(",", list);
          queryParams.Add(attribute.Key ?? prop.Name, str);
        }
        else if (value is Enum valueAsEnum)
        {
          var enumType = valueAsEnum.GetType();
          var valueList = new List<string>();

          foreach (Enum enumVal in Enum.GetValues(valueAsEnum.GetType()))
          {
            if (valueAsEnum.HasFlag(enumVal))
            {
              if (enumType
                .GetMember(enumVal.ToString())[0]
                .GetCustomAttributes(typeof(StringAttribute))
                .FirstOrDefault() is StringAttribute stringAttr)
              {
                valueList.Add(stringAttr.Value);
              }
            }
          }
          queryParams.Add(attribute.Key ?? prop.Name, string.Join(",", valueList));
        }
        else
        {
          queryParams.Add(attribute.Key ?? prop.Name, value.ToString());
        }
      }
    }

    protected virtual void CustomEnsure() { }
    protected virtual void AddCustomQueryParams(Dictionary<string, string> queryParams) { }
  }

  [AttributeUsage(AttributeTargets.Property)]
  public class QueryParamAttribute : Attribute
  {
    public string Key { get; }

    public QueryParamAttribute(string key)
    {
      Key = key;
    }
  }

  [AttributeUsage(AttributeTargets.Property)]
  public class BodyParamAttribute : Attribute
  {
    public string Key { get; }

    public BodyParamAttribute(string key)
    {
      Key = key;
    }
  }
}

