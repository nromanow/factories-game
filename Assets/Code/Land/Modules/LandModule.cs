using Code.Core.App;
using Code.Factories.App;
using Code.Inventory.Models;
using Code.Inventory.UI.App;
using Code.Land.App;
using Code.Manufactures.App;
using UnityEngine;

namespace Code.Land.Modules {
	[CreateAssetMenu(menuName = "App/Modules/LandModule")]
	public class LandModule : AppModule {
		public override void OnInstall () {
			base.OnInstall();
			
			var manufacturesService = AppComponentInstaller.Resolve<ManufacturesService>();
			var manufactureLandInitializerService = AppComponentInstaller.Resolve<ManufactureLandInitializerService>();
			var inventoryModel = AppComponentInstaller.Resolve<InventoryModel>();
			var inventoryUIService = AppComponentInstaller.Resolve<InventoryUIService>();
			var factoriesService = AppComponentInstaller.Resolve<FactoriesService>();
			var factoriesLandInitializerService = AppComponentInstaller.Resolve<FactoriesLandInitializerService>();
			
			AppComponentInstaller
				.Add(new LandSceneLoaderService(
					manufacturesService, 
					factoriesService,
					manufactureLandInitializerService,
					factoriesLandInitializerService,
					inventoryModel,
					inventoryUIService));
		}

		public override void OnDestroy () {
			base.OnDestroy();
			
			AppComponentInstaller.Resolve<LandSceneLoaderService>().Dispose();
		}
	}
}
