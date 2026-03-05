using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("ShipmentStatus")]
public class ShipmentStatus
{
    [Key]
    public int StatusId { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string StatusName { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(80)]
    public string Description { get; set; }
    
    public ICollection<Shipment> Shipments { get; set; }
}