using Code.Core.Data;
using UnityEngine;

namespace Code.Currency.Data {
	[CreateAssetMenu(menuName = "Currency Info")]
	public class CurrencyInfo : ItemInfo {
		public static CurrencyInfo GetInfo (string key) {
			return ItemsList.GetItem<CurrencyInfo>($"{key}Currency");
		} 
	}
}
