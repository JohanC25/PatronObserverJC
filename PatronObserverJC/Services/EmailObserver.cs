using PatronObserverJC.Models;

namespace PatronObserverJC.Services
{
	public class EmailObserver : IOrderObserver
	{
		public void Update(Order order)
		{
			Console.WriteLine("Order No '{0}' status is updated to '{1}'. An email sent to customer.",
				order.OrderNumber, order.OrderStatus.ToString());
		}
	}
}
