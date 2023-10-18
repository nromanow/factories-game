using Code.Materials.Data;

namespace Code.Materials.Models {
	public class MaterialModel {
		public string materialId { get; }
		public MaterialInfo info { get; }

		public MaterialModel (string materialId, MaterialInfo info) {
			this.materialId = materialId;
			this.info = info;
		}
	}
}
