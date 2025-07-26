using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinishedProductsApi.Models
{
    [Table("v_sFinishedProductsAPI")]
    public class FinishedProduct
    {
        [Key]
        public int Id { get; set; }

        public string? Manufacturer { get; set; }

        public string? Category { get; set; }

        public string? ProductType { get; set; }

        public string? Description { get; set; }

        public string? ProductSize { get; set; }

        public double SalesPrice { get; set; }

        public string? ProductName { get; set; }

        public bool IsActive { get; set; }

        public DateTime EntryTime { get; set; }

        public string? Unit { get; set; }

        public string? DepartmentName { get; set; }

        public double MaterialCost { get; set; }

        public double CostPrice { get; set; }

        public bool IsRawMaterial { get; set; }

        public string? Volume { get; set; }

        public string? Collection { get; set; }

        public string? PakingTypes { get; set; }

        public double Weight { get; set; }

        public bool IsStitched { get; set; }

        public int ProductYear { get; set; }

        public string? Gender { get; set; }
    }
}