using Code.Core.View;
using Code.Manufactures.Data;
using Code.Manufactures.Models;
using UnityEngine;

namespace Code.Manufactures.View {
	public class ManufactureModelView : InteractableLandItemView<ManufactureModel> {
		[SerializeField]
		private ManufactureSettings _manufactureType;
		
		public ManufactureSettings manufactureType => _manufactureType;
	}
}
