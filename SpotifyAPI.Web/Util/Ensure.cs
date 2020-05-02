using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotifyAPI.Web
{
  /// <summary>
  ///   Ensure input parameters
  /// </summary>
  internal static class Ensure
  {
    /// <summary>
    ///   Checks an argument to ensure it isn't null.
    /// </summary>
    /// <param name = "value">The argument value to check</param>
    /// <param name = "name">The name of the argument</param>
    /// <param name = "additional">Additional Exception Text</param>
    public static void ArgumentNotNull(object value, string name, string additional = null)
    {
      if (value != null)
      {
        return;
      }

      throw new ArgumentNullException($"{name}{additional}");
    }

    /// <summary>
    ///   Checks an argument to ensure it isn't null or an empty string
    /// </summary>
    /// <param name = "value">The argument value to check</param>
    /// <param name = "name">The name of the argument</param>
    public static void ArgumentNotNullOrEmptyString(string value, string name)
    {
      if (!string.IsNullOrEmpty(value))
      {
        return;
      }

      throw new ArgumentException("String is empty or null", name);
    }

    public static void ArgumentNotNullOrEmptyList<T>(List<T> value, string name)
    {
      if (value != null && value.Any())
      {
        return;
      }

      throw new ArgumentException("List is empty or null", name);
    }
  }
}
