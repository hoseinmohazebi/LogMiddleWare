using AutoMapper;
using AutoMapper.QueryableExtensions;
using LogMiddleWare.Data.Entities;
using LogMiddleWare.Models;
using LogMiddleWare.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LogMiddleWare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<LogEvent> _logEvent;
        private readonly IBaseRepository<IdentityUser> _userRepo;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IBaseRepository<LogEvent> logEvent, IBaseRepository<IdentityUser> userRepo, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _logEvent = logEvent;
            _userRepo = userRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = new IdentityUser { 
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            };

            //PasswordHash =_userManager.PasswordHasher("Admin123")
            var model = new HomeVm();

            model.Logs = await _logEvent.TableNoTracking.ProjectTo<LogVm>(_mapper.ConfigurationProvider).OrderByDescending(t => t.Id).ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string? search)
        {
            var model = new HomeVm();
            var query = _logEvent.TableNoTracking;
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(t => t.UserName.Contains(search) || t.Event.Contains(search));
                }
            }
            model.Logs = await query.ProjectTo<LogVm>(_mapper.ConfigurationProvider).OrderByDescending(t => t.Id).ToListAsync();
            return Ok(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}