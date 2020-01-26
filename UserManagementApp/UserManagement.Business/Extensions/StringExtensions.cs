using System;
using System.IO;
using System.Linq;

namespace UserManagement.Business.Extensions
{
    public static class StringExtensions
    {
        public static string ValidateNotEmpty(this string value, string nameOf = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameOf);
            }

            return value;
        }
        public static string CombineUri(this string uri, string relativeUri)
        {
            relativeUri.ValidateNotEmpty();

            uri = uri.Replace("/", "\\").Trim(new[] { '\\' });
            relativeUri = relativeUri.Replace("/", "\\").Trim(new[] { '\\' });

            return Path.Combine(uri, relativeUri).Replace("/", "\\").TrimEnd(new[] { '\\' });
        }

        public static string CombineUri(this string uri, string[] relativeUris)
        {
            var forwardSlash = new[] { '/' };

            var uris = relativeUris.Select(u => u.TrimStart(forwardSlash)).ToArray();

            var result = uri.Replace("/", "\\").Trim(new[] { '\\' });
            result = Path.Combine(result, Path.Combine(uris));

            return result.Replace("/", "\\").TrimEnd(new[] { '\\' });
        }
    }
}
