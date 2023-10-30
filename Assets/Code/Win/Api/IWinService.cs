using System;

namespace Code.Win.Api {
	public interface IWinService {
		event Action onWin;

		void SetCurrencyWin (string currencyId, int value);
	}
}
