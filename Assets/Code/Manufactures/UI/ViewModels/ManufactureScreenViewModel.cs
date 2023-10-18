using Code.Manufactures.Data;
using Code.Manufactures.Models;

namespace Code.Manufactures.UI.ViewModels {
	public class ManufactureScreenViewModel {
		public ManufactureModel model { get; }
		public ManufactureSettings settings => model.settings;
		public bool isManufacturing => model.isManufacturing;
		
		public ManufactureScreenViewModel (ManufactureModel model) {
			this.model = model;
		}
		
		public void StartManufacturing () {
			model.Start();
		}
		
		public void StopManufacturing () {
			model.Stop();
		}
	}
}
