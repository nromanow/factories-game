using Code.Manufactures.Models;

namespace Code.Manufactures.Api {
	public interface IManufacturesService {
		void SetStartParameters (int paramIndex);
		ManufactureModel[] GetStartManufactures ();
	}
}
