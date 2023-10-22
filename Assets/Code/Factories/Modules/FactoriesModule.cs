using Code.Core.App;
using Code.Core.UI.App;
using Code.Factories.App;
using Code.Factories.UI.App;
using Code.Inventory.Models;
using UnityEngine;

namespace Code.Factories.Modules {
	[CreateAssetMenu(menuName = "App/Modules/Factories")]
	public class FactoriesModule : AppModule {
		[SerializeField]
		private FactoriesUIScreenService.Settings _uiSettings;

		public override void OnInstall () {
			base.OnInstall();

			var baseUiScreenService = AppComponentInstaller.Resolve<UIScreenService>();
			var inventory = AppComponentInstaller.Resolve<InventoryModel>();
			
			var factoriesService = new FactoriesService(inventory);
			var uiService = new FactoriesUIScreenService(_uiSettings, baseUiScreenService);
			var screenService = new FactoriesScreenService(uiService, inventory);
			var landInitializer = new FactoriesLandInitializerService(screenService);

			AppComponentInstaller.Add(factoriesService);
			AppComponentInstaller.Add(uiService);
			AppComponentInstaller.Add(screenService);
			AppComponentInstaller.Add(landInitializer);
		}
	}
}
