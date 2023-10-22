using Code.Materials.Models;
using System;

namespace Code.Manufactures.Data {
	[Serializable]
	public class ManufactureSettings {
		public MaterialModel material { get; }
		public int deltaTime { get; }

		public ManufactureSettings (MaterialModel material, int deltaTime) {
			this.material = material;
			this.deltaTime = deltaTime;
		}
	}
}
