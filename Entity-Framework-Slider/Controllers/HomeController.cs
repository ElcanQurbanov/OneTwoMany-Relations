using Entity_Framework_Slider.Data;
using Entity_Framework_Slider.Models;
using Entity_Framework_Slider.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Entity_Framework_Slider.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
			_context = context;
        }

        public async Task<IActionResult> Index()
		{
			List<Slider> sliders = await _context.Sliders.ToListAsync();

            //IQueryable<Slider> slide = _context.Sliders.AsQueryable();
            //List<Slider> query = slide.Where(m => m.Id > 5).ToList();

            //List<Blog>	blogs = await _context.Blogs.Where(m=> !m.SoftDelete && m.Id >2 ).ToListAsync();

            SliderInfo sliderInfo = await _context.SliderInfos.FirstOrDefaultAsync();

			IEnumerable<Blog> blogs = await _context.Blogs.Where(m=> !m.SoftDelete).ToListAsync();

			IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();

			IEnumerable<Product> products = await _context.Products.Include(m=>m.Images).Where(m => !m.SoftDelete).ToListAsync();

			About about = await _context.Abouts.Where(m => !m.SoftDelete).FirstOrDefaultAsync();


            IEnumerable<Advantage> advantages = await _context.Advantages.Where(m => !m.SoftDelete).ToListAsync();


            IEnumerable<Instagram> instagram = await _context.instagrams.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Say> says = await _context.says.Where(m => !m.SoftDelete).ToListAsync();




            List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6 };

			var res = nums.FirstOrDefault();
			ViewBag.num = res;

			HomeVM model = new()
			{
				Sliders = sliders,
				SliderInfo = sliderInfo,
				Blogs = blogs,
				Categories = categories,
				Products = products,
				Advantages = advantages,
				About = about,
				Instagrams = instagram,
				
				says = says,

			};
			
			return View(model);
		}
	}
}