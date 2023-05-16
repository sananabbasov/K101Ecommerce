using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Dashboard.ViewModels;
using Web.Data;
using Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            try
            {
                var data = _context.Socials.ToList();
                ViewData["social"] = data;
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team, List<int> SocialId, List<string> SocialUrl)
        {
            try
            {
                team.PositionId = 1;
                _context.Teams.Add(team);
                _context.SaveChanges();

                for (int i = 0; i < SocialId.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(SocialUrl[i]))
                    {
                        TeamSocial ts = new()
                        {
                            TeamId = team.Id,
                            SocialId = SocialId[i],
                            UserUrl = SocialUrl[i]
                        };
                        _context.TeamSocials.Add(ts);
                        _context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

    }
}

