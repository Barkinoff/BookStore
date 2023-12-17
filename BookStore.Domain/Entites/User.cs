using BookStore.Domain.Commons;


namespace BookStore.Domain.Entites;

public class User : Auditable
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }
}
