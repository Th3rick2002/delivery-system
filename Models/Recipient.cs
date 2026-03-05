using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("Recipients")]
public class Recipient
{
    [Key]
    public Guid RecipientId { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Name { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Phone { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string Address { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string City { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Country { get; set; }
    
    public ICollection<Shipment> Shipments { get; set; }
}