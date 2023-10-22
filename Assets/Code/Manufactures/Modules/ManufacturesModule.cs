using Code.Core.App;
using Code.Core.UI.App;
using Code.Manufactures.App;
using Code.Manufactures.UI.App;
using Code.Materials.App;
using UnityEngine;

namespace Code.Manufactures.Modules {
	[CreateAssetMenu(menuName = "App/Modules/Manufactures")]
	public class ManufacturesModule : AppModule {
		[SerializeField]
		private ManufacturesUIScreenService.Settings _uiSettings;
		
		public override void OnInstall () {
			base.OnInstall();

			var screenService = AppComponentInstaller
				.Resolve<UIScreenService>();
			
			var materialsService = AppComponentInstaller
				.Resolve<MaterialsService>();

			var uiService = new ManufacturesUIScreenService(_uiSettings, screenService);
			var uiScreenService = new ManufacturesScreenService(uiService);
			
			AppComponentInstaller.Add(uiService);
			AppComponentInstaller.Add(uiScreenService);
			AppComponentInstaller.Add(new ManufacturesService(materialsService));
			AppComponentInstaller.Add(new ManufactureLandInitializerService(uiScreenService));
		}
	}
}
