using Code.Core.App;
using Code.Currency.App;
using Code.Inventory.Models;
using UnityEngine;

namespace Code.Currency.Modules {
	[CreateAssetMenu(menuName = "Modules/CurrencyModule")]
	public class CurrencyModule : AppModule {
		public override void OnInstall () {
			base.OnInstall();

			var inventoryModel = AppComponentInstaller.Resolve<InventoryModel>();

			var currencyService = new CurrenciesService(inventoryModel);

			AppComponentInstaller.Add(currencyService);
		}
	}
}
