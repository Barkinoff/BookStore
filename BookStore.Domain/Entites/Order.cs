

using BookStore.Domain.Commons;

namespace BookStore.Domain.Entites
{
    public class Order : Auditable
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int Quantity { get; set; }

        public long BookId { get; set; }

        public Book? Book { get; set; }
    }
}
