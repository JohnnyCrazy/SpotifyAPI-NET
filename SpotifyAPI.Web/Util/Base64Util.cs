
using System;
using System.Globalization;

namespace SpotifyAPI.Web
{
  internal class Base64Util
  {
    internal const string WebEncoders_InvalidCountOffsetOrLength = "Invalid {0}, {1} or {2} length.";
    internal const string WebEncoders_MalformedInput = "Malformed input: {0} is an invalid input length.";

    public static string UrlEncode(byte[] input)
    {
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      // Special-case empty input
      if (input.Length == 0)
      {
        return string.Empty;
      }

      var buffer = new char[GetArraySizeRequiredToEncode(input.Length)];
      var numBase64Chars = Convert.ToBase64CharArray(input, 0, input.Length, buffer, 0);

      // Fix up '+' -> '-' and '/' -> '_'. Drop padding characters.
      for (var i = 0; i < numBase64Chars; i++)
      {
        var ch = buffer[i];
        if (ch == '+')
        {
          buffer[i] = '-';
        }
        else if (ch == '/')
        {
          buffer[i] = '_';
        }
        else if (ch == '=')
        {
          return new string(buffer, startIndex: 0, length: i);
        }
      }

      return new string(buffer, startIndex: 0, length: numBase64Chars);
    }

    public static byte[] UrlDecode(string input)
    {
      var buffer = new char[GetArraySizeRequiredToDecode(input.Length)];
      if (input == null)
      {
        throw new ArgumentNullException(nameof(input));
      }

      // Assumption: input is base64url encoded without padding and contains no whitespace.

      var paddingCharsToAdd = GetNumBase64PaddingCharsToAddForDecode(input.Length);
      var arraySizeRequired = checked(input.Length + paddingCharsToAdd);

      // Copy input into buffer, fixing up '-' -> '+' and '_' -> '/'.
      var i = 0;
      for (var j = 0; i < input.Length; i++, j++)
      {
        var ch = input[j];
        if (ch == '-')
        {
          buffer[i] = '+';
        }
        else if (ch == '_')
        {
          buffer[i] = '/';
        }
        else
        {
          buffer[i] = ch;
        }
      }

      // Add the padding characters back.
      for (; paddingCharsToAdd > 0; i++, paddingCharsToAdd--)
      {
        buffer[i] = '=';
      }

      // Decode.
      // If the caller provided invalid base64 chars, they'll be caught here.
      return Convert.FromBase64CharArray(buffer, 0, arraySizeRequired);
    }

    private static int GetArraySizeRequiredToEncode(int count)
    {
      var numWholeOrPartialInputBlocks = checked(count + 2) / 3;
      return checked(numWholeOrPartialInputBlocks * 4);
    }

    private static int GetArraySizeRequiredToDecode(int count)
    {
      if (count < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(count));
      }

      if (count == 0)
      {
        return 0;
      }

      var numPaddingCharsToAdd = GetNumBase64PaddingCharsToAddForDecode(count);

      return checked(count + numPaddingCharsToAdd);
    }

    private static int GetNumBase64PaddingCharsToAddForDecode(int inputLength)
    {
      switch (inputLength % 4)
      {
        case 0:
          return 0;
        case 2:
          return 2;
        case 3:
          return 1;
        default:
          throw new FormatException(
              string.Format(
                  CultureInfo.CurrentCulture,
                  WebEncoders_MalformedInput,
                  inputLength));
      }
    }
  }


}
