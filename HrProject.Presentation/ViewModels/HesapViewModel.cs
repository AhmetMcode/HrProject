using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class HesapViewModel
    {
        public int Id { get; set; }

        public int HesapSiniflariId { get; set; }
        public HesapSiniflari HesapSiniflari { get; set; } = new HesapSiniflari();
        public List<HesapSiniflari> HesapSiniflaris { get; set; }

        public int HesapGruplariId { get; set; }
        public HesapGruplari HesapGruplari { get; set; } = new HesapGruplari();
        public List<HesapGruplari> HesapGruplaris { get; set; }

        public int HesapPlaniId { get; set; }
        public HesapPlani HesapPlani { get; set; } = new HesapPlani();
        public List<HesapPlani> HesapPlanis { get; set; }

        public int HesapMuavinId { get; set; }
        public string? HesapName { get; set; }
        public string HesapCode { get; set; }
        public HesapMuavin HesapMuavin { get; set; } = new HesapMuavin();
        public List<HesapMuavin> HesapMuavins { get; set; }

        public int HesapTaliId { get; set; }
        public HesapTali HesapTali { get; set; } = new HesapTali();
        public List<HesapTali> HesapTalis { get; set; }

        public int HesapDetayId { get; set; }
        public HesapDetay HesapDetay { get; set; } = new HesapDetay();
        public List<HesapDetay> HesapDetays { get; set; }



    }

    public class HesapViewModel1
    {
        public int Id { get; set; }

        public HesapGruplari HesapGruplari { get; set; }
        public int HesapPlaniId { get; set; }
        public string? HesapName { get; set; }
        public string HesapCode { get; set; }

    }

    public class HesapViewModel2
    {
        public int Id { get; set; }

        public HesapMuavin HesapMuavin { get; set; }
        public List<HesapMuavin> HesapMuavins { get; set; }
        public int HesapPlaniId { get; set; }
        public string? HesapName { get; set; }
        public string HesapCode { get; set; }
        public HesapPlani HesapPlani { get; set; }

    }


}
