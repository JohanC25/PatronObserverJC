using Microsoft.AspNetCore.Mvc;
using PatronObserverJC.Models;
using PatronObserverJC.Services;
using System.Diagnostics;

namespace PatronObserverJC.Controllers
{
	public class HomeController : Controller
	{
		private readonly IOrderService _orderService;

		public HomeController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var order = new Order()
			{
				OrderNumber = "11283A454B",
				OrderDate = DateTime.Now,
				TotalAmount = 105.99m,
				OrderStatus = OrderStatuses.PendingPayment
			};

			return View(order);
		}

		[HttpPost]
		public IActionResult Index(Order order)
		{
			Console.WriteLine("Attaching Observers...");

			var smsObserver = new SmsObserver();
			var emailObserver = new EmailObserver();

			_orderService.Attach(smsObserver);
			_orderService.Attach(emailObserver);


			Console.WriteLine("Updating Order Status...");

			_orderService.UpdateOrder(order);


			Console.WriteLine("Detaching SMS Observer...");

			_orderService.Detach(smsObserver);


			Console.WriteLine("Updating Order Status...");

			_orderService.UpdateOrder(order);

			return View(order);
		}

	}
}