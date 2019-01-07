using Microsoft.AspNetCore.Mvc;
using OnlineFishShop.Data.Models;
using OnlineFishShop.Services.Contracts;
using System.Threading.Tasks;

namespace OnlineFishShop.Web.Areas.Blog.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;

    [Area("Blog")]
    public class HomeController : Controller
    {
        private readonly IGenericDataService<BlogPost> _blogPosts;
        private readonly IGenericDataService<BlogComment> _blogComments;

        public HomeController(IGenericDataService<BlogPost> blogPosts, IGenericDataService<BlogComment> blogComment)
        {
            _blogPosts = blogPosts;
            _blogComments = blogComment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blogPosts.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPost blogPost)
        {
            _blogPosts.Add(blogPost);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _blogPosts.GetSingleOrDefaultAsync(m => m.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            blogPost.Comments.OrderBy(c => c.DateAdded);

            return View(blogPost);
        }

        public IActionResult AddComment(int blogId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var blogComment = new BlogComment()
            {
                BlogPostId = blogId,
                UserId = userId
            };
            
            return View(blogComment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var blogPost = await _blogPosts.GetSingleOrDefaultAsync(bp => bp.Id == id);
            var currentBlogComments = (await _blogComments.GetListAsync(bc => bc.BlogPostId == id)).ToArray();

            _blogComments.Remove(currentBlogComments);
            _blogPosts.Remove(blogPost);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteComment(int commentId, int blogId)
        {
            var currentBlogComment = await _blogComments.GetSingleOrDefaultAsync(bc => bc.Id == commentId);

            _blogComments.Remove(new BlogComment[]{currentBlogComment});

            return RedirectToAction("Details", new {id = blogId});
        }

        [HttpPost]
        public IActionResult AddComment(BlogComment blogComment)
        {
            blogComment.DateAdded = DateTime.Now;
        
            _blogComments.Add(new BlogComment[]{blogComment});

            return RedirectToAction("Details", new {id = blogComment.BlogPostId});
        }

        public async Task<IActionResult> Edit(int id)
        {
            var blogPost = await _blogPosts.GetSingleOrDefaultAsync(bp => bp.Id == id);

            return View(blogPost);
        }

        public async Task<IActionResult> EditComment(int id)
        {
            var blogPost = await _blogComments.GetSingleOrDefaultAsync(bp => bp.Id == id);

            return View(blogPost);
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(BlogComment blogComment)
        {
            _blogComments.Update(blogComment);

            var currentBlogComment = await _blogComments.GetSingleOrDefaultAsync(bc => bc.Id == blogComment.Id);

            currentBlogComment.DateEdited = DateTime.Now;
            currentBlogComment.IsEdited = true;

            _blogComments.Update(currentBlogComment);

            return RedirectToAction("Details",new {id = blogComment.BlogPostId});
        }

        [HttpPost]
        public IActionResult Edit(BlogPost blogPost)
        {
            _blogPosts.Update(blogPost);

            return RedirectToAction("Index");
        }
    }
}