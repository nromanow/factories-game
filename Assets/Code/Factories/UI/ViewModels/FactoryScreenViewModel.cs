using Code.Core.UI.ViewModels;
using Code.Factories.Models;
using System;
using UnityEngine;

namespace Code.Factories.UI.ViewModels {
	public class FactoryScreenViewModel : BaseViewModel {
		public event Action openSelectRightWindow;
		public event Action openSelectLeftWindow;
		public bool productionState => model.isProduction;
		public bool leftMaterialNotNull => model.leftMaterial != null;
		public bool rightMaterialNotNull => model.rightMaterial != null;
		public bool toolNotNull => model.tool != null;

		public FactoryModel model { get; }

		public FactoryScreenViewModel (FactoryModel model) {
			this.model = model;
		}
		
		public Sprite GetLeftMaterialIcon () {
			return model.leftMaterial.info.sprite;
		}
		
		public Sprite GetRightMaterialIcon () {
			return model.rightMaterial.info.sprite;
		}
		
		public Sprite GetToolIcon () {
			return model.tool.info.sprite;
		}
		
		public void StartFactory () {
			model.Start();
		}
		
		public void StopFactory () {
			model.Stop();
		}

		public void OpenSelectRightWindow () {
			openSelectRightWindow?.Invoke();
		}

		public void OpenSelectLeftWindow () {
			openSelectLeftWindow?.Invoke();
		}
	}
}
