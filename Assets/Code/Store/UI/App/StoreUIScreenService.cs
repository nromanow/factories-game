using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Store.UI.Api;
using Code.Store.UI.ViewModels;
using System;
using UnityEngine;

namespace Code.Store.UI.App {
	public class StoreUIScreenService : IStoreUIScreenService {
		private readonly Settings _settings;
		private readonly IUIScreenService _uiScreenService;

		public StoreUIScreenService (Settings settings, IUIScreenService uiScreenService) {
			_settings = settings;
			_uiScreenService = uiScreenService;
		}
		
		public void ShowStoreScreen (StoreScreenViewModel viewModel) {
			_uiScreenService.ShowScreen(_settings.storeScreenForm, viewModel);
		}

		public void CloseStoreScreen () {
			_uiScreenService.CloseScreen(_settings.storeScreenForm);
		}

		public void ShowSelectedStoreScreen (StoreSelectToolScreenViewModel viewModel) {
			_uiScreenService.ShowScreen(_settings.selectedStoreScreenForm, viewModel);
		}

		public void CloseSelectedStoreScreen () {
			_uiScreenService.CloseScreen(_settings.selectedStoreScreenForm);
		}

		[Serializable]
		public class Settings {
			[SerializeField]
			private GUIForm _storeScreenForm;

			[SerializeField]
			private GUIForm _selectedStoreScreenForm;

			public GUIForm storeScreenForm => _storeScreenForm;
			public GUIForm selectedStoreScreenForm => _selectedStoreScreenForm;
		}
	}
}
