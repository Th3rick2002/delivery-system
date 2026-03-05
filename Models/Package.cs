using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("packages")]
public class Package
{
    [Key]
    [Column("package_id")]
    public Guid PackageId { get; set; }

    [Column("shipment_id")]
    public Guid ShipmentId { get; set; }

    public Shipment Shipment { get; set; }

    public decimal Height { get; set; }

    public decimal Width { get; set; }

    public decimal Length { get; set; }

    public decimal Weight { get; set; }

    public bool Fragile { get; set; }
}