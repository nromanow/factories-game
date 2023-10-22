using Code.Core.UI.Data;
using Code.Core.UI.View;
using Code.Menu.UI.ViewModels;
using UnityEngine;

namespace Code.Menu.UI.View {
	public class MenuScreenViewModelBinding : ItemViewComponent<MenuScreenViewModel> {
		[SerializeField]
		private RectTransform _paramButtonsContainer;

		[SerializeField]
		private GUIForm _paramButtonForm;

		private void Start () {
			InitParamsButtonsList();
		}

		private void InitParamsButtonsList () {
			foreach (var button in item.paramButtons) {
				Instantiate(_paramButtonForm.form.gameObject, _paramButtonsContainer)
					.GetComponentInChildren<MenuParamButtonViewModelBinding>()
					.SetItem(button);
			}
		}
		
		public void StartGame () {
			item.StartGame();
		}
		
		public void OpenSettings () {
			item.OpenSettings();
		}
	}
}
