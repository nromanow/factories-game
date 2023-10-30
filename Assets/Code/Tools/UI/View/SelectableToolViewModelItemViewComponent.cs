using Code.Core.View;
using Code.Tools.Models;

namespace Code.Tools.UI.View {
	public class SelectableToolViewModelItemViewComponent : SelectableItemViewComponentItemViewModel<ToolModel> {
		public override void Initialize () {
			base.Initialize();
			
			_icon.sprite = item.item.info.sprite;
		}
	}
}
