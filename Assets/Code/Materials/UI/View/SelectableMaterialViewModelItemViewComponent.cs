using Code.Core.UI.View;
using Code.Materials.UI.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Materials.UI.View {
	public class SelectableMaterialViewModelItemViewComponent : ItemViewComponent<SelectableMaterialViewModel> {
		[SerializeField]
		private Image _icon;

		public void Select () {
			item.Select();
		}
		
		public override void Initialize () {
			_icon.sprite = item.model.info.sprite;
		}
	}
}
