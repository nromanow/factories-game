using Code.Store.UI.ViewModels;

namespace Code.Store.UI.Api {
	public interface IStoreUIScreenService {
		void ShowStoreScreen (StoreScreenViewModel viewModel);
		
		void CloseStoreScreen ();
		
		void ShowSelectedStoreScreen (StoreSelectToolScreenViewModel viewModel);
		
		void CloseSelectedStoreScreen ();
	}
}
