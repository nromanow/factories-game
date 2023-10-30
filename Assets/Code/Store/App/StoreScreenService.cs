using Code.Core.UI.ViewModels;
using Code.Inventory.Models;
using Code.Store.Api;
using Code.Store.Models;
using Code.Store.UI.Api;
using Code.Store.UI.ViewModels;
using Code.Tools.Models;
using System.Linq;

namespace Code.Store.App {
	public class StoreScreenService : IStoreScreenService {
		private readonly IStoreUIScreenService _storeUIScreenService;
		private readonly InventoryModel _inventoryModel;

		public StoreScreenService (IStoreUIScreenService storeUIScreenService, InventoryModel inventoryModel) {
			_storeUIScreenService = storeUIScreenService;
			_inventoryModel = inventoryModel;
		}

		public void OpenStoreScreen (StoreModel storeModel) {
			var viewModel = new StoreScreenViewModel(storeModel);
			
			viewModel.openSelectItemWindow += () => {
				var selectViewModel = GetSelectViewModel();
				selectViewModel.onToolSelected += (tool) => {
					storeModel.SelectTool(tool);
					_storeUIScreenService.CloseSelectedStoreScreen();
				};
				
				_storeUIScreenService.ShowSelectedStoreScreen(selectViewModel);
			};
			
			viewModel.closeWindow += () => {
				_storeUIScreenService.CloseStoreScreen();
			}; 

			_storeUIScreenService.ShowStoreScreen(viewModel);
		}

		private StoreSelectToolScreenViewModel GetSelectViewModel () {
			var availableTools =
				_inventoryModel.GetItemsBySourceType(typeof(ToolModel));

			var selectableTools =
				availableTools
					.Select(x => new SelectableItemViewModel<ToolModel>(x.source as ToolModel))
					.ToArray();
			
			var viewModel = new StoreSelectToolScreenViewModel(selectableTools);
			viewModel.closeWindow += () => {
				_storeUIScreenService.CloseSelectedStoreScreen();
			};
			
			return viewModel;
		}
	}
}
