using Code.Core.App;
using Code.Core.UI.App;
using Code.Land.App;
using Code.Manufactures.App;
using Code.Materials.App;
using Code.Menu.App;
using Code.Menu.UI.App;
using UnityEngine;

namespace Code.Menu.Modules {
	[CreateAssetMenu(menuName = "App/MenuModule")]
	public class MenuModule : AppModule {
		[SerializeField]
		private MenuUIScreenService.Settings _uiSettings;
		
		public override void OnInstall () {
			base.OnInstall();
			
			var uiScreenService = AppComponentInstaller
				.Resolve<UIScreenService>();

			var menuUIService = AppComponentInstaller
				.Add(new MenuUIScreenService(_uiSettings, uiScreenService));
			
			var materialsService = AppComponentInstaller
				.Resolve<MaterialsService>();
			
			var manufacturesService = AppComponentInstaller
				.Resolve<ManufacturesService>();
			
			var landService = AppComponentInstaller
				.Resolve<LandSceneLoaderService>();
			
			AppComponentInstaller.Add(new MenuScreenService(materialsService, menuUIService, manufacturesService, landService))
				.OpenMenuScreen();
		}
	}
}
