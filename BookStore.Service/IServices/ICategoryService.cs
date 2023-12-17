using BookStore.Service.DTOs.CategoryDTOs;
using BookStore.Service.ViewModels;


namespace BookStore.Service.IServices;

public interface ICategoryService
{
    public ValueTask<CategoryViewModel> AddAsync(CategoryForCreationDTOs dto);

    public ValueTask<CategoryViewModel> UpdateAsync(CategoryForUpdateDTOs udto);

    public ValueTask<bool> DeleteAsync(long id);

    public ValueTask<CategoryViewModel> GetAsync(long id);

    public ValueTask<IEnumerable<CategoryViewModel>> GetAllAsync();
}
