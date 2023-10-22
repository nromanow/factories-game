using Code.Core.UI.Api;
using Code.Core.UI.Data;
using Code.Core.UI.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Core.UI.App {
	public class UIScreenService : IUIScreenService {
		private readonly GUIBase _guiBase;
		private readonly Dictionary<GUIForm, GameObject> _instances = new();

		public UIScreenService(GUIBase guiBase) {
			_guiBase = guiBase;
		}

		public void ShowScreen<T> (GUIForm form, T argument) {
			var root = _guiBase.layers.Single(x => x.layer == form.layer).transform;
			var instance = UnityEngine.Object.Instantiate(form.form.gameObject, root);

			_instances.Add(form, instance);
			
			instance.GetComponentInChildren<ItemViewComponent<T>>()?.SetItem(argument);
		}

		public void CloseScreen (GUIForm form) {
			if (!_instances.TryGetValue(form, out var instance)) return;

			_instances.Remove(form);
				
			UnityEngine.Object.Destroy(instance);
		}
	}
}
