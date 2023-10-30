using Code.Core.Models;
using Code.Manufactures.Data;
using Code.Materials.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Manufactures.Models {
	public class ManufactureModel : ProductionModel<MaterialModel> {
		private const int MILLISECONDS_IN_SECOND = 1000;
		
		public ManufactureSettings settings { get; }

		public ManufactureModel (ManufactureSettings settings) {
			this.settings = settings;
		}

		protected override async Task StartProduction (CancellationToken cancellationToken) {
			isProduction = true;
			onProductionStateChanged?.Invoke(isProduction);
			
			while (!cancellationToken.IsCancellationRequested) {
				await Task.Delay(settings.deltaTime * MILLISECONDS_IN_SECOND, cancellationToken);
				onItemCreated?.Invoke(settings.material);
				Debug.Log($"{settings.material.info.titleLocId} are created at {DateTime.Now}");
			}
		}
	}
}
