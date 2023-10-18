using UnityEngine;

namespace Code.Core.UI.Data {
	[CreateAssetMenu(fileName = "GUIForm", menuName = "UI/GUIForm", order = 0)]
	public class GUIForm : ScriptableObject {
		[SerializeField]
		private GUILayerInfo _layer;
		
		[SerializeField] 
		private RectTransform _form;
		
		public GUILayerInfo layer => _layer;
		public RectTransform form => _form;
	}
}
