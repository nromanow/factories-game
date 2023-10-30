using Code.Core.UI.ViewModels;
using Code.Store.Models;
using System;
using UnityEngine;

namespace Code.Store.UI.ViewModels {
	public class StoreScreenViewModel : BaseViewModel {
		public event Action openSelectItemWindow;
		public StoreModel storeModel { get; }

		public StoreScreenViewModel (StoreModel storeModel) {
			this.storeModel = storeModel;
		}

		public void OpenSelectItemWindow () {
			openSelectItemWindow?.Invoke();
		}

		public Sprite GetSelectedToolSprite () {
			return storeModel.selectedTool.info.sprite;
		}
		
		public void SellItem () {
			storeModel.SellTool();
		}
	}
}
