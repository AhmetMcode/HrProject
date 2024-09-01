using System;
using HrProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Presentation.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace HrProject.Application.Services
{
    public class SafetyIssueService : ISafetyIssueService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SafetyIssueService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IEnumerable<ISGSafetyIssue>> GetAllIssuesAsync()
        {
            return await _context.ISGSafetyIssue
                .Include(i => i.Category)
                .Include(i => i.SubCategory)
                .Include(i => i.Images)
                .ToListAsync();
        }


        public async Task<ISGSafetyIssue?> GetIssueByIdAsync(int id)
        {
            return await _context.ISGSafetyIssue
                                 .Include(si => si.SubCategory)
                                 .ThenInclude(sc => sc.Category)
                                 .Include(si => si.Images)
                                 .FirstOrDefaultAsync(si => si.Id == id);
        }
        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _context.Personals.ToListAsync();
        }
        public async Task<ISGSafetyIssueCategory?> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.ISGSafetyIssueCategory
                                    .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task AddIssueAsync(ISGSafetyIssue issue)
        {
            _context.ISGSafetyIssue.Add(issue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIssueAsync(ISGSafetyIssue issue)
        {
            _context.ISGSafetyIssue.Update(issue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIssueAsync(int id)
        {
            var issue = await GetIssueByIdAsync(id);
            if (issue != null)
            {
                // Resimleri fiziksel dosya sisteminden sil
                if (issue.Images != null && issue.Images.Any())
                {
                    foreach (var image in issue.Images)
                    {
                        var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "SafetyIssueImages", image.ImagePath);

                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                }

                // İş sağlığı ve güvenliği sorununu ve ilişkili resimleri veri tabanından sil
                _context.ISGSafetyIssue.Remove(issue);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ISGSafetyIssueCategory>> GetAllCategoriesAsync()
        {
            return await _context.ISGSafetyIssueCategory
                                 .Include(c => c.SubCategories)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<ISGSafetyIssueSubCategory>> GetAllSubCategoriesAsync()
        {
            return await _context.ISGSafetyIssueSubCategory.ToListAsync();
        }

        public async Task AddCategoryAsync(ISGSafetyIssueCategory category)
        {
            _context.ISGSafetyIssueCategory.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(ISGSafetyIssueCategory category)
        {
            _context.ISGSafetyIssueCategory.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.ISGSafetyIssueCategory.FindAsync(id);
            if (category != null)
            {
                _context.ISGSafetyIssueCategory.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddSubCategoryAsync(ISGSafetyIssueSubCategory subCategory)
        {
            _context.ISGSafetyIssueSubCategory.Add(subCategory);
            await _context.SaveChangesAsync();
        }
        public async Task<ISGSafetyIssueSubCategory?> GetSubCategoryByIdAsync(int subCategoryId)
        {
            return await _context.ISGSafetyIssueSubCategory
                                 .Include(sc => sc.Category) // Kategori ile birlikte yüklemek isterseniz
                                 .FirstOrDefaultAsync(sc => sc.Id == subCategoryId);
        }
        public async Task UpdateSubCategoryAsync(ISGSafetyIssueSubCategory subCategory)
        {
            _context.ISGSafetyIssueSubCategory.Update(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubCategoryAsync(ISGSafetyIssueSubCategory subCategory)
        {
            try
            {
                _context.ISGSafetyIssueSubCategory.Remove(subCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

        }

        public async Task AddImagesAsync(List<ISGSafetyIssueImages> images)
        {
            _context.ISGSafetyIssueImages.AddRange(images);
            await _context.SaveChangesAsync();
        }

        public List<ISGSafetyIssue> GetIssuesByPersonId(int personId)
        {
            return _context.ISGSafetyIssue
                .Include(i => i.Category)
                .Include(i => i.SubCategory)
                .Include(i => i.Images)
                .Where(i => i.PersonId == personId)
                .ToList();
        }
    }
}

