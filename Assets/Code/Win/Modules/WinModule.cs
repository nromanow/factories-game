using Code.Core.App;
using Code.Core.UI.App;
using Code.Currency.App;
using Code.Win.App;
using Code.Win.UI.App;
using UnityEngine;

namespace Code.Win.Modules {
	[CreateAssetMenu(menuName = "Modules/WinModule")]
	public class WinModule : AppModule {
		[SerializeField]
		private WinUIService.Settings _winUISettings;

		public override void OnInstall () {
			base.OnInstall();

			var uiService = AppComponentInstaller.Resolve<UIScreenService>();
			var currenciesService = AppComponentInstaller.Resolve<CurrenciesService>();
			
			var winUIService = new WinUIService(_winUISettings, uiService);
			var winService = new WinService(currenciesService, winUIService);

			//TODO: Replace it to settings
			winService.SetCurrencyWin("Hard", 10);
			
			AppComponentInstaller.Add(winService);
			AppComponentInstaller.Add(winUIService);
		}
	}
}
