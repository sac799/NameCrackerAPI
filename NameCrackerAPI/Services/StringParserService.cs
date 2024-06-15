using NameCrackerAPI.Interfaces;
using NameCrackerAPI.Models;

namespace NameCrackerAPI.Services
{
    public class StringParserService : IStringParserService
    {
        public ParsedString ParseFullString(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty or null.");
            }

            string[] nameParts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length < 2)
            {
                throw new ArgumentException("Full name is not properly formatted.");
            }

            ParsedString parsedName = new ParsedString();

            // Check if first part is a valid title
            int nameStartIndex = 0;
            if (IsTitle(nameParts[0]))
            {
                parsedName.Title = nameParts[0];
                nameStartIndex = 1;
            }

            // Set forename
            parsedName.Forename = nameParts[nameStartIndex];

            // Determine where last name starts
            int lastNameIndex = nameParts.Length - 1;
            int middleNameStartIndex = nameStartIndex + 1;

            if (middleNameStartIndex < lastNameIndex)
            {
                parsedName.MiddleName = string.Join(" ", nameParts, middleNameStartIndex, lastNameIndex - middleNameStartIndex);
            }

            parsedName.Surname = nameParts[lastNameIndex];

            return parsedName;
        }

        private bool IsTitle(string part)
        {
            string[] validTitles = { "Mr.", "Mr", "Mrs.", "Mrs", "Ms.", "Ms", "Miss", "Dr.", "Dr", "Prof.", "Prof" };
            return Array.Exists(validTitles, title => title.Equals(part, StringComparison.OrdinalIgnoreCase));
        }
    }
}
