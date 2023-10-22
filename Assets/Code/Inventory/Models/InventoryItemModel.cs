using System;
using UnityEngine;

namespace Code.Inventory.Models {
	public class InventoryItemModel {
		public event Action onAmountChanged;
		public object source { get; }
		public int amount { get; private set; }
		public Sprite icon { get; }

		public InventoryItemModel(object source, int amount, Sprite icon) {
			this.source = source;
			this.amount = amount;
			this.icon = icon;
		}
		
		public void SetAmount (int amount) {
			this.amount = amount;
			onAmountChanged?.Invoke();
		}
	}
}
