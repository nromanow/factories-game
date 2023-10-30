using Code.Currency.Api;
using Code.Inventory.Models;
using Code.Tools.Models;
using System;
using System.Linq;

namespace Code.Store.Models {
	public class StoreModel {
		public event Action onToolSelected;
		public ToolModel selectedTool { get; private set; }

		private readonly InventoryModel _inventoryModel;
		private readonly ICurrenciesService _currenciesService;

		public StoreModel (InventoryModel inventoryModel, ICurrenciesService currenciesService) {
			_inventoryModel = inventoryModel;
			_currenciesService = currenciesService;
		}

		public void SelectTool (ToolModel tool) {
			selectedTool = tool;
			onToolSelected?.Invoke();
		}

		public void SellTool () {
			if (selectedTool == null) return;
			
			var targetInvItem =
				_inventoryModel
					.GetItemsBySourceType(typeof(ToolModel))
					.SingleOrDefault(x => x.source as ToolModel == selectedTool);
				
			if (targetInvItem is not { amount: > 0 }) return;
			
			targetInvItem.SetAmount(targetInvItem.amount - 1);
				
			_currenciesService.AddCurrency(selectedTool.info.sellCurrencyType, selectedTool.info.sellPrice);
		}
	}
}
