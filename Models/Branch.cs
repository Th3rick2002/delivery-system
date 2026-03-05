using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("branches")]
public class Branch
{
    [Key]
    [Column("branch_id")]
    public int BranchId { get; set; }

    [Required]
    [Column("name_branch")]
    public string NameBranch { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [Column("phone_branch")]
    public string PhoneBranch { get; set; }
}