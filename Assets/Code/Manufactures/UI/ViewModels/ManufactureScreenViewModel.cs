using Code.Manufactures.Data;
using Code.Manufactures.Models;
using System;

namespace Code.Manufactures.UI.ViewModels {
	public class ManufactureScreenViewModel {
		public event Action closeScreen;
		
		public ManufactureModel model { get; }
		public ManufactureSettings settings => model.settings;
		public bool isManufacturing => model.isProduction;
		
		public ManufactureScreenViewModel (ManufactureModel model) {
			this.model = model;
		}
		
		public void CloseScreen () {
			closeScreen?.Invoke();
		}
		
		public void StartManufacturing () {
			model.Start();
		}
		
		public void StopManufacturing () {
			model.Stop();
		}
	}
}
