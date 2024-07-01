﻿using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			var data = new TestViewModel
			{
				Name = "Andy",
				DateOfBirth = new DateTime(2001,07,19)
			};
			return View(data);
		}
	}
}
