using UnityEngine;

namespace Code.Core.UI.Data {
	public class GUIBase : MonoBehaviour {
		[SerializeField]
		private GUILayer[] _layers;
		
		public GUILayer[] layers => _layers;
	}
}
