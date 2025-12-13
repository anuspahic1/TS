using System.ComponentModel.DataAnnotations;

public record AppUserForUpdateDto
{
    [Required(ErrorMessage = "Full name is required.")]
    [MaxLength(60, ErrorMessage = "Full name max length is 60.")]
    public string FullName { get; init; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(100)]
    public string Email { get; init; }

    [MaxLength(30, ErrorMessage = "Bank account number max length is 30.")]
    public string? BankAccountNumber { get; init; }
}