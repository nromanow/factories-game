using Code.Store.Api;
using Code.Store.Models;
using Code.Store.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Store.App {
	public class StoreInitializerLandService : IStoreInitializerLandService {
		private readonly IStoreScreenService _storeScreenService;

		public StoreInitializerLandService (IStoreScreenService storeScreenService) {
			_storeScreenService = storeScreenService;
		}

		public void InitializeStoreView (IEnumerable<StoreModel> stores) {
			var views = UnityEngine.Object.FindObjectsOfType<StoreLandItemView>();

			foreach (var store in stores) {
				var emptyFactory = views.FirstOrDefault(x => x.item == null);

				if (emptyFactory == null) throw new Exception("Can't find empty factory view");

				emptyFactory.SetItem(store, () => { _storeScreenService.OpenStoreScreen(store); });
			}
		}
	}
}
