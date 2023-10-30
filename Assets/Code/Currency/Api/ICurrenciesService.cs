using Code.Currency.Models;
using System;

namespace Code.Currency.Api {
	public interface ICurrenciesService {
		event Action<CurrencyModel> onCurrencyChanged; 
		void AddCurrency (string currencyId, int value);
	}
}
