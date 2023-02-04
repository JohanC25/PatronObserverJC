using PatronObserverJC.Models;

namespace PatronObserverJC.Services
{
	public interface IOrderService : IOrderNotifier
	{
		void UpdateOrder(Order order);
	}
}
