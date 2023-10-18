using UnityEngine;

namespace Code.Core.Data {
	public static class ItemsList {
		public static T GetItem<T> (string itemName) where T : ItemInfo {
			return Resources.Load<T>($"Items/{nameof(T) + itemName}");
		}
	}
}
