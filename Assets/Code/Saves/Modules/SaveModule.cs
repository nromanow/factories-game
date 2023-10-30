using Code.Core.App;
using Code.Inventory.Models;
using Code.Saves.App;
using UnityEngine;

namespace Code.Saves.Modules {
	[CreateAssetMenu(menuName = "Modules/SaveModule")]
	public class SaveModule : AppModule {
		public override void OnInstall () {
			base.OnInstall();
			
			var inventoryModel = AppComponentInstaller.Resolve<InventoryModel>();

			AppComponentInstaller.Add(new SaveService(inventoryModel));
		}

		public override void OnDestroy () {
			base.OnDestroy();
			
			AppComponentInstaller.Resolve<SaveService>().Dispose();
		}
	}
}
