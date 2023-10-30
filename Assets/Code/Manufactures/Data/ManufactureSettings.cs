using Code.Materials.Models;

namespace Code.Manufactures.Data {
	public class ManufactureSettings {
		public MaterialModel material { get; }
		public int deltaTime { get; }

		public ManufactureSettings (MaterialModel material) {
			this.material = material;
			this.deltaTime = material.info.generationTime;
		}
	}
}
