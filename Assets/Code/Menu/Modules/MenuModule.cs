using Code.Core.App;
using Code.Core.UI.App;
using Code.Menu.UI.App;
using UnityEngine;

namespace Code.Menu.Modules {
	[CreateAssetMenu(menuName = "App/MenuModule")]
	public class MenuModule : AppModule {
		[SerializeField]
		private MenuUIScreenService.Settings _uiSettings;
		
		public override void OnInstall () {
			base.OnInstall();
			
			var uiScreenService = AppComponentInstaller.Resolve<UIScreenService>();

			AppComponentInstaller.Add(new MenuUIScreenService(_uiSettings, uiScreenService));
		}
	}
}
