using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Model.Response;
using NewsPublish.Service;
using NewsPublish.Web.Models;

namespace NewsPublish.Web.Controllers
{
    public class HomeController : Controller
    {
        private NewsService _newsService;
        private BannerService _bannerService;
        public HomeController(NewsService newsService, BannerService bannerService)
        {
            this._newsService = newsService;
            this._bannerService = bannerService;
        }

        public ActionResult Index()
        {
            ViewData["Title"] = "首页";
            return View(_newsService.GetNewsClassifyList());
        }
        [HttpGet]
        public JsonResult GetBanner()
        {
            return Json(_bannerService.GetBannerList());
        }
        [HttpGet]
        public JsonResult GetTotalNews()
        {
            return Json(_newsService.GetNewsCount(c => true));
        }
        [HttpGet]
        public JsonResult GetHomeNews()
        {
            return Json(_newsService.GetNewsList(c => true, 6));
        }
        [HttpGet]
        public JsonResult GetNewCommentNewsList()
        {
            return Json(_newsService.GetNewCommentNewsList(c => true, 5));
        }
        [HttpGet]
        public JsonResult SearchOneNews(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return Json(new ResponseModel { code = 0, result = "关键字不能为空" });
            return Json(_newsService.GetSearchOneNews(c => c.Title.Contains(keyword)));
        }
        public ActionResult Wrong()
        {
            ViewData["Title"] = "404";
            return View(_newsService.GetNewsClassifyList());
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your contact page.";
            ViewData["Title"] = "aaa";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current.Id });
        }
        public IActionResult StatusCodePagesWithReExcute(int? code)
        {
            if(code.HasValue)
            {
                if(code.Value==404|| code.Value == 500)
                {
                    return View(nameof(StatusCodePagesWithReExcute), code.ToString());
                }
            }
            return View();
        }
        public IActionResult ErrorIndex()
        {
            throw new Exception("出错啦……");
        }
    }
}