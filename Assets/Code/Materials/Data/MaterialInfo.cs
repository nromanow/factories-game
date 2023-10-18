using Code.Core.Data;
using UnityEngine;

namespace Code.Materials.Data {
	[CreateAssetMenu(menuName = "Material Info")]
	public class MaterialInfo : ItemInfo {
		public static MaterialInfo GetInfo (string key) {
			return ItemsList.GetItem<MaterialInfo>(key);
		}
	}
}
