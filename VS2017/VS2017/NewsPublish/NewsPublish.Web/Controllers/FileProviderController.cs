using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace NewsPublish.Web.Controllers
{
    public class FileProviderController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private FileProviderController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        [Route("fileProvider/index")]
        public IActionResult Index()
        {
            var contents = _fileProvider.GetDirectoryContents("");
            return View(contents);
        }
    }
}