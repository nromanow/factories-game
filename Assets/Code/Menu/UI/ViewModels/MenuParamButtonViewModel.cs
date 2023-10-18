using System;

namespace Code.Menu.UI.ViewModels {
	public class MenuParamButtonViewModel {
		public event Action onClick;
		public int index { get; }
		public bool isSelected { get; private set; }

		public MenuParamButtonViewModel(int index) {
			this.index = index;
		}

		public void SetSelectState (bool selectState) {
			this.isSelected = selectState;
		}
	}
}
