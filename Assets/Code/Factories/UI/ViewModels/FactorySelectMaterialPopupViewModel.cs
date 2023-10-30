using Code.Core.UI.ViewModels;
using Code.Materials.Models;
using System;

namespace Code.Factories.UI.ViewModels {
	public class FactorySelectMaterialPopupViewModel : BaseViewModel {
		public event Action<MaterialModel> onMaterialSelected;
		public SelectableItemViewModel<MaterialModel>[] materials { get; }

		public FactorySelectMaterialPopupViewModel (SelectableItemViewModel<MaterialModel>[] materials) {
			this.materials = materials;

			foreach (var material in materials) {
				material.onSelect += SelectMaterial;
			}
		}

		private void SelectMaterial (MaterialModel material) {
			onMaterialSelected?.Invoke(material);
		}
	}
}
