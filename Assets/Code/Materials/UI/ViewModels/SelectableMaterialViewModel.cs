using Code.Materials.Models;
using System;

namespace Code.Materials.UI.ViewModels {
	public class SelectableMaterialViewModel {
		public event Action<MaterialModel> onSelect;
		
		public MaterialModel model { get; }

		public SelectableMaterialViewModel(MaterialModel model) {
			this.model = model;
		}

		public void Select () {
			onSelect?.Invoke(model);
		}
	}
}
