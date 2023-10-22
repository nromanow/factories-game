using Code.Core.Data;
using UnityEngine;

namespace Code.Tools.Data {
	[CreateAssetMenu(menuName = "Tool Info")]
	public class ToolInfo : ItemInfo {
		public static ToolInfo GetInfo (string key) {
			return ItemsList.GetItem<ToolInfo>($"{key}Tool");
		}
	}
}
