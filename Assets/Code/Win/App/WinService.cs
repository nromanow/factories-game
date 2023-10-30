using Code.Currency.Api;
using Code.Currency.Models;
using Code.Win.Api;
using Code.Win.UI.Api;
using System;

namespace Code.Win.App {
	public class WinService : IWinService {
		public event Action onWin;
		public string currencyWinId { get; private set; }
		public int currencyWinValue { get; private set; }

		private readonly ICurrenciesService _currenciesService;
		private readonly IWinUIService _winUIService;

		public WinService (
			ICurrenciesService currenciesService,
			IWinUIService winUIService) {
			_currenciesService = currenciesService;
			_currenciesService.onCurrencyChanged += OnCurrencyChanged;
			
			_winUIService = winUIService;
		}

		public void SetCurrencyWin (string currencyId, int value) {
			currencyWinId = currencyId;
			currencyWinValue = value;
		}
		
		private void OnCurrencyChanged (CurrencyModel currency) {
			if (currency.currencyId != currencyWinId) return;

			if (currency.value >= currencyWinValue) {
				onWin?.Invoke();
				_currenciesService.onCurrencyChanged -= OnCurrencyChanged;

				_winUIService.ShowWinScreen();
			}
		}
	}
}
