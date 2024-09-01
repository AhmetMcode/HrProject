
using DinkToPdf;

namespace HrProject.Application.Services
{
    public class PdfService
    {

        public PdfService()
        {
        }

        public byte[] GeneratePdf()
        {
            var htmlContent = @"
<!DOCTYPE html>
<html>
<head>
<link href='C:\Users\musta\Desktop\MORFO ERP\HrProject\HrProject.Presentation\wwwroot\lib\bootstrap\dist\css\bootstrap.min.css' rel='stylesheet' />
<link href='C:\Users\musta\Desktop\MORFO ERP\HrProject\HrProject.Presentation\wwwroot\lib\bootstrap\dist\css\bootstrap.rtl.min.css' rel='stylesheet' />
<link href='C:\Users\musta\Desktop\MORFO ERP\HrProject\HrProject.Presentation\wwwroot\lib\bootstrap\dist\css\bootstrap.rtl.css' rel='stylesheet' />
<link href='C:\Users\musta\Desktop\MORFO ERP\HrProject\HrProject.Presentation\wwwroot\lib\bootstrap\dist\css\bootstrap.css' rel='stylesheet' />
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }
        .ortatable {
            width: 80%;
            border-collapse: collapse;
            background-color: #bdbdbd; /* Gri arka plan rengi */
        }
        table, th, td {
            border: 1px solid black;
        }

        th, td {
            padding: 15px;
            text-align: left;
        }
        .kalin {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <table>
        <tr>
            <th rowspan='3'><img style='width:200px;' src='C:\Users\musta\Desktop\MORFO ERP\HrProject\HrProject.Presentation\wwwroot\theme\logo.png' /></th>
            <th colspan='4'>Prefabrik Yapı Teklifi</th> <!-- İki hücreyi birleştir -->
        </tr>
        <tr>
            <td>Döküman No</td> <!-- İki satırı birleştir -->
            <td>Row 1, Cell 2</td>
            <td>Revizyon No</td>
            <td>Row 1, Cell 3</td>
        </tr>
        <tr>
            <td>Revizyon Tarihi</td>
            <td>Row 2, Cell 2</td>
            <td>Sayfa No</td>
            <td></td>
        </tr>
    </table>
    <div class='row' >
        <div class='col-3' >
asdasdasd
        </div>
        <div class='col-9' >
          <div id='text-container'>
            <div class='d-flex ' style='justify-content:space-between' >
              <div  class='kalin mt-2'>
                <p>SN. ABİDİN AŞICI,</p>
              </div>
              <div class='kalin mt-2 mr-4'>
                <p>Teklif Numarası: ELF_23_M(İ)ON_0186</p>
              </div>
             
        </div>
        <div class='kalin mt-2'>
          Adres: Polatlı/ANKARA
        </div>
        <div class='kalin mt-2'>
          MADDE 1) TEKLİFE ESAS İŞİN TARİFİ:
        </div>
        <div class='mt-2'>
          ___ ili ___ ilçesi ___ Mahallesi ____ ada __ parsel yakınlarında “betonarme prefabrik yapı” olarak yapılması planlanan yapının;
        </div>
        <div class='mt-4 kalin' >
          KARKAS :
        </div>
        <div class='mt-3' >
          ___ aksları arası ___ m genişliğindedir. ___ aksları arası ___ m uzunluğundadır. Saha betonundan makas altı yüksekliği ___ m’dir. Yapıda maksimum yük taşıma kapasitesi __ ton olan vinç kirişleri bulunmaktadır. Güneş paneli yükü dahil edilmiştir. Yapı oturum alanı bina dışından ___ m²’dir.
        </div>
        <div class='mt-5 kalin' >
          MADDE 2) TEKLİFE ESAS İŞİN HESAP DEĞERLERİ:
        </div>
        <div class='container mt-3' >
          <table class='ortatable' >
            <tr>
                <td class='kalin'>Hareketli Yük Katılım Katsayısı</td>
                <td>1. Satır, 2. Sütun</td>
                <td>1. Satır, 3. Sütun</td>
                <td>1. Satır, 4. Sütun</td>
            </tr>
            <tr>
                <td>2. Satır, 1. Sütun</td>
                <td>2. Satır, 2. Sütun</td>
                <td>2. Satır, 3. Sütun</td>
                <td>2. Satır, 4. Sütun</td>
            </tr>
            <tr>
                <td>3. Satır, 1. Sütun</td>
                <td>3. Satır, 2. Sütun</td>
                <td>3. Satır, 3. Sütun</td>
                <td>3. Satır, 4. Sütun</td>
            </tr>
            <tr>
                <td>4. Satır, 1. Sütun</td>
                <td>4. Satır, 2. Sütun</td>
                <td>4. Satır, 3. Sütun</td>
                <td>4. Satır, 4. Sütun</td>
            </tr>
            <tr>
                <td>5. Satır, 1. Sütun</td>
                <td>5. Satır, 2. Sütun</td>
                <td>5. Satır, 3. Sütun</td>
                <td>5. Satır, 4. Sütun</td>
            </tr>
        </table>
        
        </div>
<div class='kalin' style='margin-top:35px;' >
          MADDE 3) TEKLİFE ESAS İŞİN ÜRETİM BİLGİLERİ:
        </div>
    </div>
 
</body>
</html>
";

            var converter = new BasicConverter(new PdfTools());

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait,
            },
                Objects = {
                new ObjectSettings() {
                    PagesCount = true,
                    HtmlContent = htmlContent,
                }
            }
            };

            byte[] pdf = converter.Convert(document);

            return pdf;
        }
    }
}



