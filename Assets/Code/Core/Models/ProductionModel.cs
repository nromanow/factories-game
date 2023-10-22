using System;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Core.Models {
	public class ProductionModel<T> : IDisposable {
		protected CancellationTokenSource cancellationTokenSource = new();

		public Action<T> onItemCreated;
		public Action<bool> onProductionStateChanged;
		
		public bool isProduction { get; protected set; }
		
		public void Stop () {
			cancellationTokenSource.Cancel();
			cancellationTokenSource.Dispose();
			cancellationTokenSource = new CancellationTokenSource();

			isProduction = false;
			onProductionStateChanged?.Invoke(isProduction);
		}
		
		public void Start () {
			StartProduction(cancellationTokenSource.Token);
		}

		protected virtual Task StartProduction (CancellationToken cancellationToken) {
			return Task.CompletedTask;
		}
		
		public void Dispose() {
			cancellationTokenSource?.Cancel();
			cancellationTokenSource?.Dispose();
		}
	}
}
