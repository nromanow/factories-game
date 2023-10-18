using Code.Manufactures.Api;
using Code.Manufactures.Data;
using Code.Manufactures.Models;
using System.Linq;

namespace Code.Manufactures.App {
	public class ManufacturesService : IManufacturesService {
		public ManufactureModel[] GetStartManufacturesBySettings (ManufactureSettings[] settings) {
			return settings.Select(setting => new ManufactureModel(setting)).ToArray();
		}
	}
}
