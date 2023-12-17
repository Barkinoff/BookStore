using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Art { get; set; }

        public ICollection<BookViewModel>? Books { get; set; }
    }
}
