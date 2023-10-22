using Code.Land.Api;
using Code.Manufactures.Api;
using Code.Materials.Api;
using Code.Menu.Api;
using Code.Menu.Models;
using Code.Menu.UI.Api;
using Code.Menu.UI.ViewModels;
using System.Linq;

namespace Code.Menu.App {
	public class MenuScreenService : IMenuScreenService {
		private readonly IMaterialsService _materialsService;
		private readonly IManufacturesService _manufacturesService;
		private readonly ILandSceneLoaderService _landSceneLoaderService;
		private readonly IMenuUIScreenService _uiService;

		public MenuScreenService(
			IMaterialsService materialsService,
			IMenuUIScreenService uiService,
			IManufacturesService manufacturesService,
			ILandSceneLoaderService landSceneLoaderService) {
			_materialsService = materialsService;
			_uiService = uiService;
			_manufacturesService = manufacturesService;
			_landSceneLoaderService = landSceneLoaderService;
		}

		public void OpenMenuScreen () {
			//Mock
			var paramsButtons = new MenuParamButtonViewModel[] {
				new(1),
				new(2),
				new(3),
			};

			foreach (var button in paramsButtons) {
				button.onClick += () => {
					_manufacturesService.SetStartParameters(button.index);
					
					foreach (var instanceButton in paramsButtons) {
						instanceButton.SetSelectState(false);
					}
					
					button.SetSelectState(true);
				};
			}
			
			paramsButtons.FirstOrDefault()?.OnClick();
			
			var viewModel = new MenuScreenViewModel(paramsButtons);
			viewModel.openSettings += () => {
				var availableMaterials = _materialsService.GetAvailableMaterials();
				
				var manufacturesSettings = 
					availableMaterials
						.Select(x => new MenuManufactureSettingsModel(x))
						.ToArray();

				var settingsViewModel = new MenuManufacturesSettingsScreenViewModel(manufacturesSettings);
				_uiService.ShowMenuSettingsScreen(settingsViewModel);
			};

			viewModel.startGame += () => {
				_uiService.CloseMenuScreen();
				_landSceneLoaderService.LoadLandScene();
			};
			
			_uiService.ShowMenuScreen(viewModel);
		}
	}
}
