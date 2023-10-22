using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Inventory.Models {
	public class InventoryModel {
		public List<InventoryItemModel> items { get; } = new();

		public event Action onItemsChanged;
		
		public bool HasItemBySourceType<T> (T sourceType) {
			return items.Any(i => i.source.Equals(sourceType));
		}
		
		public InventoryItemModel[] GetItemsBySourceType<T> (T sourceType) {
			return items.Where(i => i.source.Equals(sourceType)).ToArray();
		}
		
		public bool HasItemBySourceType<T> (T sourceType, out InventoryItemModel item) {
			item = items.SingleOrDefault(i => i.source.Equals(sourceType));
			return item != null;
		}
		
		public void AddItem (InventoryItemModel item) {
			if (HasItemBySourceType(item.source, out var invItem)) {
				invItem.SetAmount(invItem.amount + item.amount);
				return;
			}
			
			items.Add(item);
			onItemsChanged?.Invoke();
		}
		
		public void RemoveItem (InventoryItemModel item) {
			items.Remove(item);
			onItemsChanged?.Invoke();
		}
	}
}
