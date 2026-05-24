using System.Collections.Generic;
using Game.Core.Ability;
using UnityEngine;

namespace Game.UI.Screens.HudScreen.Views
{
	public class PlayerAbilitiesView : MonoBehaviour
	{
		[field: SerializeField]
		private List<AbilityInfoView> AbilityViews { get; set; }

		public void Initialize(List<AbilityBase> abilities)
		{
			for (int i = 0; i < AbilityViews.Count; i++)
			{
				if (i < abilities.Count)
				{
					AbilityViews[i].Initialize(abilities[i]);
				}

				AbilityViews[i].gameObject.SetActive(i < abilities.Count);
			}
		}
	}
}