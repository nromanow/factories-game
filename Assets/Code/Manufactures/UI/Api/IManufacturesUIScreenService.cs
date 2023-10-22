using Code.Manufactures.UI.ViewModels;

namespace Code.Manufactures.UI.Api {
	public interface IManufacturesUIScreenService {
		void ShowManufactureScreen (ManufactureScreenViewModel viewModel);
		void CloseManufactureScreen ();
	}
}
