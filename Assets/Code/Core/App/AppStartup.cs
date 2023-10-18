using UnityEngine;

namespace Code.Core.App {
	public class AppStartup : MonoBehaviour {
		[SerializeField]
		private AppModule[] _modules;

		private void Awake () {
			DontDestroyOnLoad(this.gameObject);
		}

		private void Start () {
			foreach (var module in _modules) {
				module.OnInstall();
			}
		}

		private void OnDestroy () {
			foreach (var module in _modules) {
				module.OnDestroy();
			}
		}
	}
}
