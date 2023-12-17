﻿

using BookStore.Domain.Entites;

namespace BookStore.Service.ViewModels;

public class BookViewModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public string Art { get; set; }

    public int ManufactureYear { get; set; }

    public decimal Price { get; set; }

    public long CategoryId { get; set; }

    public string CategoryName { get; set; }

    public string CategoryDescription { get; set; }

    public DateTime CreatedAt { get; set; }
}
