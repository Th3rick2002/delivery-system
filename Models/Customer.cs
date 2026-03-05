using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ParcelDeliverySystem.Models;

[Table("Customers")]
[Index(nameof(Email), IsUnique = true)]
public class Customer
{
    [Key]
    public Guid CustomerId { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string Phone { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Address  { get; set; }
    
    [Required]
    public DateTime RegistrationDate  { get; set; } =  DateTime.UtcNow;
    
    public ICollection<Shipment> Shipments { get; set; }
}