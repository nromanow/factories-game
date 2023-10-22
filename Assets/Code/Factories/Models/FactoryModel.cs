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

		public bool canStartProduction =>
			leftMaterial != null && rightMaterial != null &&
			_inventoryModel.HasItemBySourceType(leftMaterial) &&
			_inventoryModel.HasItemBySourceType(rightMaterial);

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
			tool = ToolsMap.GetToolFromMaterials(leftMaterial, rightMaterial);
			onToolChanged?.Invoke(tool);
		}

		protected override async Task StartProduction (CancellationToken cancellationToken) {
			if (tool == null || !canStartProduction) return;

			var materialsItems = _inventoryModel.GetItemsBySourceType(typeof(MaterialModel));
				
			var leftItem = materialsItems.Single(x => x.source as MaterialModel == leftMaterial);
			var rightItem = materialsItems.Single(x => x.source as MaterialModel == rightMaterial);

			isProduction = true;
			onProductionStateChanged?.Invoke(isProduction);

			while (!cancellationToken.IsCancellationRequested) {
				if (leftItem.amount < REQUIRED_MATERIAL_VALUE || rightItem.amount < REQUIRED_MATERIAL_VALUE) continue;

				await Task.Delay(1000, cancellationToken);

				leftItem.SetAmount(leftItem.amount - REQUIRED_MATERIAL_VALUE);
				rightItem.SetAmount(rightItem.amount - REQUIRED_MATERIAL_VALUE);

				onItemCreated?.Invoke(tool);
				Debug.Log($"{tool.toolId} are created at {DateTime.Now}");
			}
		}
	}
}
