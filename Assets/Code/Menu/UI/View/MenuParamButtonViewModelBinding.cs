using Code.Core.UI.View;
using Code.Menu.UI.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Menu.UI.View {
	public class MenuParamButtonViewModelBinding : ItemViewComponent<MenuParamButtonViewModel> {
		[SerializeField]
		private TextMeshProUGUI _textComponent;

		[SerializeField]
		private Image _backgroundImage;
		
		[SerializeField]
		private Sprite _selectedBackgroundSprite;
		
		[SerializeField]
		private Sprite _notSelectedBackgroundSprite;
		
		public void OnClick () {
			item.OnClick();
		}
		
		public override void Initialize () {
			base.Initialize();
			
			_textComponent.text = item.index.ToString();
			OnSelectStateChange(item.isSelected);
			item.onSelectStateChange += OnSelectStateChange;
		}

		private void OnSelectStateChange (bool isSelected) {
			_backgroundImage.sprite = isSelected ? _selectedBackgroundSprite : _notSelectedBackgroundSprite;
		}
	}
}
