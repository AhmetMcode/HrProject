namespace HrProject.Presentation.Models
{
    public static class Roller
    {
        public const string Role_Admin = "Full Admin";
        public const string Role_Teklif_Yonetici = "Teklif Admin";
        public const string Role_Teklif_Calisan = "Teklif Calisan";
        public const string Role_Teklif_Proje = "Teklif Proje";
        public const string Role_Proje_Yonetici = "Proje Yonetici";
        public const string Role_Proje_Calisan = "Proje Calisan";
        public const string Role_Uretim_Admin = "Uretim Admin";
        public const string Role_Stok_Admin = "Stok Admin";
        public const string Role_Stok_Kullanici = "Stok Kullanici";
        public const string Role_Uretim_Sef = "Uretim Sef";
        public const string Role_Uretim_UstaBasi = "Uretim Usta Basi";
        public const string Role_Kalite_Admin = "Kalite Admin";
        public const string Role_Kalite_Sef = "Kalite Sef";
        public const string Role_Muhasebe_Admin = "Muhasebe Admin";
        public const string Role_Muhasebe_Calisan = "Muhasebe Calisan";
        public const string Role_Fabiraka_Calisan = "Fabrika Calisan";
        public const string Role_Planlama_Sef = "Planlama Admin";
        public const string Role_Planama_Kullanici = "Planlama Kullanici";
        public const string Role_Idari = "Idari";
        public const string Hr_Sef = "Hr Admin";
        public const string Hr_Kullanici = "Hr Kullanici";
        public const string FabrikaAdmin = "FabrikaAdmin";
        public static List<string> GetAllRoles()
        {
            return new List<string>
        {
            Role_Admin,
            Role_Teklif_Yonetici,
            Role_Teklif_Calisan,
            Role_Teklif_Proje,
            Role_Proje_Yonetici,
            Role_Proje_Calisan,
            Role_Uretim_Admin,
            Role_Uretim_Sef,
            Role_Uretim_UstaBasi,
            Role_Kalite_Admin,
            Role_Kalite_Sef,
            Role_Muhasebe_Admin,
            Role_Muhasebe_Calisan,
            Role_Fabiraka_Calisan,
            Role_Planlama_Sef,
            Role_Planama_Kullanici,
            Hr_Kullanici,
            Hr_Sef,
            Role_Idari,
            Role_Stok_Admin,
            Role_Stok_Kullanici,
            FabrikaAdmin
        };
        }
    }
}
