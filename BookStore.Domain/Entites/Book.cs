

using BookStore.Domain.Commons;

namespace BookStore.Domain.Entites
{
    public class Book : Auditable
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Art { get; set; }

        public int ManufactureYear { get; set; }

        public decimal Price { get; set; }

        public long CategoryId { get; set; }

        //public Category? Category { get; set; } 

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

    }
}
