using Code.Factories.Api;
using Code.Factories.Models;
using Code.Factories.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Factories.App {
	public class FactoriesLandInitializerService : IFactoriesLandInitializerService {
		private readonly IFactoriesScreenService _screenService;

		public FactoriesLandInitializerService (IFactoriesScreenService screenService) {
			_screenService = screenService;
		}

		public void InitializeFactoriesViews (IEnumerable<FactoryModel> factories) {
			var views = UnityEngine.Object.FindObjectsOfType<FactoryLandItemView>();

			foreach (var factory in factories) {
				var emptyFactory = views.FirstOrDefault(x => x.item == null);

				if (emptyFactory == null) throw new Exception("Can't find empty factory view");

				emptyFactory.SetItem(factory, () => { _screenService.ShowFactoryScreen(factory); });
			}
		}
	}
}
