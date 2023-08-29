using System.ComponentModel.DataAnnotations;

namespace PropertEase_Models.Models.Core;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
