using UnityEngine;

namespace Code.Core.UI.View {
	public abstract class ItemViewComponent<T> : MonoBehaviour {
		public T item { get; private set; }

		public void SetItem (T value) {
			item = value;
		}
	}
}
