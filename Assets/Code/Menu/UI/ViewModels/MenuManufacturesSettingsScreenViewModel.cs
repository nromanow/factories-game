using Code.Menu.Models;

namespace Code.Menu.UI.ViewModels {
	public class MenuManufacturesSettingsScreenViewModel {
		public MenuManufactureSettingsModel[] manufactures { get; }
		
		public MenuManufacturesSettingsScreenViewModel (MenuManufactureSettingsModel[] manufactures) {
			this.manufactures = manufactures;
		}
	}
}
