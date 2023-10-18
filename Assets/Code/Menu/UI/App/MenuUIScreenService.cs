using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Menu.UI.Api;
using Code.Menu.UI.ViewModels;
using System;
using UnityEngine;

namespace Code.Menu.UI.App {
	public class MenuUIScreenService : IMenuUIScreenService {
		private readonly Settings _settings;
		private readonly IUIScreenService _screenService;

		public MenuUIScreenService (Settings settings, IUIScreenService screenService) {
			_settings = settings;
			_screenService = screenService;
		}

		public void ShowMenuSettingsScreen (MenuManufacturesSettingsScreenViewModel viewModel) {
			_screenService.ShowScreen(_settings.menuSettingsScreen, viewModel);
		}

		public void ShowMenuScreen (MenuScreenViewModel viewModel) {
			_screenService.ShowScreen(_settings.menuScreen, viewModel);
		}

		[Serializable]
		public class Settings {
			[SerializeField]
			private GUIForm _menuSettingsScreen;

			[SerializeField]
			private GUIForm _menuScreen;

			public GUIForm menuSettingsScreen => _menuSettingsScreen;
			public GUIForm menuScreen => _menuScreen;
		}
	}
}
