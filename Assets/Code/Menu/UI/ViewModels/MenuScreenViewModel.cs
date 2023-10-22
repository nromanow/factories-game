using System;

namespace Code.Menu.UI.ViewModels {
	public class MenuScreenViewModel {
		public event Action startGame;
		public event Action openSettings;

		public MenuParamButtonViewModel[] paramButtons { get; }

		public MenuScreenViewModel (MenuParamButtonViewModel[] paramButtons) {
			this.paramButtons = paramButtons;
		}

		public void StartGame () {
			startGame?.Invoke();
		}

		public void OpenSettings () {
			openSettings?.Invoke();
		}
	}
}
