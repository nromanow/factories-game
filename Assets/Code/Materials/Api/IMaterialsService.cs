using Code.Materials.Models;

namespace Code.Materials.Api {
	public interface IMaterialsService {
		MaterialModel[] GetAvailableMaterials ();
	}
}
