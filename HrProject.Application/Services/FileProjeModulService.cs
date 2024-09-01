using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Application.Services
{
    public class FileProjeModulService : BaseRepository<FileProjeModul>, IFileProjeModulService
    {
        public FileProjeModulService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<FileProjeModul> DosyalariGetirProjeElemanaGore(int id, int projeElemanId)
        {
            if (id == 0)
            {
                var files = _context.FileProjeModul.Where(x => x.ProjectModuleSubId == id && x.ProjectElementId == 0).Include(x => x.ProjectElement).ToList();
                return files;
            }
            else
            {
                var files = _context.FileProjeModul.Where(x => x.ProjectModuleSubId == id && x.ProjectElementId == projeElemanId).Include(x => x.ProjectElement).ToList();
                return files;
            }

        }

        public List<FileProjeModul> GetFileOnylNameByProjeId(int id)
        {
            var files = _context.FileProjeModul
         .Where(x => x.ProjectModuleSubId == id)
         .Select(f => new FileProjeModul
         {
             Id = f.Id,
             RevizeNo = f.RevizeNo,
             ProjectModuleSubId = f.ProjectModuleSubId,
             Dosya = "",
             Uzanti = f.Uzanti,
             ProjectElementId = f.ProjectElementId,
             CreationUserId = f.CreationUserId,
         })
         .ToList();
            if (files == null)
            {
                return new List<FileProjeModul>();
            }
            return files;
        }
    }
}
