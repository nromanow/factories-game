using Code.Materials.Models;

namespace Code.Manufactures.Data {
	public class ManufactureSettings {
		public MaterialModel material { get; }
		public int deltaTime { get; }

		public ManufactureSettings (MaterialModel material, int deltaTime) {
			this.material = material;
			this.deltaTime = deltaTime;
		}
	}
}
