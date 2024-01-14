using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAppApi.Context;
using MyWebAppApi.Dtos.Category;
using MyWebAppApi.Entity;

namespace MyWebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _context;
        private IMapper mapper;

        public CategoriesController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        /*
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /*
        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
          if (_context.Categories == null)
          {
              return Problem("Entity set 'MyDbContext.Categories'  is null.");
          }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }
        
        [HttpPost]
        public async Task<ActionResult<CategoryCreateDTOResponse>> PostCategory([Required] CategoryCreateDTORequest category)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'MyDbContext.Categories'  is null.");
            }
            try
            {
                Category c = new Category();
                c.CategoryName = category.CategoryName;
                _context.Categories.Add(c);
                await _context.SaveChangesAsync();

                return Ok(new CategoryCreateDTOResponse() { Id = c.Id, CategoryName = c.CategoryName });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return BadRequest();
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */


        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return Ok(mapper.Map<List<Category>, List<CategoryDTOResponse>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            return Ok(mapper.Map<Category, CategoryDTOResponse>(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTORequest model)
        {
            if (!ModelState.IsValid) return BadRequest();

            Category category = mapper.Map<CategoryDTORequest, Category>(model);
            _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok(mapper.Map<Category, CategoryDTOResponse>(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTORequest model)
        {
            if (!ModelState.IsValid) return BadRequest();

            Category category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                category = mapper.Map<CategoryDTORequest, Category>(model);

                _context.Update(category);
                await _context.SaveChangesAsync();
                return Ok(mapper.Map<Category, CategoryDTOResponse>(category));

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return Ok(mapper.Map<Category, CategoryDTOResponse>(category));

            }
            return NotFound();
        }
    }
}
