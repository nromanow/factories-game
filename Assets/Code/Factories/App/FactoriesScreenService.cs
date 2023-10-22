using Code.Factories.Api;
using Code.Factories.Models;
using Code.Factories.UI.Api;
using Code.Factories.UI.ViewModels;
using Code.Inventory.Models;
using Code.Materials.Models;
using Code.Materials.UI.ViewModels;
using System.Linq;

namespace Code.Factories.App {
	public class FactoriesScreenService : IFactoriesScreenService {
		private readonly IFactoriesUIScreenService _uiService;
		private readonly InventoryModel _inventoryModel;

		public FactoriesScreenService (
			IFactoriesUIScreenService uiService,
			InventoryModel inventoryModel) {
			_uiService = uiService;
			_inventoryModel = inventoryModel;
		}

		public void ShowFactoryScreen (FactoryModel model) {
			var viewModel = new FactoryScreenViewModel(model);
			
			viewModel.openSelectLeftWindow += () => {
				var selectViewModel = GetSelectViewModel();
				selectViewModel.onMaterialSelected += (material) => {
					model.SetLeftMaterial(material);
					_uiService.CloseSelectMaterialPopup();
				};
				
				_uiService.ShowSelectMaterialPopup(selectViewModel);
			};
			
			viewModel.openSelectRightWindow += () => {
				var selectViewModel = GetSelectViewModel();
				selectViewModel.onMaterialSelected += (material) => {
					model.SetRightMaterial(material);
					_uiService.CloseSelectMaterialPopup();
				};
				
				_uiService.ShowSelectMaterialPopup(selectViewModel);
			};
			
			viewModel.closeWindow += () => {
				_uiService.CloseFactoryScreen();
			};
			
			_uiService.ShowFactoryScreen(viewModel);
		}

		private FactorySelectMaterialPopupViewModel GetSelectViewModel () {
			var availableMaterialsItems =
				_inventoryModel.GetItemsBySourceType(typeof(MaterialModel));

			var selectableMaterials =
				availableMaterialsItems
					.Select(x =>
						new SelectableMaterialViewModel(x.source as MaterialModel))
					.ToArray();

			var selectViewModel = new FactorySelectMaterialPopupViewModel(selectableMaterials);
			selectViewModel.closeWindow += () => {
				_uiService.CloseSelectMaterialPopup();
			};
			
			return selectViewModel;
		}

		private void ShowSelectMaterialWindow (FactoryModel model) {}
	}
}
