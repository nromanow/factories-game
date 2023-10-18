using UnityEngine;

namespace Code.Core.App {
	public class AppModule : ScriptableObject {
		public virtual void OnInstall () {}
		public virtual void OnDestroy () {}
	}
}
