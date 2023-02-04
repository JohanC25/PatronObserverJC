using PatronObserverJC.Models;

namespace PatronObserverJC.Services
{
	public interface IOrderObserver
	{
		void Update(Order order);
	}
}
