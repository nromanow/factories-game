using Code.Core.UI.ViewModels;
using Code.Tools.Models;
using System;

namespace Code.Store.UI.ViewModels {
	public class StoreSelectToolScreenViewModel : BaseViewModel {
		public event Action<ToolModel> onToolSelected;
		public SelectableItemViewModel<ToolModel>[] tools { get; }

		public StoreSelectToolScreenViewModel(SelectableItemViewModel<ToolModel>[] tools) {
			this.tools = tools;
			
			foreach (var tool in tools) {
				tool.onSelect += SelectTool;
			}
		}

		private void SelectTool (ToolModel tool) {
			onToolSelected?.Invoke(tool);
		}
	}
}
