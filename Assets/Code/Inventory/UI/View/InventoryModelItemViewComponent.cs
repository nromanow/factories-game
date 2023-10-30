using Code.Core.UI.Data;
using Code.Core.UI.View;
using Code.Inventory.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Inventory.UI.View {
	public class InventoryModelItemViewComponent : ItemViewComponent<InventoryModel> {
		[SerializeField]
		private RectTransform _contentRoot;
		
		[SerializeField]
		private GUIForm _inventoryItemForm;
		
		private List<GameObject> _items = new();

		public override void Initialize () {
			base.Initialize();
			
			OnItemsChanged();
			item.onItemsChanged += OnItemsChanged;
		}

		private void OnItemsChanged () {
			foreach (var itemChild in _items) {
				Destroy(itemChild);
			}
			
			_items.Clear();
			
			foreach (var inventoryItem in item.items) {
				var inventoryItemView = Instantiate(_inventoryItemForm.form, _contentRoot);
				inventoryItemView
					.GetComponentInChildren<InventoryItemModelView>()
					.SetItem(inventoryItem);
				
				_items.Add(inventoryItemView.gameObject);
			}
		}
	}
}
