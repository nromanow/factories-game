using Code.Core.UI.View;
using Code.Factories.UI.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Factories.UI.View {
	public class FactoryScreenViewModelItemViewComponent : ItemViewComponent<FactoryScreenViewModel> {
		[SerializeField]
		private Image _leftMaterialImage;

		[SerializeField]
		private Image _rightMaterialImage;

		[SerializeField]
		private Image _toolImage;

		[SerializeField]
		private Sprite _defaultToolSprite;
		
		[SerializeField]
		private Sprite _defaultMaterialSprite;

		[SerializeField]
		private Button _startButton;

		[SerializeField]
		private Button _stopButton;

		public void StartProduction () {
			item.StartFactory();
		}
		
		public void StopProduction () {
			item.StopFactory();
		}
		
		public void OpenSelectRightWindow () {
			item.OpenSelectRightWindow();
		}
		
		public void OpenSelectLeftWindow () {
			item.OpenSelectLeftWindow();
		}

		public void Close () {
			item.CloseWindow();
		}
		
		public override void Initialize () {
			base.Initialize();

			OnToolChanged();
			OnLeftMaterialChanged();
			OnRightMaterialChanged();
			OnProductionStateChanged(item.productionState);
			
			item.model.onToolChanged += OnToolChanged;
			item.model.onLeftMaterialChanged += OnLeftMaterialChanged;
			item.model.onRightMaterialChanged += OnRightMaterialChanged;
			item.model.onProductionStateChanged += OnProductionStateChanged;
		}

		private void OnDestroy () {
			item.model.onToolChanged -= OnToolChanged;
			item.model.onLeftMaterialChanged -= OnLeftMaterialChanged;
			item.model.onRightMaterialChanged -= OnRightMaterialChanged;
			item.model.onProductionStateChanged -= OnProductionStateChanged;
		}

		private void OnProductionStateChanged (bool inProd) {
			if (inProd) {
				_startButton.gameObject.SetActive(false);
				_stopButton.gameObject.SetActive(true);
			}
			else {
				_startButton.gameObject.SetActive(true);
				_stopButton.gameObject.SetActive(false);
			}
		}

		private void OnLeftMaterialChanged () {
			_leftMaterialImage.sprite = item.leftMaterialNotNull ? item.GetLeftMaterialIcon() : _defaultMaterialSprite;
		}

		private void OnRightMaterialChanged () {
			_rightMaterialImage.sprite = item.rightMaterialNotNull ? item.GetRightMaterialIcon() : _defaultMaterialSprite;
		}

		private void OnToolChanged () {
			_toolImage.sprite = item.toolNotNull ? item.GetToolIcon() : _defaultToolSprite;
		}
	}
}
