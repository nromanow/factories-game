using UnityEngine;

namespace Code.Core.UI.Data {
	public class GUILayer : MonoBehaviour {
		[SerializeField]
		private GUILayerInfo _layer;
		
		public GUILayerInfo layer => _layer;
	}
}
