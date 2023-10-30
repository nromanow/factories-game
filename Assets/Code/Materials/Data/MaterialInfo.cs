using Code.Core.Data;
using UnityEngine;

namespace Code.Materials.Data {
	[CreateAssetMenu(menuName = "Material Info")]
	public class MaterialInfo : ItemInfo {
		[SerializeField]
		private int _generationTime;
		
		public int generationTime => _generationTime;
		
		public static MaterialInfo GetInfo (string key) {
			return ItemsList.GetItem<MaterialInfo>($"{key}Material");
		}
	}
}
