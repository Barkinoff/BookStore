

using BookStore.Service.DTOs.BookDTOs;
using BookStore.Service.ViewModels;

namespace BookStore.Service.IServices;

public interface IBookService
{
    public Task<BookViewModel> CreateAsync(BookForCreationDTO bookDto);

    public Task<BookViewModel> GetAsync(long id);

    public Task<bool> DeleteAsync(long id);

    public Task<IEnumerable<BookViewModel>> GetAllAsync();
}
