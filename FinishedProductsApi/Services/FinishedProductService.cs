using FinishedProductsApi.Data;
using FinishedProductsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinishedProductsApi.Services
{
    public class FinishedProductService : IFinishedProductService
    {
        private readonly ApplicationDbContext _context;

        public FinishedProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<FinishedProduct>> GetAllAsync(PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts.OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<FinishedProduct?> GetByIdAsync(int id)
        {
            return await _context.FinishedProducts
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PagedResult<FinishedProduct>> GetByCategoryAsync(string category, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.Category != null && p.Category.Contains(category))
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> GetActiveProductsAsync(PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.IsActive)
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> SearchByNameAsync(string productName, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.ProductName != null && p.ProductName.Contains(productName))
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> GetByManufacturerAsync(string manufacturer, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.Manufacturer != null && p.Manufacturer.Contains(manufacturer))
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> GetByProductTypeAsync(string productType, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.ProductType != null && p.ProductType.Contains(productType))
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> GetByDepartmentAsync(string departmentName, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.DepartmentName != null && p.DepartmentName.Contains(departmentName))
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> GetByGenderAsync(string gender, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.Gender != null && p.Gender.Contains(gender))
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> GetByProductYearAsync(int productYear, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => p.ProductYear == productYear)
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<PagedResult<FinishedProduct>> GetByMultipleIdsAsync(List<int> ids, PaginationParams paginationParams)
        {
            var query = _context.FinishedProducts
                .Where(p => ids.Contains(p.Id))
                .OrderBy(p => p.ProductName);

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationParams.PageSize);

            var data = await query
                .Skip((paginationParams.Page - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<FinishedProduct>
            {
                Data = data,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = paginationParams.Page,
                PageSize = paginationParams.PageSize,
                HasNextPage = paginationParams.Page < totalPages,
                HasPreviousPage = paginationParams.Page > 1
            };
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.FinishedProducts.CountAsync();
        }
    }
}