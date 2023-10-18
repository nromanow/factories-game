using Code.Core.UI.View;
using Code.Manufactures.UI.ViewModels;
using UnityEngine;

namespace Code.Manufactures.UI.View {
	public class ManufactureScreenViewModelItemViewComponent : ItemViewComponent<ManufactureScreenViewModel> {
		public Sprite materialIcon => item.settings.material.info.sprite;
		public string materialLocId => item.settings.material.info.titleLocId;
		public int delaTime => item.settings.deltaTime;
		public bool isManufacturing => item.isManufacturing;
	}
}
