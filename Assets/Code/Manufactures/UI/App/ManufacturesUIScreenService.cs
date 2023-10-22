using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Manufactures.UI.Api;
using Code.Manufactures.UI.ViewModels;
using System;
using UnityEngine;

namespace Code.Manufactures.UI.App {
	public class ManufacturesUIScreenService : IManufacturesUIScreenService {
		private readonly Settings _settings;
		private readonly IUIScreenService _uiScreenService;

		public ManufacturesUIScreenService (
			Settings settings,
			IUIScreenService uiScreenService) {
			_settings = settings;
			_uiScreenService = uiScreenService;
		}

		public void ShowManufactureScreen (ManufactureScreenViewModel viewModel) {
			_uiScreenService.ShowScreen(_settings.manufactureScreenReference, viewModel);
		}

		public void CloseManufactureScreen () {
			_uiScreenService.CloseScreen(_settings.manufactureScreenReference);
		}

		[Serializable]
		public class Settings {
			[SerializeField]
			private GUIForm _manufactureScreenReference;

			public GUIForm manufactureScreenReference => _manufactureScreenReference;
		}
	}
}
