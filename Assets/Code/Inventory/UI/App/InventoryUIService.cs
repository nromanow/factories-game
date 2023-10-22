using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Inventory.Models;
using Code.Inventory.UI.Api;
using System;
using UnityEngine;

namespace Code.Inventory.UI.App {
	public class InventoryUIService : IInventoryUIService {
		private readonly Settings _settings;
		private readonly IUIScreenService _uiScreenService;

		public InventoryUIService (Settings settings, IUIScreenService uiScreenService) {
			_settings = settings;
			_uiScreenService = uiScreenService;
		}

		public void ShowHUD (InventoryModel inventoryModel) {
			_uiScreenService.ShowScreen(_settings.inventoryHUDForm, inventoryModel);
		}

		[Serializable]
		public class Settings {
			[SerializeField]
			private GUIForm _inventoryHUDForm;

			public GUIForm inventoryHUDForm => _inventoryHUDForm;
		}
	}
}
