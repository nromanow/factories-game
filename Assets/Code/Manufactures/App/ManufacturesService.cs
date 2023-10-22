using Code.Manufactures.Api;
using Code.Manufactures.Data;
using Code.Manufactures.Models;
using Code.Materials.Api;
using System.Collections.Generic;

namespace Code.Manufactures.App {
	public class ManufacturesService : IManufacturesService {
		private readonly IMaterialsService _materialsService;
		
		private int _paramIndex;

		public ManufacturesService(IMaterialsService materialsService) {
			_materialsService = materialsService;
		}

		public void SetStartParameters (int paramIndex) {
			_paramIndex = paramIndex;
		}

		public ManufactureModel[] GetStartManufactures () {
			var availableMaterials = _materialsService.GetAvailableMaterials();
			var manufacturesList = new List<ManufactureModel>();
			
			for (var i = 0; i < _paramIndex; i++) {
				manufacturesList.Add(new ManufactureModel(new ManufactureSettings(availableMaterials[i], 1)));
			}

			return manufacturesList.ToArray();
		}
	}
}
