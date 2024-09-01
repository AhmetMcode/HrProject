using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class OfferCostCategoryService : BaseRepository<OfferCostCategory>, IOfferCostCategory
    {
        private readonly IOfferService offerService;

        public OfferCostCategoryService(DbContextOptions<ApplicationDbContext> options, IOfferService offerService) : base(options)
        {
            this.offerService = offerService;
        }

        public List<OfferCostCategory> GetAllInclude()
        {
            return _context.OfferCostCategorys.Include(x => x.OfferMaterials).ThenInclude(x => x.CurrentValue).ThenInclude(x => x.Unit).ToList();
        }

        public OfferCostCategory GetInclude(int id)
        {
            return _context.OfferCostCategorys.Where(x => x.Id == id).Include(x => x.CreationUserId).FirstOrDefault();
        }

        public List<OfferCostCalculateDetail> OfferCostCalculateDetailsAddAndList(int offerPartId)
        {
            var catgorys = _context.OfferMaterials.Include(x => x.CurrentValue).ToList();
            var ConcretesClass = offerService.GetConcretsWithVaVlue(offerPartId);
            var ropes = offerService.GetRopeIronsTotalValue(offerPartId);
            foreach (var cat in catgorys)
            {
                OfferCostCalculateDetail offerCostCalculateDetail1 = _context.OfferCostCalculateDetails.Where(x => x.OfferMaterialsId == cat.Id && x.OfferPartId == offerPartId).FirstOrDefault();
                if (offerCostCalculateDetail1 != null)
                {
                    offerCostCalculateDetail1.OfferPartId = offerPartId;
                    offerCostCalculateDetail1.OfferMaterialsId = cat.Id;
                    // offerCostCalculateDetail1.CurrentValueC = cat.CurrentValue.Price;
                    offerCostCalculateDetail1.Wastage = cat.Wastage;
                    if (false)
                    {
                        if (cat.Formulas == Formulas.DemirleriTopla)
                        {
                            offerCostCalculateDetail1.Quantity = (offerService.GetTotalIronValue(offerPartId) / 1000M);
                            offerCostCalculateDetail1.Amount = offerCostCalculateDetail1.Quantity * cat.CurrentValue.Price;
                        }
                        else if (cat.Formulas == Formulas.HasirlariTopla)
                        {
                            offerCostCalculateDetail1.Quantity = (offerService.GetTotalWickerValue(offerPartId) / 1000M);
                            offerCostCalculateDetail1.Amount = offerCostCalculateDetail1.Quantity * cat.CurrentValue.Price;
                        }
                        else if (cat.Formulas == Formulas.BetonlariTopla)
                        {
                            offerCostCalculateDetail1.Quantity = offerService.GetTotalConcreteValue(offerPartId);
                            offerCostCalculateDetail1.Amount = offerCostCalculateDetail1.Quantity * cat.CurrentValue.Price;
                        }
                        else if (cat.Formulas == Formulas.ProjedekiMiktar)
                        {
                            if (cat.TypesFormulas == TypesFormulas.Beton)
                            {
                                string cocnrete = cat.CurrentValue.CurrentValueName.Substring(0, 3);
                                ConcreteClass concreteClass = _context.ConcreteClass.Where(x => x.Name == cocnrete).FirstOrDefault();
                                decimal qu = ConcretesClass.Where(x => x.Key == concreteClass.Name).FirstOrDefault().Value;
                                offerCostCalculateDetail1.Quantity = ((qu * cat.Wastage) / 100) + qu;
                                offerCostCalculateDetail1.Amount = offerCostCalculateDetail1.Quantity * cat.CurrentValue.Price;
                            }
                            if (cat.TypesFormulas == TypesFormulas.Hasir)
                            {
                                decimal qu = offerService.GetTotalWickerValue(offerPartId);
                                offerCostCalculateDetail1.Quantity = ((((qu * cat.Wastage) / 100) + qu) / 1000M);
                                offerCostCalculateDetail1.Amount = offerCostCalculateDetail1.Quantity * cat.CurrentValue.Price;
                            }
                            if (cat.TypesFormulas == TypesFormulas.Halat)
                            {
                                string cocnrete = cat.CurrentValue.CurrentValueName.Substring(0, 3);
                                decimal qu = ropes.Where(x => x.Key.Contains(cocnrete)).FirstOrDefault().Value;
                                offerCostCalculateDetail1.Quantity = ((((qu * cat.Wastage) / 100) + qu) / 1000M);
                                offerCostCalculateDetail1.Amount = offerCostCalculateDetail1.Quantity * cat.CurrentValue.Price;

                            }

                        }

                        // Diğer durumları ekleyebilirsiniz.
                        _context.OfferCostCalculateDetails.Update(offerCostCalculateDetail1);
                    }
                    else
                    {
                        offerCostCalculateDetail1.Quantity = 0;
                        offerCostCalculateDetail1.Wastage = cat.Wastage;
                        offerCostCalculateDetail1.CreatedTime = DateTime.Now;
                    }
                    //_context.OfferCostCalculateDetails.Update(offerCostCalculateDetail1);

                }
                else
                {
                    OfferCostCalculateDetail offerCostCalculateDetail = new OfferCostCalculateDetail
                    {
                        OfferPartId = offerPartId,
                        OfferMaterialsId = cat.Id,
                        CurrentValueC = cat.CurrentValue.Price,
                        Wastage = cat.Wastage,

                    };
                    if (false)
                    {
                        if (cat.Formulas == Formulas.DemirleriTopla)
                        {
                            offerCostCalculateDetail.Quantity = offerService.GetTotalIronValue(offerPartId) / 1000M;
                            offerCostCalculateDetail.Amount = (offerCostCalculateDetail.Quantity) * cat.CurrentValue.Price;
                        }
                        else if (cat.Formulas == Formulas.HasirlariTopla)
                        {
                            offerCostCalculateDetail.Quantity = offerService.GetTotalWickerValue(offerPartId) / 1000M;
                            offerCostCalculateDetail.Amount = (offerCostCalculateDetail.Quantity / 1000) * cat.CurrentValue.Price;
                        }
                        else if (cat.Formulas == Formulas.BetonlariTopla)
                        {
                            offerCostCalculateDetail.Quantity = offerService.GetTotalConcreteValue(offerPartId);
                            offerCostCalculateDetail.Amount = offerCostCalculateDetail.Quantity * cat.CurrentValue.Price;
                        }
                        else if (cat.Formulas == Formulas.ProjedekiMiktar)
                        {
                            if (cat.TypesFormulas == TypesFormulas.Beton)
                            {
                                string cocnrete = cat.CurrentValue.CurrentValueName.Substring(0, 3);
                                ConcreteClass concreteClass = _context.ConcreteClass.Where(x => x.Name == cocnrete).FirstOrDefault();
                                decimal qu = ConcretesClass.Where(x => x.Key == concreteClass.Name).FirstOrDefault().Value;
                                offerCostCalculateDetail.Quantity = ((qu * cat.Wastage) / 100) + qu;
                                offerCostCalculateDetail.Amount = offerCostCalculateDetail.Quantity * cat.CurrentValue.Price;
                            }
                            if (cat.TypesFormulas == TypesFormulas.Hasir)
                            {
                                decimal qu = offerService.GetTotalWickerValue(offerPartId);
                                offerCostCalculateDetail.Quantity = (((qu * cat.Wastage) / 100) + qu) / 1000;
                                offerCostCalculateDetail.Amount = offerCostCalculateDetail.Quantity * cat.CurrentValue.Price;
                            }
                            if (cat.TypesFormulas == TypesFormulas.Halat)
                            {
                                string cocnrete = cat.CurrentValue.CurrentValueName.Substring(0, 3);
                                decimal qu = ropes.Where(x => x.Key.Contains(cocnrete)).FirstOrDefault().Value / 5;
                                offerCostCalculateDetail.Quantity = ((qu * cat.Wastage) / 100) + qu;
                                offerCostCalculateDetail.Amount = offerCostCalculateDetail.Quantity * cat.CurrentValue.Price;
                            }

                        }

                        // Diğer durumları ekleyebilirsiniz.

                    }
                    else
                    {
                        offerCostCalculateDetail.Enflasyon = -99;
                        offerCostCalculateDetail.Quantity = 0;
                        offerCostCalculateDetail.Wastage = cat.Wastage;
                        offerCostCalculateDetail.CreatedTime = DateTime.Now;
                    }
                    _context.OfferCostCalculateDetails.Add(offerCostCalculateDetail);
                }

            }
            _context.SaveChanges();

            return _context.OfferCostCalculateDetails.Where(x => x.OfferPartId == offerPartId).Include(x => x.OfferMaterials).ThenInclude(x => x.CurrentValue).ThenInclude(x => x.Unit).ToList();
        }
    }
}
