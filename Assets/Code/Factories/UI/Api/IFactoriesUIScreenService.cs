using Code.Factories.UI.ViewModels;

namespace Code.Factories.UI.Api {
	public interface IFactoriesUIScreenService {
		void ShowFactoryScreen (FactoryScreenViewModel viewModel);
		void CloseFactoryScreen ();
		void ShowSelectMaterialPopup (FactorySelectMaterialPopupViewModel viewModel);
		void CloseSelectMaterialPopup ();
	}
}
