using Code.Manufactures.Api;
using Code.Manufactures.Models;
using Code.Manufactures.UI.Api;
using Code.Manufactures.UI.ViewModels;

namespace Code.Manufactures.App {
	public class ManufacturesScreenService : IManufacturesScreenService {
		private readonly IManufacturesUIScreenService _screenService;

		public ManufacturesScreenService (IManufacturesUIScreenService screenService) {
			_screenService = screenService;
		}

		public void ShowManufactureScreen (ManufactureModel model) {
			var viewModel = new ManufactureScreenViewModel(model);
			viewModel.closeScreen += _screenService.CloseManufactureScreen;

			_screenService.ShowManufactureScreen(viewModel);
		}
	}
}
