using Code.Core.UI.View;
using Code.Core.UI.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Core.View {
	public class SelectableItemViewComponentItemViewModel<T> : ItemViewComponent<SelectableItemViewModel<T>> {
		[SerializeField]
		protected Image _icon;

		public void Select () {
			item.Select();
		}
	}
}
