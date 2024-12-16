using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirstRelation.Models;
using CodeFirstRelation.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CodeFirstRelation.Data;

namespace CodeFirstRelation.Controllers
{
    // api/Post
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PatikaSecondDbContext _context;

        public PostController(PatikaSecondDbContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts()
        {
            return await _context.Posts
                .Include(p => p.User)
                .Select(p => new PostDto
                {
                    Title = p.Title,
                    Content = p.Content,
                    UserId = p.UserId
                })
                .ToListAsync();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            var post = await _context.Posts
                .Include(p => p.User)
                .Where(p => p.Id == id)
                .Select(p => new PostDto
                {
                    Title = p.Title,
                    Content = p.Content,
                    UserId = p.UserId
                })
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost([FromBody] PostDto postDto)
        {
            // Kullanıcı var mı kontrol et
            var user = await _context.Users.FindAsync(postDto.UserId);
            if (user == null)
                return BadRequest("Geçersiz kullanıcı kimliği.");

            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                UserId = postDto.UserId,
                User = user
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, postDto);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDto postDto)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            // Kullanıcı var mı kontrol et
            var user = await _context.Users.FindAsync(postDto.UserId);
            if (user == null)
                return BadRequest("Geçersiz kullanıcı kimliği.");

            post.Title = postDto.Title;
            post.Content = postDto.Content;
            post.UserId = postDto.UserId;
            post.User = user;

            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}