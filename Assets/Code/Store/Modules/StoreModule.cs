using Code.Core.App;
using Code.Core.UI.App;
using Code.Currency.App;
using Code.Inventory.Models;
using Code.Store.App;
using Code.Store.Models;
using Code.Store.UI.App;
using UnityEngine;

namespace Code.Store.Modules {
	[CreateAssetMenu(menuName = "Modules/StoreModule")]
	public class StoreModule : AppModule {
		[SerializeField]
		private StoreUIScreenService.Settings _uiSettings;
		
		public override void OnInstall () {
			base.OnInstall();

			var uiScreenService = AppComponentInstaller.Resolve<UIScreenService>();
			var inventoryModel = AppComponentInstaller.Resolve<InventoryModel>();
			var currencyService = AppComponentInstaller.Resolve<CurrenciesService>();
			
			var storeUIScreenService = new StoreUIScreenService(_uiSettings, uiScreenService);
			var storeScreenService = new StoreScreenService(storeUIScreenService, inventoryModel);
			var storeInitializeLandService = new StoreInitializerLandService(storeScreenService);
			var storeModel = new StoreModel(inventoryModel, currencyService);

			AppComponentInstaller.Add(storeUIScreenService);
			AppComponentInstaller.Add(storeScreenService);
			AppComponentInstaller.Add(storeInitializeLandService);
			AppComponentInstaller.Add(storeModel);
		}
	}
}
