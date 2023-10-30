using System;

namespace Code.Core.UI.ViewModels {
	public class SelectableItemViewModel<T> {
		public event Action<T> onSelect;
		
		public T item { get; }

		public SelectableItemViewModel(T item) {
			this.item = item;
		}

		public void Select () {
			onSelect?.Invoke(item);
		}
	}
}
