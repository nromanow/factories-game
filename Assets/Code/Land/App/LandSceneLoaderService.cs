﻿using Code.Factories.Api;
using Code.Inventory.Models;
using Code.Inventory.UI.Api;
using Code.Land.Api;
using Code.Manufactures.Api;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Land.App {
	public class LandSceneLoaderService : ILandSceneLoaderService, IDisposable {
		private readonly IManufacturesService _manufacturesService;
		private readonly IFactoriesService _factoriesService;
		private readonly IManufactureLandInitializerService _manufactureLandInitializerService;
		private readonly IFactoriesLandInitializerService _factoriesLandInitializerService;
		private readonly InventoryModel _inventoryModel;
		private readonly IInventoryUIService _inventoryUIService;
		private readonly List<IDisposable> _disposables = new();

		public LandSceneLoaderService(
			IManufacturesService manufacturesService, 
			IFactoriesService factoriesService,
			IManufactureLandInitializerService manufactureLandInitializerService,
			IFactoriesLandInitializerService factoriesLandInitializerService,
			InventoryModel inventoryModel,
			IInventoryUIService inventoryUIService) {
			_manufacturesService = manufacturesService;
			_factoriesService = factoriesService;
			_manufactureLandInitializerService = manufactureLandInitializerService;
			_factoriesLandInitializerService = factoriesLandInitializerService;
			_inventoryModel = inventoryModel;
			_inventoryUIService = inventoryUIService;
		}

		public void LoadLandScene () {
			SceneManager.LoadSceneAsync("Scenes/LandScene").completed += OnLandSceneLoaded;
		}

		private void OnLandSceneLoaded (AsyncOperation operation) {
			var manufactures = _manufacturesService.GetStartManufactures();
			var factories = _factoriesService.GetStartedFactories();

			foreach (var manufacture in manufactures) {
				var inventoryItemModel = 
					new InventoryItemModel(manufacture.settings.material, 0, manufacture.settings.material.info.sprite);

				_inventoryModel.AddItem(inventoryItemModel);
				
				manufacture.onItemCreated += item => {
					inventoryItemModel.SetAmount(inventoryItemModel.amount + 1);
				};
			}
			
			_disposables.AddRange(manufactures);
			_manufactureLandInitializerService.InitializeManufactures(manufactures);
			_factoriesLandInitializerService.InitializeFactoriesViews(factories);
			_inventoryUIService.ShowHUD(_inventoryModel);
		}

		public void Dispose() {
			foreach (var disposable in _disposables) {
				disposable?.Dispose();
			}
		}
	}
}
