using Code.Core.View;
using Code.Manufactures.Models;
using Code.Materials.Data;
using UnityEngine;

namespace Code.Manufactures.View {
	public class ManufactureModelView : InteractableLandItemView<ManufactureModel> {
		[SerializeField]
		private MaterialInfo _materialInfo;

		public MaterialInfo materialInfo => _materialInfo;
	}
}
