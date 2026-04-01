using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerProject.DTOs.CategoryDto;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAl()
        {
            var categories = _categoryService.ListCategory();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequestDto dto)
        {
            _categoryService.CreateCategory(dto);
            return StatusCode(201, dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Detele(string id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
