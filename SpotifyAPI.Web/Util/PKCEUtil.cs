using System;
using System.Security.Cryptography;
using System.Text;

namespace SpotifyAPI.Web
{
  public static class PKCEUtil
  {
    private const int VERIFY_MIN_LENGTH = 43;
    private const int VERIFY_MAX_LENGTH = 128;
    private const int VERIFY_DEFAULT_LENGTH = 100;

    /// <summary>
    ///   Generate a verifier and challenge pair using RNGCryptoServiceProvider
    /// </summary>
    /// <param name="length">The length of the generated verifier</param>
    /// <returns></returns>
    public static (string verifier, string challenge) GenerateCodes(int length = VERIFY_DEFAULT_LENGTH)
    {
      if (length < VERIFY_MIN_LENGTH || length > VERIFY_MAX_LENGTH)
      {
        throw new ArgumentException(
          $"length must be between {VERIFY_MIN_LENGTH} and {VERIFY_MAX_LENGTH}",
          nameof(length)
        );
      }

      var verifier = GenerateRandomURLSafeString(length);
      return GenerateCodes(verifier);
    }

    /// <summary>
    /// Return the paseed verifier and its challenge
    /// </summary>
    /// <param name="verifier">A secure random generated verifier</param>
    /// <returns></returns>
    public static (string verifier, string challenge) GenerateCodes(string verifier)
    {
      Ensure.ArgumentNotNull(verifier, nameof(verifier));

      if (verifier.Length < VERIFY_MIN_LENGTH || verifier.Length > VERIFY_MAX_LENGTH)
      {
        throw new ArgumentException(
          $"length must be between {VERIFY_MIN_LENGTH} and {VERIFY_MAX_LENGTH}",
          nameof(verifier)
        );
      }

      var challenge = Base64Util.UrlEncode(ComputeSHA256(verifier));
      return (verifier, challenge);
    }

    private static string GenerateRandomURLSafeString(int length)
    {
      var bit_count = length * 6;
      var byte_count = (bit_count + 7) / 8; // rounded up
      var bytes = new byte[byte_count];

      using var generator = RandomNumberGenerator.Create();
      generator.GetBytes(bytes);
      return Base64Util.UrlEncode(bytes);
    }

    private static byte[] ComputeSHA256(string value)
    {
      using var hash = SHA256.Create();
      return hash.ComputeHash(Encoding.UTF8.GetBytes(value));
    }
  }
}
