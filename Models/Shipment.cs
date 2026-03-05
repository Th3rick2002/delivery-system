using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("Shipments")]
public class Shipment
{
    [Key] 
    public Guid ShipmentId { get; set; }
    
    [Required]
    public Guid CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
    
    [Required]
    public Guid RecipientId { get; set; }
    [ForeignKey("RecipientId")]
    public Recipient Recipient {get; set;}
    
    [Required]
    public int ShipmentStatusId { get; set; }
    [ForeignKey("ShipmentStatusId")]
    public ShipmentStatus ShipmentStatus { get; set; }
    
    [Required]
    public DateTime ShipmentDate { get; set; }
    
    [Required]
    public DateTime DeliveryDate { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    public ICollection<Package> Packages { get; set; }
}