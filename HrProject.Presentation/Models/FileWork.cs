namespace HrProject.Presentation.Models
{
    public static class FileWork
    {
        public static string IntArrayToString(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return "";
            }

            return string.Join("-", array);
        }

        // String'i "-" karakterine göre ayırıp int dizisine dönüştüren metot
        public static int[] StringToIntArray(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new int[0];
            }

            string[] parts = str.Split('-');
            List<int> tempList = new List<int>();

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int num))
                {
                    tempList.Add(num);
                }
                else
                {
                    // Hata durumunda uygun bir işlem yapabilirsiniz.
                    Console.WriteLine($"'{part}' is not a valid integer.");
                }
            }

            return tempList.ToArray();
        }

        public static string ConvertBase64ToBase64(IFormFile pic)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // IFormFile'u MemoryStream'e kopyala
                pic.CopyTo(memoryStream);

                // MemoryStream'deki veriyi byte dizisine dönüştür
                byte[] bytes = memoryStream.ToArray();

                // Byte dizisini base64 string'e dönüştür
                string base64String = Convert.ToBase64String(bytes);

                return base64String;
            }
        }
        public static void SaveFileToDirectory(IFormFile file, string directoryPath)
        {
            string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(directoryPath, fileName);

            // Save the file to the specified directory
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
        public static string ReturnFileName(IFormFile file, string saveFile, IWebHostEnvironment hostEnvironment)
        {

            if (file != null && file.Length > 0)
            {
                string dosyaAdi = "";

                dosyaAdi = Path.GetFileName(file.FileName);
                string dosyaUzantisi = Path.GetExtension(dosyaAdi);
                var dosyaYolu = Path.Combine(hostEnvironment.WebRootPath, saveFile);
                dosyaAdi = Guid.NewGuid().ToString() + dosyaUzantisi;
                var dosyaYoluTam = Path.Combine(dosyaYolu, dosyaAdi);

                using (var fileStream = new FileStream(dosyaYoluTam, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return dosyaAdi;

            }
            else
            {
                return string.Empty;
            }

        }
        public static string ConvertToBase64(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }

        public static string GetFileExtension(IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }

        public static string GetFileName(IFormFile file)
        {
            return Path.GetFileNameWithoutExtension(file.FileName);
        }

    }
}
