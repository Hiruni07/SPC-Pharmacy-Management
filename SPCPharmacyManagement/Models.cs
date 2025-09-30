using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPCPharmacyManagement.Models
{
    /// <summary>
    /// Represents a pharmaceutical supplier in the SPC system
    /// </summary>
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(255)]
        public string ContactPerson { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Phone]
        [StringLength(50)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string LicenseNumber { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        public Supplier()
        {
            RegistrationDate = DateTime.Now;
            IsActive = true;
        }
    }

    /// <summary>
    /// Represents a pharmaceutical drug in the inventory
    /// </summary>
    public class Drug
    {
        public int DrugId { get; set; }

        [Required]
        [StringLength(255)]
        public string DrugName { get; set; }

        [StringLength(255)]
        public string GenericName { get; set; }

        [Required]
        [StringLength(255)]
        public string Manufacturer { get; set; }

        [StringLength(100)]
        public string BatchNumber { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        // Additional properties for SPC requirements
        public string Category { get; set; }
        public bool RequiresPrescription { get; set; }
        public int MinimumStockLevel { get; set; }
        public int MaximumStockLevel { get; set; }
        public string StorageConditions { get; set; }

        public Drug()
        {
            CreatedDate = DateTime.Now;
            RequiresPrescription = false;
            MinimumStockLevel = 10;
            MaximumStockLevel = 1000;
        }

        // Helper properties
        public bool IsLowStock => QuantityInStock <= MinimumStockLevel;
        public bool IsExpired => ExpiryDate <= DateTime.Now;
        public bool IsNearExpiry => ExpiryDate <= DateTime.Now.AddMonths(3);
    }

    /// <summary>
    /// Represents a registered pharmacy in the SPC network
    /// </summary>
    public class Pharmacy
    {
        public int PharmacyId { get; set; }

        [Required]
        [StringLength(255)]
        public string PharmacyName { get; set; }

        [StringLength(255)]
        public string ContactPerson { get; set; }

        [Phone]
        [StringLength(50)]
        public string Phone { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string LicenseNumber { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        // Additional properties for SPC requirements
        public string PharmacyType { get; set; } // "SPC_OWNED", "LINKED_DEALER"
        public decimal CreditLimit { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Region { get; set; }

        public Pharmacy()
        {
            RegistrationDate = DateTime.Now;
            IsActive = true;
            PharmacyType = "LINKED_DEALER";
            CreditLimit = 10000;
            CurrentBalance = 0;
        }

        // Helper properties
        public decimal AvailableCredit => CreditLimit - CurrentBalance;
        public bool HasCreditAvailable => AvailableCredit > 0;
    }

    /// <summary>
    /// Represents an order placed by a pharmacy
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public int PharmacyId { get; set; }

        public string PharmacyName { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        public string OrderNotes { get; set; }

        // Additional properties for SPC requirements
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string ShippingAddress { get; set; }
        public string TrackingNumber { get; set; }
        public int ProcessedBy { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }

        // Navigation properties
        public virtual List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
            OrderDate = DateTime.Now;
            Status = "PENDING";
            PaymentStatus = "PENDING";
        }

        // Helper properties
        public bool IsPending => Status == "PENDING";
        public bool IsProcessing => Status == "PROCESSING";
        public bool IsShipped => Status == "SHIPPED";
        public bool IsDelivered => Status == "DELIVERED";
        public bool IsCancelled => Status == "CANCELLED";
        public int TotalItems => OrderItems?.Count ?? 0;
    }

    /// <summary>
    /// Represents an individual item within an order
    /// </summary>
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int DrugId { get; set; }

        public string DrugName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        // Additional properties
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; }

        public OrderItem()
        {
            DiscountPercentage = 0;
            DiscountAmount = 0;
        }

        // Helper methods
        public void CalculateTotalPrice()
        {
            var subtotal = Quantity * UnitPrice;
            DiscountAmount = subtotal * (DiscountPercentage / 100);
            TotalPrice = subtotal - DiscountAmount;
        }

        public void SetTotalPrice()
        {
            TotalPrice = Quantity * UnitPrice;
        }
    }

    /// <summary>
    /// Represents stock updates for inventory management
    /// </summary>
    public class StockUpdate
    {
        public int StockUpdateId { get; set; }

        [Required]
        public int DrugId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string UpdateType { get; set; } // "ADD", "REMOVE", "ADJUSTMENT"

        public string Reason { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

        [Required]
        [StringLength(255)]
        public string UpdatedBy { get; set; }

        // Additional properties
        public int? SupplierId { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? TotalCost { get; set; }

        public StockUpdate()
        {
            UpdateDate = DateTime.Now;
        }
    }

    /// <summary>
    /// Represents tender proposals from suppliers
    /// </summary>
    public class TenderProposal
    {
        public int TenderProposalId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(100)]
        public string TenderNumber { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // "SUBMITTED", "UNDER_REVIEW", "ACCEPTED", "REJECTED"

        public decimal TotalAmount { get; set; }

        public DateTime? ValidUntil { get; set; }
        public string Terms { get; set; }
        public string Notes { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public string ReviewedBy { get; set; }

        // Navigation properties
        public virtual List<TenderItem> TenderItems { get; set; }

        public TenderProposal()
        {
            TenderItems = new List<TenderItem>();
            SubmissionDate = DateTime.Now;
            Status = "SUBMITTED";
        }

        // Helper properties
        public bool IsActive => Status == "SUBMITTED" || Status == "UNDER_REVIEW";
        public bool IsExpired => ValidUntil.HasValue && ValidUntil.Value < DateTime.Now;
    }

    /// <summary>
    /// Represents individual items within a tender proposal
    /// </summary>
    public class TenderItem
    {
        public int TenderItemId { get; set; }

        [Required]
        public int TenderProposalId { get; set; }

        [Required]
        public int DrugId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public DateTime DeliveryDate { get; set; }
        public string Specifications { get; set; }
    }

    /// <summary>
    /// Represents manufacturing plants in the SPC system
    /// </summary>
    public class ManufacturingPlant
    {
        public int PlantId { get; set; }

        [Required]
        [StringLength(255)]
        public string PlantName { get; set; }

        [Required]
        public string Location { get; set; }

        [StringLength(100)]
        public string PlantCode { get; set; }

        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string SystemType { get; set; } // "WEB_BASED", "WINDOWS_BASED"

        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public DateTime EstablishedDate { get; set; }

        public ManufacturingPlant()
        {
            IsActive = true;
            EstablishedDate = DateTime.Now;
        }
    }

    /// <summary>
    /// Represents production records from manufacturing plants
    /// </summary>
    public class ProductionRecord
    {
        public int ProductionRecordId { get; set; }

        [Required]
        public int PlantId { get; set; }

        [Required]
        public int DrugId { get; set; }

        [Required]
        public int QuantityProduced { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        [StringLength(100)]
        public string BatchNumber { get; set; }

        public DateTime ExpiryDate { get; set; }
        public decimal ProductionCost { get; set; }
        public string QualityStatus { get; set; }
        public string Notes { get; set; }

        public ProductionRecord()
        {
            ProductionDate = DateTime.Now;
            QualityStatus = "PENDING";
        }
    }

    /// <summary>
    /// Represents user accounts in the system
    /// </summary>
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } // "ADMIN", "MANAGER", "OPERATOR", "VIEWER"

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Additional properties
        public int? PlantId { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }

        public User()
        {
            IsActive = true;
            CreatedDate = DateTime.Now;
        }

        // Helper properties
        public bool IsAdmin => Role == "ADMIN";
        public bool IsManager => Role == "MANAGER";
        public string DisplayName => !string.IsNullOrEmpty(FullName) ? FullName : Username;
    }

    /// <summary>
    /// Represents audit trail for system activities
    /// </summary>
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [Required]
        [StringLength(100)]
        public string EntityType { get; set; }

        public int? EntityId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public string Details { get; set; }
        public string IpAddress { get; set; }

        public AuditLog()
        {
            Timestamp = DateTime.Now;
        }
    }
}
