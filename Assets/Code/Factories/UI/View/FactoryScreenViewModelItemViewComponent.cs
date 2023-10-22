using Code.Core.UI.View;
using Code.Factories.UI.ViewModels;
using Code.Materials.Models;
using Code.Tools.Models;
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

			OnToolChanged(item.model.tool);
			OnLeftMaterialChanged(item.model.leftMaterial);
			OnRightMaterialChanged(item.model.rightMaterial);
			OnProductionStateChanged(item.model.isProduction);
			
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

		private void OnLeftMaterialChanged (MaterialModel material) {
			_leftMaterialImage.sprite = material != null ? material.info.sprite : _defaultMaterialSprite;
		}

		private void OnRightMaterialChanged (MaterialModel material) {
			_rightMaterialImage.sprite = material != null ? material.info.sprite : _defaultMaterialSprite;
		}

		private void OnToolChanged (ToolModel tool) {
			_toolImage.sprite = tool != null ? tool.info.sprite : _defaultToolSprite;
		}
	}
}
