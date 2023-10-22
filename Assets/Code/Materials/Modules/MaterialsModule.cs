using Code.Core.App;
using Code.Materials.App;
using UnityEngine;

namespace Code.Materials.Modules {
	[CreateAssetMenu(menuName = "App/Modules/Materials")]
	public class MaterialsModule : AppModule {
		public override void OnInstall () {
			base.OnInstall();

			AppComponentInstaller.Add(new MaterialsService());
		}
	}
}
