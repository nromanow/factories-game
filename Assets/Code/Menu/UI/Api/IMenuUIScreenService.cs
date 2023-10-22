using Code.Menu.UI.ViewModels;

namespace Code.Menu.UI.Api {
	public interface IMenuUIScreenService {
		void ShowMenuSettingsScreen (MenuManufacturesSettingsScreenViewModel viewModel);

		void ShowMenuScreen (MenuScreenViewModel viewModel);
		
		void CloseMenuScreen ();
	}
}
