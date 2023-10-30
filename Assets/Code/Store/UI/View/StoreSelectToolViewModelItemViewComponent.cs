using Code.Core.UI.Data;
using Code.Core.UI.View;
using Code.Store.UI.ViewModels;
using Code.Tools.UI.View;
using UnityEngine;

namespace Code.Store.UI.View {
	public class StoreSelectToolViewModelItemViewComponent : ItemViewComponent<StoreSelectToolScreenViewModel> {
		[SerializeField]
		private RectTransform _itemsRoot;
		
		[SerializeField]
		private GUIForm _selectableForm;
		
		public void Close () {
			item.CloseWindow();
		}
		public override void Initialize () {
			base.Initialize();
			
			foreach (var tool in item.tools) {
				var selectable = Instantiate(_selectableForm.form, _itemsRoot);
				selectable
					.GetComponentInChildren<SelectableToolViewModelItemViewComponent>()
					.SetItem(tool);
			}
		}
	}
}
