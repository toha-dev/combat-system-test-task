using Game.Core.Ability;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Screens.HudScreen.Views
{
	public class AbilityInfoView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[field: SerializeField]
		private TextMeshProUGUI Name { get; set; }

		[field: SerializeField]
		private TextMeshProUGUI Description { get; set; }

		[field: SerializeField]
		private GameObject ToolTip { get; set; }

		private AbilityBase Ability { get; set; }

		public void Initialize(AbilityBase ability)
		{
			Ability = ability;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Name.text = Ability.BaseConfig.Name;
			Description.text = Ability.BaseConfig.Description;
			ToolTip.SetActive(true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			ToolTip.SetActive(false);
		}
	}
}