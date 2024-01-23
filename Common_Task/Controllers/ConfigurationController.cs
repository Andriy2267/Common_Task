using Common_Task.DB;
using Common_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Common_Task.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly AppDbContext _context;

        public ConfigurationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var configuration = _context.ConfigurationItems.Include(c => c.Children).FirstOrDefault(c => c.ParentId == null);
            return View(configuration);
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return RedirectToAction("Index");
            }

            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    ConfigurationItem newItem = new ConfigurationItem
                    {
                        Key = parts[0],
                        Value = parts[parts.Length - 1]
                    };

                    _context.ConfigurationItems.Add(newItem);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
