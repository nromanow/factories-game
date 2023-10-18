using Code.Core.UI.View;
using Code.Materials.Models;
using Code.Menu.Models;

namespace Code.Menu.UI.View {
	public class MenuManufactureSettingsComponentModel : ItemViewComponent<MenuManufactureSettingsModel> {
		public MaterialModel material => item.material;
		
		public void SetTime (int time) {
			item.SetTime(time);
		}
	}
}
