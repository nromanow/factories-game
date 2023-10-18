using Code.Core.UI.App;
using Code.Core.UI.Data;
using UnityEngine;

namespace Code.Core.App {
	[CreateAssetMenu(menuName = "App/BaseAppModule")]
	public class BaseAppModule : AppModule {
		[SerializeField]
		private GUIBase _guiBasePrefab;
		
		public override void OnInstall () {
			base.OnInstall();

			var guiBaseInstance = GameObject.Instantiate(_guiBasePrefab);
			
			DontDestroyOnLoad(guiBaseInstance);
			
			AppComponentInstaller.Add(new UIScreenService(guiBaseInstance));
		}
	}
}
