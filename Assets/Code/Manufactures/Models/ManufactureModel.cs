using Code.Manufactures.Data;
using Code.Materials.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Manufactures.Models {
	public class ManufactureModel : IDisposable {
		private CancellationTokenSource _cancellationTokenSource = new();

		public event Action<MaterialModel> onItemCreated;

		public bool isManufacturing { get; private set; }
		public ManufactureSettings settings { get; }

		public ManufactureModel (ManufactureSettings settings) {
			this.settings = settings;
		}

		public void Start () {
			StartManufacturing(_cancellationTokenSource.Token).Start();

			isManufacturing = true;
		}

		public void Stop () {
			_cancellationTokenSource.Cancel();
			_cancellationTokenSource.Dispose();
			_cancellationTokenSource = new CancellationTokenSource();

			isManufacturing = false;
		}

		private async Task StartManufacturing (CancellationToken cancellationToken) {
			while (!cancellationToken.IsCancellationRequested) {
				await Task.Delay(settings.deltaTime, cancellationToken);
				onItemCreated?.Invoke(settings.material);
			}
		}

		public void Dispose () {
			_cancellationTokenSource?.Dispose();
		}
	}
}
