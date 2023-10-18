using System;
using UnityEngine;

namespace Code.Core.View {
	public class InteractableLandItemView<T> : MonoBehaviour where T : class {
		public T item { get; private set; }
		public event Action onItemClicked;
		
		public void SetItem (T target, Action onInteract) {
			this.item = target;
			this.onItemClicked += onInteract;
		}

		private void OnMouseDown () {
			onItemClicked?.Invoke();
		}
	}
}
