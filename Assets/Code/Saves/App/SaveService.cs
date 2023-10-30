using Code.Currency.Data;
using Code.Currency.Models;
using Code.Inventory.Models;
using Code.Materials.Data;
using Code.Materials.Models;
using Code.Saves.Api;
using Code.Saves.Data;
using Code.Tools.Data;
using Code.Tools.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using UnityEngine;

namespace Code.Saves.App {
	public class SaveService : ISaveService, IDisposable {
		private const string SAVE_INV_KEY_MATERIALS = "player_materials";
		private const string SAVE_INV_KEY_TOOLS = "player_tools";
		private const string SAVE_INV_KEY_CURRENCIES = "player_currencies";

		private readonly InventoryModel _inventoryModel;

		public SaveService (InventoryModel inventoryModel) {
			_inventoryModel = inventoryModel;

			InitializeSaves();
		}

		public void ResetAllSaves () {
			PlayerPrefs.DeleteAll();
		}

		private void InitializeSaves () {
			var materialsJsonRaw = PlayerPrefs.GetString(SAVE_INV_KEY_MATERIALS, "[]");
			var toolsJsonRaw = PlayerPrefs.GetString(SAVE_INV_KEY_TOOLS, "[]");
			var currenciesJsonRaw = PlayerPrefs.GetString(SAVE_INV_KEY_CURRENCIES, "[]");

			var materialsSaveData = JsonConvert.DeserializeObject<ItemSaveData[]>(materialsJsonRaw);
			var toolsSaveData = JsonConvert.DeserializeObject<ItemSaveData[]>(toolsJsonRaw);
			var currenciesSaveData = JsonConvert.DeserializeObject<ItemSaveData[]>(currenciesJsonRaw);

			var materials =
				materialsSaveData
					.Select(materialSaveData => {
						var materialInfo = MaterialInfo.GetInfo(materialSaveData.itemResourceId);
						return new MaterialModel(materialSaveData.itemResourceId, materialInfo);
					})
					.ToArray();

			var tools =
				toolsSaveData
					.Select(toolSaveData => {
						var toolInfo = ToolInfo.GetInfo(toolSaveData.itemResourceId);
						return new ToolModel(toolSaveData.itemResourceId, toolInfo);
					})
					.ToArray();

			var currencies =
				currenciesSaveData
					.Select(currencySaveData => {
						var currencyInfo = CurrencyInfo.GetInfo(currencySaveData.itemResourceId);
						return new CurrencyModel(currencyInfo, currencySaveData.itemResourceId, currencySaveData.amount);
					})
					.ToArray();

			var materialsInvItems =
				materials
					.Select(material => new InventoryItemModel(material, materialsSaveData.Single(x => x.itemResourceId == material.materialId).amount, material.info.sprite))
					.ToArray();

			var toolsInvItems =
				tools
					.Select(tool => new InventoryItemModel(tool, toolsSaveData.Single(x => x.itemResourceId == tool.toolId).amount, tool.info.sprite))
					.ToArray();
			
			var currenciesInvItems =
				currencies
					.Select(currency => new InventoryItemModel(currency, currenciesSaveData.Single(x => x.itemResourceId == currency.currencyId).amount, currency.currencyInfo.sprite))
					.ToArray();
			
			_inventoryModel.FillItems(materialsInvItems);
			_inventoryModel.FillItems(toolsInvItems);
			_inventoryModel.FillItems(currenciesInvItems);
		}

		private void SaveInventory () {
			var saveItems =
				_inventoryModel
					.GetItems();

			var saveMaterials =
				saveItems.Where(x => x.source is MaterialModel)
					.Select(material => new ItemSaveData {
						itemResourceId = (material.source as MaterialModel).materialId,
						amount = material.amount,
					})
					.ToArray();

			var saveTools =
				saveItems.Where(x => x.source is ToolModel)
					.Select(tool => new ItemSaveData {
						itemResourceId = (tool.source as ToolModel).toolId,
						amount = tool.amount,
					})
					.ToArray();

			var saveCurrencies =
				saveItems.Where(x => x.source is CurrencyModel)
					.Select(currency => new ItemSaveData {
						itemResourceId = (currency.source as CurrencyModel).currencyId,
						amount = currency.amount,
					})
					.ToArray();

			var saveMaterialsJsonRaw = JsonConvert.SerializeObject(saveMaterials);
			var saveToolsJsonRaw = JsonConvert.SerializeObject(saveTools);
			var saveCurrenciesJsonRaw = JsonConvert.SerializeObject(saveCurrencies);

			PlayerPrefs.SetString(SAVE_INV_KEY_MATERIALS, saveMaterialsJsonRaw);
			PlayerPrefs.SetString(SAVE_INV_KEY_TOOLS, saveToolsJsonRaw);
			PlayerPrefs.SetString(SAVE_INV_KEY_CURRENCIES, saveCurrenciesJsonRaw);
		}

		public void Dispose () {
			SaveInventory();
		}
	}
}
