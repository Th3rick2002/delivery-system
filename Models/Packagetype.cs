using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("package_types")]
public class PackageType
{
    [Key]
    [Column("type_id")]
    public int TypeId { get; set; }

    [Column("type_name")]
    public string TypeName { get; set; }

    public string Description { get; set; }
}