using Code.Manufactures.Api;
using Code.Manufactures.Models;
using Code.Manufactures.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Manufactures.App {
	public class ManufactureLandInitializerService : IManufactureLandInitializerService {
		private readonly IManufacturesScreenService _manufacturesScreenService;

		public ManufactureLandInitializerService(IManufacturesScreenService manufacturesScreenService) {
			_manufacturesScreenService = manufacturesScreenService;
		}

		public void InitializeManufactures (IEnumerable<ManufactureModel> models) {
			var manufactureViews = UnityEngine.Object.FindObjectsOfType<ManufactureModelView>();
			
			foreach (var model in models) {
				var targetView = manufactureViews.SingleOrDefault(x => x.materialInfo == model.settings.material.info);
				
				if (targetView == null) {
					throw new Exception($"Can't find manufacture view for material {model.settings.material.info.name}");
				}
				
				targetView.SetItem(model, () => _manufacturesScreenService.ShowManufactureScreen(model));
			}
			
			var emptyViews = manufactureViews.Where(x => x.item == null);

			foreach (var view in emptyViews) {
				view.gameObject.SetActive(false);
			}
		}
	}
}
