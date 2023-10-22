using Code.Manufactures.Models;
using System.Collections.Generic;

namespace Code.Manufactures.Api {
	public interface IManufactureLandInitializerService {
		void InitializeManufactures (IEnumerable<ManufactureModel> models);
	}
}
