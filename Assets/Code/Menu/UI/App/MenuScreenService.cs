using Code.Menu.UI.ViewModels;

namespace Code.Menu.UI.App {
	public class MenuScreenService {
		void ShowMenuScreen () {
			//Lets suppose that this data comes from some server API
			var paramsButtons = new MenuParamButtonViewModel[] {
				new(1),
				new(2),
				new(3),
			};

			foreach (var button in paramsButtons) {
				button.onClick += () => {
					button.SetSelectState(true);
				};
			}
			
			var viewModel = new MenuScreenViewModel(paramsButtons);
		}
	}
}
