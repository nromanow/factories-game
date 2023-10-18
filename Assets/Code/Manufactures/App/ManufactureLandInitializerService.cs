using Code.Manufactures.Api;
using Code.Manufactures.Models;
using Code.Manufactures.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Manufactures.App {
	public class ManufactureLandInitializerService {
		private readonly IManufacturesScreenService _manufacturesScreenService;
		
		public void InitializeManufactures (IEnumerable<ManufactureModel> models) {
			var manufactureViews = UnityEngine.Object.FindObjectsOfType<ManufactureModelView>();
			
			foreach (var model in models) {
				var targetView = manufactureViews.SingleOrDefault(x => x.manufactureType == model.settings);

				if (targetView == null) {
					throw new ArgumentException($"View for {model} not found");
				}
				
				targetView.SetItem(model, () => _manufacturesScreenService.ShowManufactureScreen(model));
			}
		}
	}
}
