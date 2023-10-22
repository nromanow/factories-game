using Code.Factories.Models;
using System.Collections.Generic;

namespace Code.Factories.Api {
	public interface IFactoriesLandInitializerService {
		void InitializeFactoriesViews (IEnumerable<FactoryModel> factories);
	}
}
