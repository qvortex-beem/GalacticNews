using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GalacticNews.Data;
using GalacticNews.Models;

namespace GalacticNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly AppDbContext _context;
        private const int PageSize = 4;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            int totalNews = _context.News.Count();
            int totalPages = (int)Math.Ceiling(totalNews / (double)PageSize);
            ViewBag.PageSize = PageSize;

            var newsPage = _context.News
                .OrderByDescending(n => n.Date)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(newsPage);
        }

        public IActionResult Details(int id, int? page)
        {
            var news = _context.News.FirstOrDefault(n => n.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            ViewBag.ReturnPage = page ?? 1;
            return View(news);
        }
    }
}