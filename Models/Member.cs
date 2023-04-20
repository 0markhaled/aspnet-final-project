using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class Member
{

    public uint MemberId { get; set; }

    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }

    public string? Password { get; set; }

    [NotMapped]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string? PasswordVerify { get; set; }

    public string? MailingAddress { get; set; }



}