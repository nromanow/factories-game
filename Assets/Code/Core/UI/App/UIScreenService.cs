using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Core.UI.View;
using UnityEngine;

namespace Code.Core.UI.App {
	public class UIScreenService : IUIScreenService {
		private readonly GUIBase _guiBase;

		public UIScreenService(GUIBase guiBase) {
			_guiBase = guiBase;
		}

		public void ShowScreen<T> (GUIForm form, T argument) {
			var instance = Object.Instantiate(form.form.gameObject, _guiBase.baseLayer.transform);

			instance.GetComponentInChildren<ItemViewComponent<T>>()?.SetItem(argument);
		}
	}
}
