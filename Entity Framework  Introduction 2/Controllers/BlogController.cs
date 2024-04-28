using Entity_Framework__Introduction_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework__Introduction_2.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var db = new BlogContext();
            var a = db.Blogs.ToList();
            return View(db.Blogs.ToList());
        }

        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(AddBlog blog)
        {
            if (ModelState.IsValid)
            {
                var db = new BlogContext();
                Blog newBlog = new Blog() { Name = blog.Name, Url = blog.Url };
                db.Blogs.Add(newBlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        public IActionResult DeleteBlog(int Id)
        {
            var db = new BlogContext();
            var blog = db.Blogs.Where(b => b.Id == Id).FirstOrDefault();
            if (blog != null)
            {
                db.Blogs.Remove(blog);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
