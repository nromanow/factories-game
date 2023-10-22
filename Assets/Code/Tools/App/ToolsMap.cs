using Code.Materials.Models;
using Code.Tools.Data;
using Code.Tools.Models;
using System.Linq;

namespace Code.Tools.App {
	public static class ToolsMap {
		public static ToolModel GetToolFromMaterials (MaterialModel leftMaterial, MaterialModel rightMaterial) {
			var array = new[] { leftMaterial.materialId, rightMaterial.materialId };
			
			if (array.Contains("Wood") && array.Contains("Stone")) {
				return new ToolModel("Hummer", ToolInfo.GetInfo("Hummer"));
			}
			
			if (array.Contains("Wood") && array.Contains("Iron")) {
				return new ToolModel("Fork", ToolInfo.GetInfo("Fork"));
			}
			
			if (array.Contains("Stone") && array.Contains("Iron")) {
				return new ToolModel("Drill", ToolInfo.GetInfo("Drill"));
			}

			return null;
		}
	}
}
