using Code.Core.UI.View;
using Code.Manufactures.UI.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Manufactures.UI.View {
	public class ManufactureScreenViewModelItemViewComponent : ItemViewComponent<ManufactureScreenViewModel> {
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private GameObject _startButton;

		[SerializeField]
		private GameObject _stopButton;

		public void StartManufacture () {
			item.StartManufacturing();
		}

		public void StopManufacture () {
			item.StopManufacturing();
		}

		public void CloseScreen () {
			item.CloseScreen();
		}

		public override void Initialize () {
			_icon.sprite = item.GetIcon();

			if (!item.isManufacturing) {
				_startButton.SetActive(true);
				_stopButton.SetActive(false);
			}
			else {
				_startButton.SetActive(false);
				_stopButton.SetActive(true);
			}

			item.model.onProductionStateChanged += OnManufacturingStateChanged;
		}

		private void OnManufacturingStateChanged (bool isManufacturing) {
			_startButton.SetActive(!isManufacturing);
			_stopButton.SetActive(isManufacturing);
		}

		private void OnDestroy () {
			item.model.onProductionStateChanged -= OnManufacturingStateChanged;
		}
	}
}
