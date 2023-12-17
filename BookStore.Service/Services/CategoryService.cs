
using AutoMapper;
using BookStore.Data.IRepositories;
using BookStore.Domain.Entites;
using BookStore.Service.DTOs.CategoryDTOs;
using BookStore.Service.Exceptions;
using BookStore.Service.IServices;
using BookStore.Service.ViewModels;

namespace BookStore.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> genericRepository;
    private readonly IMapper mapper;
    public CategoryService(IGenericRepository<Category> genericRepository, IMapper mapper)
    {
        this.genericRepository = genericRepository;
        this.mapper = mapper; 
    }

    public async ValueTask<CategoryViewModel> AddAsync(CategoryForCreationDTOs dto)
    {
        var resultMap = mapper.Map<Category>(dto);
        resultMap.CreateAt = DateTime.UtcNow;
        var result = await this.genericRepository.InsertAsync(resultMap);

        return mapper.Map<CategoryViewModel>(result);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var checkValue = await genericRepository.GetAsync(o => o.Id == id, new[] { "Book" });

        if (checkValue is null)
            throw new HttpException("Category is not found", 404);

        await genericRepository.DeleteAsync(checkValue);
        return true;
    }

    public async ValueTask<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        var result = await Task.FromResult(genericRepository.GetAll(null,new[] { "Book" }));
        var resultMap = mapper.Map<IEnumerable<CategoryViewModel>>(result);

        foreach (var item in resultMap) 
        {
            if(item.Books is null) 
                item.Books = new List<BookViewModel>();

            var resultCategory = result.Where(book => book.Name == item.Name).SelectMany(book => book.Book);
            item.Books = mapper.Map<List<BookViewModel>>(resultCategory);
        }

        return resultMap;
    }

    public async ValueTask<CategoryViewModel> GetAsync(long id)
    {
        var result = await genericRepository.GetAsync(v => v.Id == id, new[] { "Book" });

        if (result is null)
            throw new HttpException("Category is not found", 404);

        var resultMap = mapper.Map<CategoryViewModel>(result);

        if (resultMap.Books is null)
            resultMap.Books = new List<BookViewModel>();

        resultMap.Books = mapper.Map<List<BookViewModel>>(result.Book);
        
        return resultMap;
    }

    public async ValueTask<CategoryViewModel> UpdateAsync(CategoryForUpdateDTOs udto)
    
    {
        var getResult = await genericRepository.GetAsync(x => x.Id == udto.Id);
        getResult.Art = udto.Art;
        getResult.Description = udto.Description;
        getResult.Name = udto.Name;
        var result = await genericRepository.UpdateAsync(getResult);

        return mapper.Map<CategoryViewModel>(result);
    }
}
