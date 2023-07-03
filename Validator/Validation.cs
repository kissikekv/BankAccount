using System.Text.RegularExpressions;

namespace Validation
{
    public static class Validator
    {
        public static bool NullEqualValidator(object? value)
        {
            if (value.Equals(null))
            {
                throw new ArgumentNullException(nameof(value));
            }
            return true;
        }

        public static bool NameValidator(string? name)
        {
            NullEqualValidator(name);
            string pattern = @"\d+";
            if (Regex.IsMatch(pattern, name))
            {
                throw new ArgumentException(nameof(name));
            }
            return true;
        }

        public static bool AccountNumberValidator(string? accountNumber)
        {
            NullEqualValidator(accountNumber);
            string pattern = @"^\d{4}\s{1}\d{4}\s{1}\d{4}\s{1}\d{4}$";
            if (!Regex.IsMatch(pattern, accountNumber))
            {
                throw new ArgumentException(nameof(accountNumber));
            }
            return true;
        }

        public static void ValidateFilePath(string filePath)
        {
            try
            {
                UriBuilder uriBuilder = new UriBuilder();
                uriBuilder.Scheme = Uri.UriSchemeFile;
                uriBuilder.Path = filePath;

                bool isValid = Uri.TryCreate(uriBuilder.Uri.ToString(), UriKind.Absolute, out Uri resultUri);
            }
            catch (UriFormatException)
            {
                throw new FormatException(message: "Invalid path format");
            }
        }
    }
}
