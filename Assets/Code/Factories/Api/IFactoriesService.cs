using Code.Factories.Models;
using Code.Inventory.Models;

namespace Code.Factories.Api {
	public interface IFactoriesService {
		FactoryModel[] GetStartedFactories ();
	}
}
