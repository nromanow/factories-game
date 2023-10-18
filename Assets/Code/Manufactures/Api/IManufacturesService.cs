using Code.Manufactures.Data;
using Code.Manufactures.Models;

namespace Code.Manufactures.Api {
	public interface IManufacturesService {
		ManufactureModel[] GetStartManufacturesBySettings (ManufactureSettings[] settings);
	}
}
