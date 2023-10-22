using Code.Factories.Api;
using Code.Factories.Models;
using Code.Inventory.Models;

namespace Code.Factories.App {
	public class FactoriesService : IFactoriesService {
		private readonly InventoryModel _inventory;

		public FactoriesService(InventoryModel inventory) {
			_inventory = inventory;
		}

		public FactoryModel[] GetStartedFactories () {
			return new[] { new FactoryModel(_inventory) };
		}
	}
}
