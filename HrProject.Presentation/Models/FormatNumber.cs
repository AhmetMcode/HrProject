using System.Globalization;

namespace HrProject.Presentation.Models
{
    public class NumberFormatter
    {
        public static string FormatNumber(decimal number)
        {
            CultureInfo turkishCulture = new CultureInfo("tr-TR");
            return number.ToString("N2", turkishCulture);
        }
    }

}
