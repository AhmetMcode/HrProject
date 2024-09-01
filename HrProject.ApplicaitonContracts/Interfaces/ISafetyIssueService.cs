using System;
using HrProject.Domain.Entities;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ISafetyIssueService
    {
        Task<IEnumerable<ISGSafetyIssue>> GetAllIssuesAsync();
        Task<ISGSafetyIssue?> GetIssueByIdAsync(int id);
        Task AddIssueAsync(ISGSafetyIssue issue);
        Task UpdateIssueAsync(ISGSafetyIssue issue);
        Task DeleteIssueAsync(int id);


        Task<IEnumerable<ISGSafetyIssueCategory>> GetAllCategoriesAsync();
        Task<IEnumerable<ISGSafetyIssueSubCategory>> GetAllSubCategoriesAsync();

        Task AddCategoryAsync(ISGSafetyIssueCategory category);
        Task UpdateCategoryAsync(ISGSafetyIssueCategory category);
        Task DeleteCategoryAsync(int id);

        Task AddSubCategoryAsync(ISGSafetyIssueSubCategory subCategory);
        Task UpdateSubCategoryAsync(ISGSafetyIssueSubCategory subCategory);
        Task DeleteSubCategoryAsync(ISGSafetyIssueSubCategory subCategory);

        Task AddImagesAsync(List<ISGSafetyIssueImages> images);
        Task<ISGSafetyIssueCategory?> GetCategoryByIdAsync(int categoryId);
        Task<ISGSafetyIssueSubCategory?> GetSubCategoryByIdAsync(int subCategoryId);
        Task<List<Person>> GetAllPersonsAsync();

        List<ISGSafetyIssue> GetIssuesByPersonId(int personId);
    }
}

