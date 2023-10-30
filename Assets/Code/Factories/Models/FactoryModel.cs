using Code.Core.Models;
using Code.Inventory.Models;
using Code.Materials.Models;
using Code.Tools.App;
using Code.Tools.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Factories.Models {
	public class FactoryModel : ProductionModel<ToolModel> {
		private const int REQUIRED_MATERIAL_VALUE = 1;
		
		private readonly InventoryModel _inventoryModel;

		public event Action<MaterialModel> onLeftMaterialChanged;
		public event Action<MaterialModel> onRightMaterialChanged;
		public event Action<ToolModel> onToolChanged;

		public MaterialModel leftMaterial { get; private set; }
		public MaterialModel rightMaterial { get; private set; }
		public ToolModel tool { get; private set; }

		public bool canStartProduction => leftMaterial != null && rightMaterial != null;

		public FactoryModel (InventoryModel inventoryModel) {
			_inventoryModel = inventoryModel;
		}

		public void SetLeftMaterial (MaterialModel value) {
			leftMaterial = value;
			onLeftMaterialChanged?.Invoke(leftMaterial);
			UpdateTool();
		}

		public void SetRightMaterial (MaterialModel value) {
			rightMaterial = value;
			onRightMaterialChanged?.Invoke(rightMaterial);
			UpdateTool();
		}

		private void UpdateTool () {
			Stop();
			
			tool = ToolsMap.GetToolFromMaterials(leftMaterial, rightMaterial);
			onToolChanged?.Invoke(tool);
		}

		protected override async Task StartProduction (CancellationToken cancellationToken) {
			if (tool == null || !canStartProduction) return;

			var materialsItems = _inventoryModel.GetItemsBySourceType(typeof(MaterialModel));
				
			var leftItem = materialsItems.Single(x => x.source as MaterialModel == leftMaterial);
			var rightItem = materialsItems.Single(x => x.source as MaterialModel == rightMaterial);
			
			var toolsItems = _inventoryModel.GetItemsBySourceType(typeof(ToolModel));
			
			var toolItem = toolsItems.SingleOrDefault(x => x.source as ToolModel == tool);

			if (toolItem == null) {
				toolItem = new InventoryItemModel(tool, 0, tool.info.sprite);
				_inventoryModel.AddItem(toolItem);
			}

			isProduction = true;
			onProductionStateChanged?.Invoke(isProduction);

			while (!cancellationToken.IsCancellationRequested) {
				if (leftItem.amount < REQUIRED_MATERIAL_VALUE || rightItem.amount < REQUIRED_MATERIAL_VALUE) {
					Stop();
					Debug.Log($"Production of {tool.toolId} are stopped at {DateTime.Now} bsc is not enough materials");
				}

				await Task.Delay(1000, cancellationToken);

				leftItem.SetAmount(leftItem.amount - REQUIRED_MATERIAL_VALUE);
				rightItem.SetAmount(rightItem.amount - REQUIRED_MATERIAL_VALUE);
				
				toolItem.SetAmount(toolItem.amount + 1);

				onItemCreated?.Invoke(tool);
				Debug.Log($"{tool.toolId} are created at {DateTime.Now}");
			}
		}
	}
}
