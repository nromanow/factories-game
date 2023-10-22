using Code.Core.UI.View;
using Code.Inventory.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Inventory.UI.View {
	public class InventoryItemModelView : ItemViewComponent<InventoryItemModel> {
		[SerializeField]
		private Image _icon;
		
		[SerializeField]
		private TextMeshProUGUI _amountText;
		
		public override void Initialize () {
			base.Initialize();
			
			_icon.sprite = item.icon;
			_amountText.text = item.amount.ToString();
			
			item.onAmountChanged += OnAmountChanged;
		}

		private void OnAmountChanged () {
			_amountText.text = item.amount.ToString();
		}
	}
}
