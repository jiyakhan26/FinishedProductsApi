using FinishedProductsApi.Models;

namespace FinishedProductsApi.Services
{
    public interface IFinishedProductService
    {
        Task<PagedResult<FinishedProduct>> GetAllAsync(PaginationParams paginationParams);
        Task<FinishedProduct?> GetByIdAsync(int id);
        Task<PagedResult<FinishedProduct>> GetByCategoryAsync(string category, PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> GetActiveProductsAsync(PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> SearchByNameAsync(string productName, PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> GetByManufacturerAsync(string manufacturer, PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> GetByProductTypeAsync(string productType, PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> GetByDepartmentAsync(string departmentName, PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> GetByGenderAsync(string gender, PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> GetByProductYearAsync(int productYear, PaginationParams paginationParams);
        Task<PagedResult<FinishedProduct>> GetByMultipleIdsAsync(List<int> ids, PaginationParams paginationParams);
        Task<int> GetTotalCountAsync();
    }
}