using System;

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
    public static void ArgumentNotNull(object value, string name)
    {
      if (value != null)
      {
        return;
      }

      throw new ArgumentNullException(name);
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

    public static void PropertyNotNull(object value, string name, string additional = null)
    {
      if (value != null)
      {
        return;
      }

      throw new InvalidOperationException($"The property {name} is null{additional}");
    }
  }
}
