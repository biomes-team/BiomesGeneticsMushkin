using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace BiomesGeneticsMushkin
{
	internal class Window_PickCaste : Window
	{
		private const float TitleHeight = 50f;
		private const float Padding = 10f;
		private const float RadioPadding = 2f;
		private const float ButtonHeight = 40f;
		private const float ButtonWidth = 140f;
		private readonly AbilityComp_CasteSwap comp;
		private readonly Action action;


		public override Vector2 InitialSize => new(300f, 400f);


		public Window_PickCaste(AbilityComp_CasteSwap comp, Action confirmAction)
		{
			this.comp = comp;
			action = confirmAction;
		}


		public override void DoWindowContents(Rect inRect)
		{
			Rect titleRect = new(inRect.xMin, inRect.yMin, inRect.width, TitleHeight);
			using (new TextBlock(GameFont.Medium, TextAnchor.MiddleCenter))
			{
				Widgets.Label(titleRect, "BGM_SelectCaste_Title".Translate());
			}
			Rect radiosRect = new(inRect.xMin, titleRect.yMax + Padding, inRect.width, inRect.height - titleRect.height - Padding - Padding - ButtonHeight);
			float radioHeight = radiosRect.yMin + RadioPadding;
			foreach (XenotypeDef xenotypeDef in comp.Props.allowedXenotypes)
			{
				Rect radioRect = new(radiosRect.xMin, radioHeight, radiosRect.width, ButtonHeight);
				Widgets.DrawHighlightIfMouseover(radioRect);
				if (Widgets.RadioButtonLabeled(radioRect, xenotypeDef.LabelCap, xenotypeDef == comp.pickedCaste))
				{
					comp.pickedCaste = xenotypeDef;
				}
				radioHeight = radioRect.yMax + RadioPadding;
			}
			Rect buttonRect = new((inRect.width / 2) - ButtonWidth / 2, radiosRect.yMax + Padding, ButtonWidth, ButtonHeight);
			if (Widgets.ButtonText(buttonRect, "BGM_SelectCaste_Confirm".Translate()))
			{
				action();
				Close();
			}
		}
	}
}
