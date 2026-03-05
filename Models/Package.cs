using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("Packages")]
public class Package
{
    [Key]
    public Guid PackageId { get; set; }
    
    [Required]
    public Guid ShipmentId { get; set; }
    [ForeignKey("ShipmentId")]
    public Shipment Shipment { get; set; }
    
    [Required]
    public decimal Weight { get; set; }
}