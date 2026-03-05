using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("name")]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    [Column("phone")]
    public string Phone { get; set; }

    [Required]
    [EmailAddress]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [Column("password")]
    public string Password { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    public Role Role { get; set; }

    public ICollection<Shipment> Shipments { get; set; }
}