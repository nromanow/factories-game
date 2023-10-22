using System;

namespace Code.Core.UI.ViewModels {
	public class BaseViewModel {
		public event Action closeWindow;
		
		public void CloseWindow () {
			closeWindow?.Invoke();
		}
	}
}
