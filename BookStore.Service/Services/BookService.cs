
using AutoMapper;
using BookStore.Data.IRepositories;
using BookStore.Domain.Entites;
using BookStore.Service.DTOs.BookDTOs;
using BookStore.Service.Exceptions;
using BookStore.Service.IServices;
using BookStore.Service.ViewModels;

namespace BookStore.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> bookRepository;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Category> categoryRepository;

        public BookService(IGenericRepository<Book> genericRepository,IMapper mapper, IGenericRepository<Category> categoryRepository)
        {
            this.bookRepository = genericRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<BookViewModel> CreateAsync(BookForCreationDTO bookDto)
        {
            var categoryModel = await categoryRepository.GetAsync(x => x.Id == bookDto.CategoryId);

            if (categoryModel is null)
                throw new HttpException("Category is not found", 404);
            
            var bookModel = mapper.Map<Book>(bookDto);
            bookModel.CategoryId = categoryModel.Id;
            bookModel.CategoryName = categoryModel.Name;
            bookModel.CategoryDescription = categoryModel.Description;
            bookModel.CreateAt = DateTime.UtcNow;

            var bookResult = await bookRepository.InsertAsync(bookModel);

            if (categoryModel.Book is null)
                categoryModel.Book = new List<Book>();

            categoryModel.Book.Add(bookResult);

            await categoryRepository.UpdateAsync(categoryModel);

            return mapper.Map<BookViewModel>(bookResult);
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var result = await Task.FromResult(bookRepository.GetAll(null));
            return mapper.Map<IEnumerable<BookViewModel>>(result);
        }

        public Task<BookViewModel> GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
