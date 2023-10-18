namespace Code.Menu.UI.ViewModels {
	public class MenuScreenViewModel {
		public MenuParamButtonViewModel[] paramButtons { get; }

		public MenuScreenViewModel(MenuParamButtonViewModel[] paramButtons) {
			this.paramButtons = paramButtons;
		}
	}
}
