using Code.Factories.Api;
using Code.Inventory.Models;
using Code.Inventory.UI.Api;
using Code.Land.Api;
using Code.Manufactures.Api;
using Code.Materials.Models;
using Code.Store.Api;
using Code.Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Land.App {
	public class LandSceneLoaderService : ILandSceneLoaderService, IDisposable {
		private readonly IManufacturesService _manufacturesService;
		private readonly IFactoriesService _factoriesService;
		private readonly IManufactureLandInitializerService _manufactureLandInitializerService;
		private readonly IFactoriesLandInitializerService _factoriesLandInitializerService;
		private readonly IStoreInitializerLandService _storeInitializerLandService;
		private readonly StoreModel _storeModel;
		private readonly InventoryModel _inventoryModel;
		private readonly IInventoryUIService _inventoryUIService;
		private readonly List<IDisposable> _disposables = new();

		public LandSceneLoaderService(
			IManufacturesService manufacturesService, 
			IFactoriesService factoriesService,
			IManufactureLandInitializerService manufactureLandInitializerService,
			IFactoriesLandInitializerService factoriesLandInitializerService,
			IStoreInitializerLandService storeInitializerLandService,
			StoreModel storeModel,
			InventoryModel inventoryModel,
			IInventoryUIService inventoryUIService) {
			_manufacturesService = manufacturesService;
			_factoriesService = factoriesService;
			_manufactureLandInitializerService = manufactureLandInitializerService;
			_factoriesLandInitializerService = factoriesLandInitializerService;
			_storeInitializerLandService = storeInitializerLandService;
			_storeModel = storeModel;
			_inventoryModel = inventoryModel;
			_inventoryUIService = inventoryUIService;
		}

		public void LoadLandScene () {
			SceneManager.LoadSceneAsync("Scenes/LandScene").completed += OnLandSceneLoaded;
		}

		private void OnLandSceneLoaded (AsyncOperation operation) {
			var manufactures = _manufacturesService.GetStartManufactures();
			var factories = _factoriesService.GetStartedFactories();

			var materialsInvItems = _inventoryModel.GetItemsBySourceType(typeof(MaterialModel));
			
			foreach (var manufacture in manufactures) {
				var targetItem = materialsInvItems.SingleOrDefault(x => (x.source as MaterialModel).info == manufacture.settings.material.info);

				if (targetItem == null) {
					var inventoryItemModel = new InventoryItemModel(manufacture.settings.material, 0, manufacture.settings.material.info.sprite);
					_inventoryModel.AddItem(inventoryItemModel);
					
					manufacture.onItemCreated += item => {
						inventoryItemModel.SetAmount(inventoryItemModel.amount + 1);
					};
				}
				else {
					manufacture.onItemCreated += item => {
						targetItem.SetAmount(targetItem.amount + 1);
					};
				}
			}
			
			_disposables.AddRange(manufactures);
			_disposables.AddRange(factories);
			_manufactureLandInitializerService.InitializeManufactures(manufactures);
			_factoriesLandInitializerService.InitializeFactoriesViews(factories);
			_storeInitializerLandService.InitializeStoreView(new [] { _storeModel });
			_inventoryUIService.ShowHUD(_inventoryModel);
		}

		public void Dispose() {
			foreach (var disposable in _disposables) {
				disposable?.Dispose();
			}
		}
	}
}
