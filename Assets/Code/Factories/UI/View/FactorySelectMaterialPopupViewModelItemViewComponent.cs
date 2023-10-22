using Code.Core.UI.Data;
using Code.Core.UI.View;
using Code.Factories.UI.ViewModels;
using Code.Materials.UI.View;
using UnityEngine;

namespace Code.Factories.UI.View {
	public class FactorySelectMaterialPopupViewModelItemViewComponent : ItemViewComponent<FactorySelectMaterialPopupViewModel> {
		[SerializeField]
		private RectTransform _itemsRoot;
		
		[SerializeField]
		private GUIForm _selectableForm;

		public void Close () {
			item.CloseWindow();
		}
		
		public override void Initialize () {
			base.Initialize();
			
			foreach (var material in item.materials) {
				var selectable = Instantiate(_selectableForm.form, _itemsRoot);
				selectable
					.GetComponentInChildren<SelectableMaterialViewModelItemViewComponent>()
					.SetItem(material);
			}
		}
	}
}
