using UnityEngine;

namespace Code.Core.UI.Data {
	public class GUIBase : MonoBehaviour {
		[SerializeField]
		private GUILayer _baseLayer;
		
		[SerializeField]
		private GUILayer _popupLayer;
		
		[SerializeField]
		private GUILayer _hudLayer;
		
		public GUILayer baseLayer => _baseLayer;
		public GUILayer popupLayer => _popupLayer;
		public GUILayer hudLayer => _hudLayer;
	}
}
