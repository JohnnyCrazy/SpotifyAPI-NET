using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace SpotifyAPI.Web
{
  public abstract class RequestParams
  {
    private static readonly ConcurrentDictionary<Type, List<(PropertyInfo, BodyParamAttribute)>> _bodyParamsCache =
      new();

    public JObject BuildBodyParams()
    {
      // Make sure everything is okay before building body params
      CustomEnsure();

      var body = new JObject();
      var type = GetType();

      if (!_bodyParamsCache.IsEmpty && _bodyParamsCache.TryGetValue(type, out var bodyParamsCached))
      {
        foreach (var (info, attribute) in bodyParamsCached)
        {
          AddBodyParam(body, info, attribute);
        }
      }
      else
      {
        var bodyProps = GetType()
          .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
          .Where(prop => prop.GetCustomAttributes(typeof(BodyParamAttribute), true).Length > 0);

        var cachedParams = new List<(PropertyInfo, BodyParamAttribute)>();
        foreach (var prop in bodyProps)
        {
          var attribute = prop.GetCustomAttribute<BodyParamAttribute>();
          if (attribute != null)
          {
            cachedParams.Add((prop, attribute));
            AddBodyParam(body, prop, attribute);
          }
        }
        _bodyParamsCache[type] = cachedParams;
      }

      return body;
    }

    private void AddBodyParam(JObject body, PropertyInfo prop, BodyParamAttribute attribute)
    {
      object? value = prop.GetValue(this);
      if (value != null)
      {
        body[attribute.Key ?? prop.Name] = JToken.FromObject(value);
      }
    }

    private static readonly ConcurrentDictionary<Type, List<(PropertyInfo, QueryParamAttribute)>> _queryParamsCache =
      new();

    public Dictionary<string, string> BuildQueryParams()
    {
      // Make sure everything is okay before building query params
      CustomEnsure();

      var queryParams = new Dictionary<string, string>();
      var type = GetType();

      if (!_queryParamsCache.IsEmpty && _queryParamsCache.TryGetValue(type, out var queryParamsCached))
      {
        foreach (var (info, attribute) in queryParamsCached)
        {
          AddQueryParam(queryParams, info, attribute);
        }
      }
      else
      {
        var queryProps = GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
        .Where(prop => prop.GetCustomAttributes(typeof(QueryParamAttribute), true).Length > 0);

        var cachedParams = new List<(PropertyInfo, QueryParamAttribute)>();
        foreach (var prop in queryProps)
        {
          var attribute = prop.GetCustomAttribute<QueryParamAttribute>();
          if (attribute != null)
          {
            cachedParams.Add((prop, attribute));
            AddQueryParam(queryParams, prop, attribute);
          }
        }
        _queryParamsCache[type] = cachedParams;
      }

      AddCustomQueryParams(queryParams);

      return queryParams;
    }

    private void AddQueryParam(Dictionary<string, string> queryParams, PropertyInfo prop, QueryParamAttribute attribute)
    {
      object? value = prop.GetValue(this);
      if (value != null)
      {
        if (value is IList<string> list)
        {
          if (list.Count > 0)
          {
            var str = string.Join(",", list);
            queryParams.Add(attribute.Key ?? prop.Name, str);
          }
        }
        else if (value is bool valueAsBool)
        {
          queryParams.Add(attribute.Key ?? prop.Name, valueAsBool ? "true" : "false");
        }
        else if (value is Enum valueAsEnum)
        {
          var enumType = valueAsEnum.GetType();
          var valueList = new List<string>();

          if (enumType.IsDefined(typeof(FlagsAttribute), false))
          {
            foreach (Enum enumVal in Enum.GetValues(valueAsEnum.GetType()))
            {
              if (valueAsEnum.HasFlag(enumVal))
              {
                if (StringAttribute.GetValue(enumType, enumVal, out var stringVal))
                {
                  // .netstandard2.0 requires !
                  valueList.Add(stringVal!);
                }
              }
            }
          }
          else
          {
            if (StringAttribute.GetValue(enumType, valueAsEnum, out var stringVal))
            {
              // .netstandard2.0 requires !
              valueList.Add(stringVal!);
            }
          }
          queryParams.Add(attribute.Key ?? prop.Name, string.Join(",", valueList));
        }
        else
        {
          queryParams.Add(attribute.Key ?? prop.Name, value.ToString() ?? throw new APIException("ToString returned null for query parameter"));
        }
      }
    }

    protected virtual void CustomEnsure() { }
    protected virtual void AddCustomQueryParams(Dictionary<string, string> queryParams) { }
  }

  [AttributeUsage(AttributeTargets.Property)]
  public sealed class QueryParamAttribute : Attribute
  {
    public string Key { get; }

    public QueryParamAttribute(string key)
    {
      Key = key;
    }
  }

  [AttributeUsage(AttributeTargets.Property)]
  public sealed class BodyParamAttribute : Attribute
  {
    public string Key { get; }

    public BodyParamAttribute(string key)
    {
      Key = key;
    }
  }
}

