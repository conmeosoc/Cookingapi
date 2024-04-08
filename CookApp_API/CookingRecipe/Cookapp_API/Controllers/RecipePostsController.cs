﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookapp_API.Data;
using Cookapp_API.DataAccess.BLL;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PostDTO;
using Microsoft.Extensions.Hosting;

namespace Cookapp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipepostsController : ControllerBase
    {
        private readonly CookingRecipeDbContext _context;
        private IConfiguration _configuration;


        public RecipepostsController(CookingRecipeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Recipeposts
        [HttpGet]
        public async Task<ActionResult<List<PostDTO>>> GetRecipeposts()
        {
            if (_context.Recipeposts == null)
            {
                return NotFound();
            }
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<PostDTO> post = bll.GetPosts(new List<string>());
            return post;
        }

        // GET: api/Recipeposts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PostDTO>>> GetRecipepost(string id)
        {
          if (_context.Recipeposts == null)
          {
              return NotFound();
          }
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<PostDTO> post = bll.GetPostByID(id);
            return post;
        }
        // GET: api/Recipeposts/5
        [HttpGet("getpostbycate")]
        public async Task<ActionResult<List<PostDTO>>> GetPostbyCategory(string categoryid)
        {
          if (_context.Recipeposts == null)
          {
              return NotFound();
          }
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<PostDTO> post = bll.GetPostbyCategory(categoryid);
            return post;
        }
        [HttpGet("getpostbynutri")]
        public async Task<ActionResult<List<PostDTO>>> GetPostbyNutri(string nutri)
        {
          if (_context.Recipeposts == null)
          {
              return NotFound();
          }
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<PostDTO> post = bll.GetPostbyNutri(nutri);
            return post;
        }
        [HttpGet("getpostbyingredient")]
        public async Task<ActionResult<List<PostDTO>>> GetPostbyIngre(string ingre)
        {
          if (_context.Recipeposts == null)
          {
              return NotFound();
          }
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            List<PostDTO> post = bll.GetPostbyIngre(ingre);
            return post;
        }

        // PUT: api/Recipeposts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePostDTO>> PutRecipepost(string id, UpdatePostDTO post)
        {
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.UpdatePost(id, post);
            return post;
        }

        // POST: api/Recipeposts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreatePostDTO>> PostRecipepost(CreatePostDTO post)
        {
          if (_context.Recipeposts == null)
          {
              return Problem("Entity set 'CookingRecipeDbContext.Recipeposts'  is null.");
          }
            AllInOneBLL bll = new AllInOneBLL(_configuration["ConnectionStrings:CookappDB"], DataAccess.ESqlProvider.SQLSERVER, 120);
            bll.CreatePost(post);
            return post;
           
        }

        // DELETE: api/Recipeposts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipepost(string id)
        {
            if (_context.Recipeposts == null)
            {
                return NotFound();
            }
            var recipepost = await _context.Recipeposts.FindAsync(id);
            if (recipepost == null)
            {
                return NotFound();
            }

            _context.Recipeposts.Remove(recipepost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipepostExists(string id)
        {
            return (_context.Recipeposts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
