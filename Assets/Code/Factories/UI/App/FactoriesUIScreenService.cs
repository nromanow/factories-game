using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Factories.UI.Api;
using Code.Factories.UI.ViewModels;
using System;
using UnityEngine;

namespace Code.Factories.UI.App {
	public class FactoriesUIScreenService : IFactoriesUIScreenService {
		private readonly Settings _settings;
		private readonly IUIScreenService _screenService;

		public FactoriesUIScreenService (Settings settings, IUIScreenService screenService) {
			_settings = settings;
			_screenService = screenService;
		}

		public void ShowFactoryScreen (FactoryScreenViewModel viewModel) {
			_screenService.ShowScreen(_settings.factoryScreenForm, viewModel);
		}

		public void CloseFactoryScreen () {
			_screenService.CloseScreen(_settings.factoryScreenForm);
		}

		public void ShowSelectMaterialPopup (FactorySelectMaterialPopupViewModel viewModel) {
			_screenService.ShowScreen(_settings.selectMaterialPopupForm, viewModel);
		}

		public void CloseSelectMaterialPopup () {
			_screenService.CloseScreen(_settings.selectMaterialPopupForm);
		}

		[Serializable]
		public class Settings {
			[SerializeField]
			private GUIForm _factoryScreenForm;
			
			[SerializeField]
			private GUIForm _selectMaterialPopupForm;

			public GUIForm factoryScreenForm => _factoryScreenForm;
			public GUIForm selectMaterialPopupForm => _selectMaterialPopupForm;
		}
	}
}
