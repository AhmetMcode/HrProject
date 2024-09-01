namespace HrProject.Presentation.Models
{
    public static class SubString
    {
        public static string Sub(string word)
        {
            if (word != null)
            {

                if (word.Length > 10)
                {
                    return word.Substring(0, 10) + "...";
                }
                else
                {
                    return word;
                }
            }
            return "";
        }
    }
}
