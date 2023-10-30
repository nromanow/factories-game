using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Inventory.Models {
	public class InventoryModel {
		private readonly List<InventoryItemModel> _items = new();

		public event Action onItemsChanged;
		
		public bool HasItemBySourceType (Type sourceType) {
			return _items.Any(i => i.source.GetType() == sourceType);
		}
		
		public InventoryItemModel[] GetItemsBySourceType (Type sourceType) {
			return _items.Where(i => i.source.GetType() == sourceType).ToArray();
		}
		
		public bool HasItemBySourceType<T> (T sourceType, out InventoryItemModel item) {
			item = _items.SingleOrDefault(i => i.source.Equals(sourceType));
			return item != null;
		}

		public InventoryItemModel[] GetItems () {
			return _items.ToArray();
		}
		
		public void AddItem (InventoryItemModel item) {
			if (_items.Contains(item)) {
				var exception = new Exception($"Item {item} already exists in inventory");
				throw exception;
			}
			
			_items.Add(item);
			onItemsChanged?.Invoke();
		}
		
		public void RemoveItem (InventoryItemModel item) {
			_items.Remove(item);
			onItemsChanged?.Invoke();
		}
	}

	public static class InvExtensions {
		public static void FillItems (this InventoryModel inventory, IEnumerable<InventoryItemModel> items) {
			foreach (var item in items) {
				inventory.AddItem(item);
			}
		}
	}
}
