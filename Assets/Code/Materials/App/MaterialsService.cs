using Code.Materials.Api;
using Code.Materials.Data;
using Code.Materials.Models;

namespace Code.Materials.App {
	public class MaterialsService : IMaterialsService {
		// In ideal this method should be implemented by the server
		public MaterialModel[] GetAvailableMaterials () {
			return new[] {
				new MaterialModel("Wood", MaterialInfo.GetInfo("Wood")),
				new MaterialModel("Stone", MaterialInfo.GetInfo("Stone")),
				new MaterialModel("Iron", MaterialInfo.GetInfo("Iron")),
			};
		}
	}
}
