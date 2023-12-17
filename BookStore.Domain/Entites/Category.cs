
using BookStore.Domain.Commons;

namespace BookStore.Domain.Entites;

public class Category : Auditable
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Art { get; set; }

    public ICollection<Book>? Book { get; set; }
}
