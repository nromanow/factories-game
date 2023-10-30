using Code.Store.Models;
using System.Collections.Generic;

namespace Code.Store.Api {
	public interface IStoreInitializerLandService {
		void InitializeStoreView (IEnumerable<StoreModel> stores);
	}
}
