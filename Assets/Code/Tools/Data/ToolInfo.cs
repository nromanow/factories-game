using Code.Core.Data;
using UnityEngine;

namespace Code.Tools.Data {
	[CreateAssetMenu(menuName = "Tool Info")]
	public class ToolInfo : ItemInfo {
		[SerializeField]
		private string _sellCurrencyType;
		
		[SerializeField]
		private int _sellPrice;

		[SerializeField]
		private int _generateCount;
		
		public string sellCurrencyType => _sellCurrencyType;
		public int sellPrice => _sellPrice;
		public int generateCount => _generateCount;
		
		public static ToolInfo GetInfo (string key) {
			return ItemsList.GetItem<ToolInfo>($"{key}Tool");
		}
	}
}
