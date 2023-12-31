﻿using Code.Core.UI.Data;

namespace Code.Core.UI.Api {
	public interface IUIScreenService {
		void ShowScreen<T> (GUIForm form, T argument);

		void ShowScreen (GUIForm form);
		
		void CloseScreen (GUIForm form);
	}
}
