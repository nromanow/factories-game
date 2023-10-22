using Code.Materials.Models;
using Code.Tools.Models;

namespace Code.Tools.Api {
	public interface IToolsService {
		ToolModel GetToolFromMaterials (MaterialModel leftMaterial, MaterialModel rightMaterial);
	}
}
