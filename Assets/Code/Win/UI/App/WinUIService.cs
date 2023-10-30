using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Win.UI.Api;
using System;
using UnityEngine;

namespace Code.Win.UI.App {
	public class WinUIService : IWinUIService {
		private readonly Settings _settings;
		private readonly IUIScreenService _uiScreenService;

		public WinUIService (Settings settings, IUIScreenService uiScreenService) {
			_settings = settings;
			_uiScreenService = uiScreenService;
		}

		public void ShowWinScreen () {
			_uiScreenService.ShowScreen(_settings.winForm);
		}

		public void CloseWinScreen () {
			_uiScreenService.CloseScreen(_settings.winForm);
		}

		[Serializable]
		public class Settings {
			[SerializeField]
			private GUIForm _winForm;

			public GUIForm winForm => _winForm;
		}
	}
}
