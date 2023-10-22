using Code.Core.Models;
using Code.Manufactures.Data;
using Code.Materials.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Manufactures.Models {
	public class ManufactureModel : ProductionModel<MaterialModel> {
		public ManufactureSettings settings { get; }

		public ManufactureModel (ManufactureSettings settings) {
			this.settings = settings;
		}

		protected override async Task StartProduction (CancellationToken cancellationToken) {
			isProduction = true;
			onProductionStateChanged?.Invoke(isProduction);
			
			while (!cancellationToken.IsCancellationRequested) {
				await Task.Delay(settings.deltaTime * 1000, cancellationToken);
				onItemCreated?.Invoke(settings.material);
				Debug.Log($"{settings.material.info.titleLocId} are created at {DateTime.Now}");
			}
		}
	}
}
