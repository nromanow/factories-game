using Code.Core.UI.View;
using Code.Store.UI.ViewModels;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Store.UI.View {
	public class StoreScreenViewModelItemViewComponent : ItemViewComponent<StoreScreenViewModel> {
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Sprite _defaultSprite;

		public override void Initialize () {
			base.Initialize();
			
			OnToolSelected();
			item.storeModel.onToolSelected += OnToolSelected;
		}

		private void OnDestroy () {
			item.storeModel.onToolSelected -= OnToolSelected;
		}

		public void SellTool () {
			item.SellItem();
		}
		
		public void OpenSelectItemWindow () {
			item.OpenSelectItemWindow();
		}
		
		public void Close () {
			item.CloseWindow();
		}

		private void OnToolSelected () {
			_icon.sprite =
				item.storeModel.selectedTool == null ? _defaultSprite :
					item.GetSelectedToolSprite();
		}
	}
}
