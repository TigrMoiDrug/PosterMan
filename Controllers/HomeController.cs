using ExploringCalifornia2.Data;
using ExploringCalifornia2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace PosterMan.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogData _db;
        readonly UserManager<IdentityUser> _userManager;
        public HomeController(BlogData db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("blog")]
        public ViewResult Blog()
        {
            return View("Blog", _db.Posts.ToList());
        }
        [Route("")]
        public ViewResult Back()
        {
            return View("Index");
        }

        [Authorize]
        [HttpGet, Route("newPost")]
        public ViewResult Create()
        {
            return View("CreatePost");
        }

        [Authorize]
        [HttpPost, Route("newPost")]
        public IActionResult CreatePost(Post post)
        {
            var userName = _userManager.FindByNameAsync(User.Identity.Name).Result.UserName;
            post.UserName = userName;
            post.DateTimeStamp = DateTime.Now.ToString("MM dd yyyy hh:mm tt");
            _db.Posts.Add(post);
            _db.SaveChanges();
            return View("Blog", _db.Posts.ToList());
        }

        [HttpPost, Route("blog")]
        public IActionResult OnPostRemove(int id)
        {
            _db.Posts.Remove(_db.Posts.Find(id));
            _db.SaveChanges();
            return View("Blog", _db.Posts.ToList());
        }

        [HttpGet]
        public IActionResult SetBackgroundForBlogPage()
        {
            string img = null;
            if (Url.ToString().Contains("newPost"))
            {
                img = $@"Content\gradient-blue.jpg";
            }
            return File(img, "image/jpeg");
        }

    }
}
