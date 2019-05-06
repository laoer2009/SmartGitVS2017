using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Web.Models;
namespace NewsPublish.Web.Controllers
{
    public class RedisChatsController : Controller
    {
        public IActionResult Index()
        {
          
            var redisClient = new RedisHelper(2);
            ViewBag.BagInfo = "this page is home";
            ChartModels isError = null;
            ViewData["Pop"] = MessageQueue.CurrentChatModels == null ? "没有记录" : MessageQueue.CurrentChatModels.Chat;
            var q = redisClient.ListRightPop<ChartModels>("MessageQuene");
        
            ViewData["MessageQuene"] = q ?? (isError=new ChartModels());

            ViewData["aa"] = "内容";
            return View();
        }
        [HttpPost]
        public ActionResult Index(ChartModels form)
        {
            var redisClient = new RedisHelper(2);
            List<ChartModels> isError = null;

            Task<long> t=   redisClient.ListLeftPushAsync<ChartModels>("MessageQuene",new ChartModels() {UserId = form.UserId, Chat = form.Chat});
    
            //消息入列
           // redisClient.ListLeftPush("MessageQuene", new ChartModels() {UserId = form.UserId, Chat = form.Chat});
            //var q = redisClient.ListRightPop<ChartModels>("MessageQuene");
            Task<ChartModels> t3 =  redisClient.ListLeftPopAsync<ChartModels>("MessageQuene");

            long t2 = t.Result;
            var q = t3.Result;
            ViewData["MessageQuene"] = q;

            ViewData["aa"] = q == null ? "q" : q.Chat;
            return View();
        }
    }
}