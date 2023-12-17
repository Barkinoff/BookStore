using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.DTOs.CategoryDTOs;

public class CategoryForUpdateDTOs
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Art { get; set; }
}
