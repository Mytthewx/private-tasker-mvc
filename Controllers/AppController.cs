using Microsoft.AspNetCore.Mvc;
using PrivateTasker.Data;
using System;
using System.Linq;

namespace PrivateTasker.Controllers
{
	public class AppController : Controller
	{
		private readonly TaskerContext context;

		public AppController(TaskerContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			var results = context.Notes.ToList();
			return View();
		}

		public IActionResult Contact()
		{
			ViewBag.Title = "Contact Me";
			return View();
		}

		public IActionResult TaskManager()
		{
			ViewBag.Title = "Task Manager";
			return View();
		}

		public IActionResult Notebook()
		{
			var results = context.Notes.ToList();
			return View(results);
		}
	}
}
