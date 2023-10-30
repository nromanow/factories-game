using Code.Core.View;
using Code.Materials.Models;

namespace Code.Materials.UI.View {
	public class SelectableMaterialViewModelItemViewComponent : SelectableItemViewComponentItemViewModel<MaterialModel> {
		public override void Initialize () {
			_icon.sprite = item.item.info.sprite;
		}
	}
}
