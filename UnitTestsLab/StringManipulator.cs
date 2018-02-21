using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsLab
{
    /// <summary>
    /// Performs basic operations on Strings.
    /// </summary>
    class StringManipulator
    {
        /// <summary>
        /// Removes leading and trailing whitespace.
        /// </summary>
        /// <param name="text">A string.</param>
        /// <returns>The given string with no whitespace in the front or back.</returns>
        public String Trim(String text)
        {
            int leading = 0;
            while (leading < text.Length && char.IsWhiteSpace(text[leading]))
            {
                leading++;
            }

            int trailing = text.Length - 1;
            while (trailing > leading && char.IsWhiteSpace(text[trailing]))
            {
                trailing--;
            }

            if (trailing <= leading)
            {
                return "";
            }

            return text.Substring(leading, trailing - leading);
        }

        /// <summary>
        /// Pads a given string with another string to a given length.
        /// If appending the padded string would cause the new string
        /// to be too long, only a portion of the padded string is appended.
        /// If text is longer than toLength, an ArgumentException is thrown.
        /// </summary>
        /// <param name="text">The text to pad.</param>
        /// <param name="toPad">The string to pad with.</param>
        /// <param name="length">The desired length of the new string.</param>
        /// <returns>A string padded with toPad so it is exactly toLength
        /// characters long.</returns>
        public String RightPad(String text, String toPad, int toLength)
        {
            if (text.Length > toLength)
            {
                throw new ArgumentException("String \"" + text + "\" is longer than desired length " + toLength + ".");
            }
            StringBuilder paddedString = new StringBuilder(text);
            while (paddedString.Length < toLength)
            {
                paddedString.Append(toPad);
            }

            return paddedString.ToString();
        }

        /// <summary>
        /// Removes all the vowels from a given string. "y" and "Y"
        /// are not considered vowels. Only works on strings containing
        /// English letters.
        /// </summary>
        /// <param name="text">The string to remove the vowels from.</param>
        /// <returns>The given string with all vowels removed.</returns>
        public String RemoveVowels(String text)
        {
            StringBuilder vowelsRemoved = new StringBuilder();
            foreach (char value in text)
            {
                if (!"aeiouAEIOU".Contains(value))
                {
                    vowelsRemoved.Append(value);
                }
            }

            return vowelsRemoved.ToString();
        }
    }
}
