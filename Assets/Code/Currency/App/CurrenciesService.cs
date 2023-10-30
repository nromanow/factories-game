using Code.Currency.Api;
using Code.Currency.Data;
using Code.Currency.Models;
using Code.Inventory.Models;
using System;
using System.Linq;
using UnityEngine;

namespace Code.Currency.App {
	public class CurrenciesService : ICurrenciesService {
		public event Action<CurrencyModel> onCurrencyChanged;
		
		private readonly InventoryModel _inventoryModel;

		public CurrenciesService (InventoryModel inventoryModel) {
			_inventoryModel = inventoryModel;
		}

		public void AddCurrency (string currencyId, int value) {
			var currencyInfo = CurrencyInfo.GetInfo(currencyId);
			
			if (currencyInfo == null) {
				var exception = new ArgumentException($"Currency with id {currencyId} not found");
				Debug.LogException(exception);
				throw exception;
			}

			var allCurrency =
				_inventoryModel
					.GetItemsBySourceType(typeof(CurrencyModel));
			
			var targetCurrency =
				allCurrency
					.Select(x => x.source as CurrencyModel)
					.SingleOrDefault(model => model.currencyInfo == currencyInfo);

			if (targetCurrency == null) {
				targetCurrency = new CurrencyModel(currencyInfo, currencyId, value);
				_inventoryModel
					.AddItem(
						new InventoryItemModel(
							targetCurrency, 
							targetCurrency.value, 
							currencyInfo.sprite));
			}
			else {
				targetCurrency.IncreaseValue(value);
				var invItem = allCurrency.Single(x => x.source == targetCurrency);
				invItem.SetAmount(targetCurrency.value);
			}
			
			onCurrencyChanged?.Invoke(targetCurrency);
		}
	}
}
