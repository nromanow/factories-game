using Code.Materials.Models;

namespace Code.Menu.Models {
	public class MenuManufactureSettingsModel {
		public MaterialModel material { get; }
		public int deltaTime { get; private set; }

		public MenuManufactureSettingsModel(MaterialModel material) {
			this.material = material;
		}

		public void SetTime (int time) {
			deltaTime = time;
		}
	}
}
