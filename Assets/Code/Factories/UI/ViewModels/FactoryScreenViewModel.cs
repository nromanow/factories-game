using Code.Core.UI.ViewModels;
using Code.Factories.Models;
using System;

namespace Code.Factories.UI.ViewModels {
	public class FactoryScreenViewModel : BaseViewModel {
		public event Action openSelectRightWindow;
		public event Action openSelectLeftWindow;

		public FactoryModel model { get; }

		public FactoryScreenViewModel (FactoryModel model) {
			this.model = model;
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
