using BookStore.Service.DTOs.CategoryDTOs;
using BookStore.Service.IServices;
using BookStore.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("Category-package")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"> itoblar kategoriyasini kiriting </param>
        /// <returns></returns>
        [HttpPost("AddCategory")]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryForCreationDTOs dto) =>
            Ok(await categoryService.AddAsync(dto));

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] CategoryForUpdateDTOs dto) =>
            Ok(await categoryService.UpdateAsync(dto));

        [HttpGet("Get")]
        public async Task<IActionResult> GetAsync(long id) =>
            Ok(await categoryService.GetAsync(id));

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAllAsync() =>
           Ok(await categoryService.GetAllAsync());

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(long id) =>
            Ok(await categoryService.DeleteAsync(id));
    }
}
