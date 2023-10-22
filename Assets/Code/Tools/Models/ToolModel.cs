using Code.Tools.Data;

namespace Code.Tools.Models {
	public class ToolModel {
		public string toolId { get; }
		public ToolInfo info { get; }

		public ToolModel (string toolId, ToolInfo info) {
			this.toolId = toolId;
			this.info = info;
		}
	}
}
