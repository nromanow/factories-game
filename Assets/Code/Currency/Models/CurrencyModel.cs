using Code.Currency.Data;

namespace Code.Currency.Models {
	public class CurrencyModel {
		public CurrencyInfo currencyInfo { get; }
		public string currencyId { get; }
		public int value { get; private set; }

		public CurrencyModel(
			CurrencyInfo currencyInfo,
			string currencyId,
			int value) {
			this.currencyInfo = currencyInfo;
			this.currencyId = currencyId;
			this.value = value;
		}
		
		public void IncreaseValue (int amount) {
			value += amount;
		}
		
		public void DecreaseValue (int amount) {
			value -= amount;
		}
	}
}
