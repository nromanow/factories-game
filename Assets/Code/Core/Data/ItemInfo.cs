using UnityEngine;

namespace Code.Core.Data {
	public class ItemInfo : ScriptableObject {
		[SerializeField]
		private string _titleLocId;

		[SerializeField]
		private Sprite _sprite;
		
		public string titleLocId => _titleLocId;
		public Sprite sprite => _sprite;
	}
}
