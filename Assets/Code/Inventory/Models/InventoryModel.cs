using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Inventory.Models {
	public class InventoryModel {
		public List<InventoryItemModel> items { get; } = new();

		public event Action onItemsChanged;
		
		public bool HasItemBySourceType (Type sourceType) {
			return items.Any(i => i.source.GetType() == sourceType);
		}
		
		public InventoryItemModel[] GetItemsBySourceType (Type sourceType) {
			return items.Where(i => i.source.GetType() == sourceType).ToArray();
		}
		
		public bool HasItemBySourceType<T> (T sourceType, out InventoryItemModel item) {
			item = items.SingleOrDefault(i => i.source.Equals(sourceType));
			return item != null;
		}
		
		public void AddItem (InventoryItemModel item) {
			items.Add(item);
			onItemsChanged?.Invoke();
		}
		
		public void RemoveItem (InventoryItemModel item) {
			items.Remove(item);
			onItemsChanged?.Invoke();
		}
	}
}
