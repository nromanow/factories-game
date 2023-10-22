using Code.Core.App;
using Code.Core.UI.App;
using Code.Inventory.Models;
using Code.Inventory.UI.App;
using UnityEngine;

namespace Code.Inventory.Modules {
	[CreateAssetMenu(menuName = "Modules/Inventory")]
	public class InventoryModule : AppModule {
		[SerializeField]
		private InventoryUIService.Settings _uiSettings;

		public override void OnInstall () {
			base.OnInstall();

			var uiScreenService = AppComponentInstaller.Resolve<UIScreenService>();
			
			AppComponentInstaller.Add(new InventoryModel());
			AppComponentInstaller.Add(new InventoryUIService(_uiSettings, uiScreenService));
		}
	}
}
