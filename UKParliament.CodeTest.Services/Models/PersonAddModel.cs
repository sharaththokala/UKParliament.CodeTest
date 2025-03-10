using System.ComponentModel.DataAnnotations;
using UKParliament.CodeTest.Services.Validations;

namespace UKParliament.CodeTest.Services.Models;

public class PersonAddModel
{
    [Required]
    [StringLength(100, ErrorMessage = "First Name length can't be more than 100.")]
    [ValidName]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100, ErrorMessage = "Last Name length can't be more than 100.")]
    [ValidName]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [NotInFutureDate("Date Of Birth cannot be in future.")]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    public int DepartmentId { get; set; }
}
