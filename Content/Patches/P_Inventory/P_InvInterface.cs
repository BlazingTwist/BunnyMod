using BepInEx.Logging;
using BunnyMod.Content.Logging;
using BunnyMod.Content.Traits;
using HarmonyLib;
using UnityEngine;
using RogueLibsCore;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace BunnyMod.Content.Patches
{
	[HarmonyPatch(declaringType: typeof(InvInterface))]
	public static class P_InvInterface
	{
		private static readonly ManualLogSource logger = BMLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		// TODO: Transpiler
		[HarmonyPrefix,HarmonyPatch(methodName:nameof(InvInterface.RealAwake))]
		public static bool RealAwake_Prefix(InvInterface __instance, ref bool ___isRealAwake, ref int ___slotXPos, ref int ___slotYPos)
		{
			___isRealAwake = true;
			__instance.database = __instance.transform.parent.GetComponent<MainGUI>().agent.GetComponent<InvDatabase>();
			__instance.cursorTextString = __instance.cursorText.GetComponent<Text>();
			__instance.cursorTextString2 = __instance.cursorText2.GetComponent<Text>();
			__instance.cursorTextString3 = __instance.cursorText3.GetComponent<Text>();
			__instance.cursorTextString4 = __instance.cursorText4.GetComponent<Text>();
			__instance.cursorTextString5 = __instance.cursorText5.GetComponent<Text>();
			__instance.cursorTextRect = __instance.cursorText.GetComponent<RectTransform>();
			__instance.cursorTextRect2 = __instance.cursorText2.GetComponent<RectTransform>();
			__instance.cursorTextRect3 = __instance.cursorText3.GetComponent<RectTransform>();
			__instance.cursorTextRect4 = __instance.cursorText4.GetComponent<RectTransform>();
			__instance.cursorTextRect5 = __instance.cursorText5.GetComponent<RectTransform>();
			__instance.cursorTextBackgroundRect = __instance.cursorTextBackground.GetComponent<RectTransform>();
			__instance.cursorTextBackgroundRect2 = __instance.cursorTextBackground2.GetComponent<RectTransform>();
			__instance.cursorTextBackgroundImage2 = __instance.cursorTextBackground2.GetComponent<Image>();
			__instance.mainGUI = __instance.transform.parent.GetComponent<MainGUI>();
			__instance.worldSpaceGUI = __instance.transform.parent.GetComponent<MainGUI>().agent.worldSpaceGUI;
			__instance.canvasGroup = __instance.GetComponent<CanvasGroup>();
			__instance.tooltipRect = __instance.tooltip.GetComponent<RectTransform>();
			__instance.targetSprite = __instance.gr.gamepadCursors[0];
			__instance.target2Sprite = __instance.gr.gamepadCursors[1];
			__instance.targetHighlightSprite = __instance.gr.gamepadCursors[2];
			__instance.cursorTextHolderCanvas = __instance.cursorTextHolder.GetComponent<Canvas>();
			__instance.backgroundColorRed = new Color32(56, 0, 0, 200);
			__instance.backgroundColorGreen = new Color32(0, 109, 10, 124);

			if (__instance.mainGUI.agent.controllerTypeSpecific == "Keyboard")
			{
				__instance.cursorText.transform.localPosition = new Vector3(0f, __instance.cursorText.transform.localPosition.y, 0f);
				__instance.cursorText2.transform.localPosition = new Vector3(0f, __instance.cursorText2.transform.localPosition.y, 0f);
				__instance.cursorText3.transform.localPosition = new Vector3(0f, __instance.cursorText3.transform.localPosition.y, 0f);
				__instance.cursorText4.transform.localPosition = new Vector3(0f, __instance.cursorText4.transform.localPosition.y, 0f);
				__instance.cursorText5.transform.localPosition = new Vector3(0f, __instance.cursorText5.transform.localPosition.y, 0f);
			}

			try
			{
				__instance.selectionBoxMain = __instance.mainGUI.transform.Find("SelectionBox").gameObject;
			}
			catch
			{
				__instance.selectionBoxMain = GC.mainGUI.transform.Find("SelectionBox2").gameObject;
				__instance.selectionBoxMain.GetComponent<Canvas>().overrideSorting = false;

				if (GC.fourPlayerMode)
				{
					if (__instance.mainGUI.agent.isPlayer == 3)
						__instance.selectionBoxMain = GC.mainGUI.transform.Find("SelectionBox3").gameObject;
					else if (__instance.mainGUI.agent.isPlayer == 4)
						__instance.selectionBoxMain = GC.mainGUI.transform.Find("SelectionBox4").gameObject;
				}
			}

			GC.mainGUI.transform.Find("SelectionBox").gameObject.SetActive(true);
			GC.mainGUI.transform.Find("SelectionBox2").gameObject.SetActive(true);
			GC.mainGUI.transform.Find("SelectionBox3").gameObject.SetActive(true);
			GC.mainGUI.transform.Find("SelectionBox4").gameObject.SetActive(true);

			if (GC.coopMode)
			{
				GC.mainGUI.transform.Find("SelectionBox3").gameObject.SetActive(false);
				GC.mainGUI.transform.Find("SelectionBox4").gameObject.SetActive(false);
			}
			else if (!GC.fourPlayerMode)
			{
				GC.mainGUI.transform.Find("SelectionBox2").gameObject.SetActive(false);
				GC.mainGUI.transform.Find("SelectionBox3").gameObject.SetActive(false);
				GC.mainGUI.transform.Find("SelectionBox4").gameObject.SetActive(false);
			}

			__instance.selectionBoxWorldSpace = __instance.worldSpaceGUI.transform.Find("Scaler").transform.Find("SelectionBox").gameObject;
			__instance.selectionBoxCharSelect = GC.mainGUI.transform.Find("SelectionBoxCharSelect").gameObject;
			__instance.selectionBoxMainTr = __instance.selectionBoxMain.transform;
			__instance.selectionBoxWorldSpaceTr = __instance.selectionBoxWorldSpace.transform;
			__instance.selectionBoxCharSelectTr = __instance.selectionBoxCharSelect.transform;
			__instance.selectionBoxMainCanvas = __instance.selectionBoxMain.GetComponent<Canvas>();
			__instance.selectionBoxWorldSpaceCanvas = __instance.selectionBoxWorldSpace.GetComponent<Canvas>();
			__instance.selectionBoxCharSelectCanvas = __instance.selectionBoxCharSelect.GetComponent<Canvas>();
			__instance.selectionBoxMainAnimator = __instance.selectionBoxMain.GetComponent<Animator>();
			__instance.selectionBoxWorldSpaceAnimator = __instance.selectionBoxWorldSpace.GetComponent<Animator>();
			__instance.selectionBoxCharSelectAnimator = __instance.selectionBoxCharSelect.GetComponent<Animator>();
			__instance.interfaceTarget = GC.mainGUI.transform.Find("InterfaceTarget").GetComponent<InterfaceTarget>();
			__instance.tooltipWorldSpace = __instance.worldSpaceGUI.transform.Find("Scaler").transform.Find("Tooltip").gameObject;
			__instance.tooltipWorldSpace.GetComponent<Canvas>().enabled = true;
			__instance.draggedInvItem = null;
			__instance.thrownItem = null;

			if (__instance.mainGUI.agent.controllerType != "Keyboard")
				__instance.tooltipCanvas.enabled = true;

			__instance.instructionText = __instance.mainGUI.invContent.transform.Find("InstructionText").transform;
			__instance.instructionText1 = __instance.instructionText.Find("InstructionText1").GetComponent<Text>();
			__instance.instructionText2 = __instance.instructionText.Find("InstructionText2").GetComponent<Text>();
			__instance.instructionText3 = __instance.instructionText.Find("InstructionText3").GetComponent<Text>();
			__instance.instructionText4 = __instance.instructionText.Find("InstructionText4").GetComponent<Text>();
			__instance.tooltipText0 = new Text[2];
			__instance.tooltipText1 = new Text[2];
			__instance.tooltipText2 = new Text[2];
			__instance.tooltipText3 = new Text[2];
			__instance.tooltipText4 = new Text[2];
			__instance.tooltipText5 = new Text[2];
			__instance.tooltipButtonImage = new Image[2];
			__instance.tooltipButtonImage2 = new Image[2];
			__instance.tooltipButtonImage3 = new Image[2];
			__instance.tooltipButtonImage4 = new Image[2];
			__instance.tooltipButtonImageCanvas = new Canvas[2];
			__instance.tooltipButtonImageCanvas2 = new Canvas[2];
			__instance.tooltipButtonImageCanvas3 = new Canvas[2];
			__instance.tooltipButtonImageCanvas4 = new Canvas[2];
			__instance.tooltipButtonImageGo = new GameObject[2];
			__instance.tooltipButtonImage2Go = new GameObject[2];
			__instance.tooltipButtonImage3Go = new GameObject[2];
			__instance.tooltipButtonImage4Go = new GameObject[2];
			__instance.tooltipText0[0] = __instance.tooltip.transform.GetChild(1).GetComponent<Text>();
			__instance.tooltipText1[0] = __instance.tooltip.transform.GetChild(2).GetComponent<Text>();
			__instance.tooltipText2[0] = __instance.tooltip.transform.GetChild(3).GetComponent<Text>();
			__instance.tooltipText3[0] = __instance.tooltip.transform.GetChild(4).GetComponent<Text>();
			__instance.tooltipText4[0] = __instance.tooltip.transform.GetChild(5).GetComponent<Text>();
			__instance.tooltipText5[0] = __instance.tooltip.transform.GetChild(6).GetComponent<Text>();
			__instance.tooltipText0[1] = __instance.tooltipWorldSpace.transform.GetChild(1).GetComponent<Text>();
			__instance.tooltipText1[1] = __instance.tooltipWorldSpace.transform.GetChild(2).GetComponent<Text>();
			__instance.tooltipText2[1] = __instance.tooltipWorldSpace.transform.GetChild(3).GetComponent<Text>();
			__instance.tooltipText3[1] = __instance.tooltipWorldSpace.transform.GetChild(4).GetComponent<Text>();
			__instance.tooltipText4[1] = __instance.tooltipWorldSpace.transform.GetChild(5).GetComponent<Text>();
			__instance.tooltipText5[1] = __instance.tooltipWorldSpace.transform.GetChild(6).GetComponent<Text>();
			__instance.tooltipButtonImage[0] = __instance.tooltip.transform.Find("ItemActionImage").GetComponent<Image>();
			__instance.tooltipButtonImage[1] = __instance.tooltipWorldSpace.transform.Find("ItemActionImage").GetComponent<Image>();
			__instance.tooltipText2[0].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText3[0].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText4[0].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText5[0].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText2[1].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText3[1].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText4[1].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText5[1].rectTransform.pivot = new Vector2(0f, 1f);
			__instance.tooltipText2[0].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText3[0].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText4[0].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText5[0].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText2[1].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText3[1].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText4[1].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText5[1].alignment = TextAnchor.MiddleCenter;
			__instance.tooltipText2[0].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText3[0].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText4[0].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText5[0].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText2[1].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText3[1].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText4[1].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText5[1].rectTransform.sizeDelta = new Vector2(450f, 48f);
			__instance.tooltipText2[0].rectTransform.anchoredPosition = new Vector2(-115f, -128f);
			__instance.tooltipText3[0].rectTransform.anchoredPosition = new Vector2(-115f, -158f);
			__instance.tooltipText4[0].rectTransform.anchoredPosition = new Vector2(-115f, -188f);
			__instance.tooltipText5[0].rectTransform.anchoredPosition = new Vector2(-115f, -218f);
			__instance.tooltipText2[1].rectTransform.anchoredPosition = new Vector2(-115f, -128f);
			__instance.tooltipText3[1].rectTransform.anchoredPosition = new Vector2(-115f, -158f);
			__instance.tooltipText4[1].rectTransform.anchoredPosition = new Vector2(-115f, -188f);
			__instance.tooltipText5[1].rectTransform.anchoredPosition = new Vector2(-115f, -218f);

			if (__instance.mainGUI.agent.controllerTypeSpecific == "Keyboard" && (GC.coopMode || GC.fourPlayerMode || GC.multiplayerMode))
			{
				__instance.tooltipText1[0].rectTransform.sizeDelta = new Vector2(__instance.tooltipText1[0].rectTransform.sizeDelta.x,
					__instance.tooltipText1[0].rectTransform.sizeDelta.y - 20f);
				__instance.tooltipText1[1].rectTransform.sizeDelta = new Vector2(__instance.tooltipText1[1].rectTransform.sizeDelta.x,
					__instance.tooltipText1[1].rectTransform.sizeDelta.y - 20f);
				__instance.tooltipText1[0].rectTransform.anchoredPosition = new Vector2(__instance.tooltipText1[0].rectTransform.anchoredPosition.x,
					__instance.tooltipText1[0].rectTransform.anchoredPosition.y + 10f);
				__instance.tooltipText1[1].rectTransform.anchoredPosition = new Vector2(__instance.tooltipText1[1].rectTransform.anchoredPosition.x,
					__instance.tooltipText1[1].rectTransform.anchoredPosition.y + 10f);
				__instance.tooltipText2[0].rectTransform.anchoredPosition = new Vector2(-115f, -108f);
				__instance.tooltipText3[0].rectTransform.anchoredPosition = new Vector2(-115f, -138f);
				__instance.tooltipText4[0].rectTransform.anchoredPosition = new Vector2(-115f, -168f);
				__instance.tooltipText5[0].rectTransform.anchoredPosition = new Vector2(-115f, -198f);
				__instance.tooltipText2[1].rectTransform.anchoredPosition = new Vector2(-115f, -108f);
				__instance.tooltipText3[1].rectTransform.anchoredPosition = new Vector2(-115f, -138f);
				__instance.tooltipText4[1].rectTransform.anchoredPosition = new Vector2(-115f, -168f);
				__instance.tooltipText5[1].rectTransform.anchoredPosition = new Vector2(-115f, -198f);
			}

			__instance.tooltipButtonImage[0].rectTransform.anchoredPosition = new Vector2(-115f, -138f);
			__instance.tooltipButtonImage[1].rectTransform.anchoredPosition = new Vector2(-115f, -138f);

			if (GC.sessionDataBig.gameLanguage == "schinese" || GC.sessionDataBig.specialCharacterSizeFitting)
			{
				__instance.tooltipText1[0].resizeTextForBestFit = false;
				__instance.tooltipText1[1].resizeTextForBestFit = false;
			}

			if (__instance.mainGUI.agent.controllerTypeSpecific != "Keyboard")
			{
				for (int i = 0; i < 2; i++)
				{
					__instance.tooltipText2[i].alignment = 0;
					__instance.tooltipText2[i].transform.localPosition = new Vector3(__instance.tooltipText2[i].transform.localPosition.x + 30f,
						__instance.tooltipText2[i].transform.localPosition.y, __instance.tooltipText2[i].transform.localPosition.z);
					__instance.tooltipText3[i].alignment = 0;
					__instance.tooltipText3[i].transform.localPosition = new Vector3(__instance.tooltipText3[i].transform.localPosition.x + 30f,
						__instance.tooltipText3[i].transform.localPosition.y, __instance.tooltipText3[i].transform.localPosition.z);
					__instance.tooltipText4[i].alignment = 0;
					__instance.tooltipText4[i].transform.localPosition = new Vector3(__instance.tooltipText4[i].transform.localPosition.x + 30f,
						__instance.tooltipText4[i].transform.localPosition.y, __instance.tooltipText4[i].transform.localPosition.z);
					__instance.tooltipText5[i].alignment = 0;
					__instance.tooltipText5[i].transform.localPosition = new Vector3(__instance.tooltipText5[i].transform.localPosition.x + 30f,
						__instance.tooltipText5[i].transform.localPosition.y, __instance.tooltipText5[i].transform.localPosition.z);
				}
			}
			else
			{
				for (int j = 0; j < 2; j++)
				{
					__instance.tooltipText2[j].rectTransform.pivot = new Vector2(0.5f, 0.5f);
					__instance.tooltipText3[j].rectTransform.pivot = new Vector2(0.5f, 0.5f);
					__instance.tooltipText4[j].rectTransform.pivot = new Vector2(0.5f, 0.5f);
					__instance.tooltipText5[j].rectTransform.pivot = new Vector2(0.5f, 0.5f);
					__instance.tooltipText2[j].rectTransform.sizeDelta = new Vector2(600f, 48f);
					__instance.tooltipText3[j].rectTransform.sizeDelta = new Vector2(600f, 48f);
					__instance.tooltipText4[j].rectTransform.sizeDelta = new Vector2(600f, 48f);
					__instance.tooltipText5[j].rectTransform.sizeDelta = new Vector2(600f, 48f);
					__instance.tooltipText2[j].rectTransform.localPosition = new Vector2(160f, __instance.tooltipText2[j].rectTransform.localPosition.y);
					__instance.tooltipText3[j].rectTransform.localPosition = new Vector2(160f, __instance.tooltipText3[j].rectTransform.localPosition.y);
					__instance.tooltipText4[j].rectTransform.localPosition = new Vector2(160f, __instance.tooltipText4[j].rectTransform.localPosition.y);
					__instance.tooltipText5[j].rectTransform.localPosition = new Vector2(160f, __instance.tooltipText5[j].rectTransform.localPosition.y);
				}
			}

			__instance.instructionTextImage1 = __instance.instructionText.Find("InstructionTextImage1").GetComponent<Image>();
			__instance.instructionTextImage2 = __instance.instructionText.Find("InstructionTextImage2").GetComponent<Image>();
			__instance.instructionTextImage3 = __instance.instructionText.Find("InstructionTextImage3").GetComponent<Image>();
			__instance.instructionTextImage4 = __instance.instructionText.Find("InstructionTextImage4").GetComponent<Image>();
			__instance.tooltipButtonImage2[0] = __instance.tooltip.transform.Find("ItemActionImage2").GetComponent<Image>();
			__instance.tooltipButtonImage3[0] = __instance.tooltip.transform.Find("ItemActionImage3").GetComponent<Image>();
			__instance.tooltipButtonImage4[0] = __instance.tooltip.transform.Find("ItemActionImage4").GetComponent<Image>();
			__instance.tooltipButtonImageCanvas[0] = __instance.tooltipButtonImage[0].GetComponent<Canvas>();
			__instance.tooltipButtonImageCanvas2[0] = __instance.tooltipButtonImage2[0].GetComponent<Canvas>();
			__instance.tooltipButtonImageCanvas3[0] = __instance.tooltipButtonImage3[0].GetComponent<Canvas>();
			__instance.tooltipButtonImageCanvas4[0] = __instance.tooltipButtonImage4[0].GetComponent<Canvas>();
			__instance.tooltipButtonImageGo[0] = __instance.tooltipButtonImage[0].gameObject;
			__instance.tooltipButtonImage2Go[0] = __instance.tooltipButtonImage2[0].gameObject;
			__instance.tooltipButtonImage3Go[0] = __instance.tooltipButtonImage3[0].gameObject;
			__instance.tooltipButtonImage4Go[0] = __instance.tooltipButtonImage4[0].gameObject;
			__instance.tooltipButtonImage2[1] = __instance.tooltipWorldSpace.transform.Find("ItemActionImage2").GetComponent<Image>();
			__instance.tooltipButtonImage3[1] = __instance.tooltipWorldSpace.transform.Find("ItemActionImage3").GetComponent<Image>();
			__instance.tooltipButtonImage4[1] = __instance.tooltipWorldSpace.transform.Find("ItemActionImage4").GetComponent<Image>();
			__instance.tooltipButtonImageCanvas[1] = __instance.tooltipButtonImage[1].GetComponent<Canvas>();
			__instance.tooltipButtonImageCanvas2[1] = __instance.tooltipButtonImage2[1].GetComponent<Canvas>();
			__instance.tooltipButtonImageCanvas3[1] = __instance.tooltipButtonImage3[1].GetComponent<Canvas>();
			__instance.tooltipButtonImageCanvas4[1] = __instance.tooltipButtonImage4[1].GetComponent<Canvas>();
			__instance.tooltipButtonImageGo[1] = __instance.tooltipButtonImage[1].gameObject;
			__instance.tooltipButtonImage2Go[1] = __instance.tooltipButtonImage2[1].gameObject;
			__instance.tooltipButtonImage3Go[1] = __instance.tooltipButtonImage3[1].gameObject;
			__instance.tooltipButtonImage4Go[1] = __instance.tooltipButtonImage4[1].gameObject;

			if (GC.fourPlayerMode && __instance.mainGUI.fourPlayerNoToolbar)
			{
				for (int k = 0; k < 2; k++)
				{
					__instance.tooltipText2[k].transform.localPosition = new Vector2(__instance.tooltipText2[k].transform.localPosition.x,
						__instance.tooltipText2[k].transform.localPosition.y - 30f);
					__instance.tooltipButtonImage[k].transform.localPosition = new Vector2(__instance.tooltipButtonImage[k].transform.localPosition.x,
						__instance.tooltipButtonImage[k].transform.localPosition.y - 30f);
				}
			}

			__instance.selectionBoxAnimator = __instance.selectionBoxMain.GetComponent<Animator>();
			__instance.StartCoroutine(__instance.LateSetup());

			for (int l = 0; l < __instance.Slots.Count; l++)
			{
				if (__instance.Slots[l] != null)
				{
					GC.mainGUI.AllSlots.Remove(__instance.Slots[l]);
					Object.Destroy(__instance.Slots[l].gameObject);
				}
			}

			__instance.Slots.Clear();
			___slotXPos = -128;
			___slotYPos = 96;
			__instance.numSlotRows = 8;

			if (__instance.mainGUI.agent.controllerTypeSpecific == "Keyboard" && (!GC.fourPlayerMode || !__instance.mainGUI.fourPlayerNoToolbar))
			{
				__instance.numSlotCols = 4;
				___slotYPos = 110;
			}
			else
			{
				__instance.numSlotCols = 5;
				___slotYPos = 32;
			}

			int num = 0;
			int num2 = 0;
			int num3 = 0;

			for (int m = 0; m < __instance.numSlotCols; m++)
			{
				for (int n = 0; n < __instance.numSlotRows; n++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(__instance.slots);
					gameObject.GetComponent<InvSlot>().slotNumber = num;
					gameObject.GetComponent<InvSlot>().totalSlotNumber = num2;
					gameObject.GetComponent<InvSlot>().realTotalSlotNumber = num3;
					gameObject.GetComponent<InvSlot>().slotType = "Player";
					gameObject.GetComponent<InvSlot>().slotTypePlayer = true;
					gameObject.transform.Find("ToolbarSlotNum").gameObject.SetActive(false);

					if (num > 19 && (!(__instance.mainGUI.agent.controllerTypeSpecific != "Keyboard") || num - 19 != 5))
					{
						if (!GC.fourPlayerMode || !__instance.mainGUI.fourPlayerNoToolbar)
							gameObject.transform.Find("ToolbarSlotNum").GetComponent<Text>().text = string.Concat(num - 19);

						GameObject gameObject2 = gameObject.transform.Find("ToolbarArrowImage").gameObject;

						if (!GC.fourPlayerMode || !__instance.mainGUI.fourPlayerNoToolbar)
							gameObject2.SetActive(true);
						else
							gameObject2.SetActive(false);

						if (num == 20)
							gameObject2.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
						else if (num == 21)
							gameObject2.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
						else if (num == 22)
							gameObject2.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
					}

					__instance.Slots.Add(gameObject.GetComponent<InvSlot>());
					__instance.mainGUI.AllSlots.Add(gameObject.GetComponent<InvSlot>());
					gameObject.name = string.Concat(new object[] { "InvSlot (", m + 1, ".", n + 1, ")" });
					gameObject.transform.SetParent(__instance.transform.GetChild(0).transform.GetChild(0).transform);
					gameObject.GetComponent<RectTransform>().localPosition = new Vector3((float)___slotXPos, (float)___slotYPos, 0f);
					___slotXPos += 80;

					if (n == __instance.numSlotRows - 1)
					{
						___slotXPos = -128;
						___slotYPos -= 80;

						if (m == 3)
							___slotYPos = 112;
					}

					gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					gameObject.GetComponent<InvSlot>().canvas = gameObject.transform.parent.GetComponent<Canvas>();
					num++;
					num2++;
					num3++;
				}
			}

			num -= __instance.numSlotRows;
			num2 -= __instance.numSlotRows;

			if (__instance.mainGUI.agent.controllerTypeSpecific == "Keyboard" && (!GC.fourPlayerMode || !__instance.mainGUI.fourPlayerNoToolbar))
			{
				num += 5;
				___slotXPos = -128;
				___slotYPos = 0;
				__instance.database.toolbarSlots = 5;

				for (int num4 = 0; num4 < __instance.database.toolbarSlots; num4++)
				{
					GameObject gameObject3 = Object.Instantiate<GameObject>(__instance.slots);
					gameObject3.GetComponent<InvSlot>().slotNumber = num;
					gameObject3.GetComponent<InvSlot>().totalSlotNumber = num2;
					gameObject3.GetComponent<InvSlot>().realTotalSlotNumber = num3;
					gameObject3.GetComponent<InvSlot>().slotType = "Toolbar";
					gameObject3.GetComponent<InvSlot>().slotTypeToolbar = true;

					if (!GC.fourPlayerMode || !__instance.mainGUI.fourPlayerNoToolbar)
						gameObject3.transform.Find("ToolbarSlotNum").GetComponent<Text>().text = string.Concat(num - 19);

					__instance.Slots.Add(gameObject3.GetComponent<InvSlot>());
					__instance.mainGUI.AllSlots.Add(gameObject3.GetComponent<InvSlot>());
					gameObject3.name = "ToolbarSlot (" + num4 + ")";
					gameObject3.transform.SetParent(__instance.mainGUI.transform.Find("Toolbar").transform);
					gameObject3.GetComponent<RectTransform>().localPosition = new Vector3((float)___slotXPos, (float)___slotYPos, 0f);
					___slotXPos += 80;
					gameObject3.transform.localScale = new Vector3(1f, 1f, 1f);
					gameObject3.GetComponent<InvSlot>().canvas = gameObject3.transform.parent.GetComponent<Canvas>();
					num++;
					num2++;
					num3++;
				}
			}
			else
			{
				foreach (object obj in __instance.mainGUI.transform)
				{
					Transform transform = (Transform)obj;

					if (transform.gameObject.name == "InvButton" || transform.gameObject.name == "QuestButton" ||
						transform.gameObject.name == "CharacterButton" || transform.gameObject.name == "Outline1" || transform.gameObject.name == "Outline2" ||
						transform.gameObject.name == "Outline3")
						transform.gameObject.SetActive(false);
				}

				__instance.mainGUI.toolbar.GetComponent<Image>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
				__instance.mainGUI.toolbar.transform.GetChild(0).GetComponent<Image>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
				__instance.database.toolbarSlots = 5;

				for (int num5 = 0; num5 < __instance.database.toolbarSlots; num5++)
				{
					GameObject gameObject4 = Object.Instantiate<GameObject>(__instance.slots);
					gameObject4.GetComponent<InvSlot>().slotNumber = num;
					gameObject4.GetComponent<InvSlot>().totalSlotNumber = num2;
					gameObject4.GetComponent<InvSlot>().slotType = "Toolbar";
					gameObject4.GetComponent<InvSlot>().slotTypeToolbar = true;
					gameObject4.transform.Find("ToolbarSlotNum").gameObject.SetActive(false);
					GameObject gameObject5 = gameObject4.transform.Find("ToolbarArrowImage").gameObject;

					if (!GC.fourPlayerMode || !__instance.mainGUI.fourPlayerNoToolbar)
						gameObject5.SetActive(true);
					else
						gameObject5.SetActive(false);

					if (num == 20)
						gameObject5.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
					else if (num == 21)
						gameObject5.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
					else if (num == 22)
						gameObject5.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);

					__instance.Slots.Add(gameObject4.GetComponent<InvSlot>());
					__instance.mainGUI.AllSlots.Add(gameObject4.GetComponent<InvSlot>());
					gameObject4.name = "ToolbarSlot (" + num5 + ")";
					gameObject4.transform.SetParent(__instance.mainGUI.transform.Find("Toolbar").transform);
					int num6 = 0;

					if (__instance.mainGUI.agent.controllerType != "Keyboard" || (GC.fourPlayerMode && __instance.mainGUI.fourPlayerNoToolbar))
					{
						if (GC.coopMode)
						{
							if (__instance.mainGUI.agent == GC.playerAgent2)
								num6 = 476;
							else
								num6 = 33;
						}
						else
							num6 = 33;
					}

					if (num5 == 0)
						gameObject4.GetComponent<RectTransform>().localPosition = new Vector3((float)(-90 + num6), 68f, 0f);
					else if (num5 == 1)
						gameObject4.GetComponent<RectTransform>().localPosition = new Vector3((float)(-170 + num6), 28f, 0f);
					else if (num5 == 2)
						gameObject4.GetComponent<RectTransform>().localPosition = new Vector3((float)(-10 + num6), 28f, 0f);
					else if (num5 == 3)
						gameObject4.GetComponent<RectTransform>().localPosition = new Vector3((float)(-90 + num6), -12f, 0f);
					else if (num5 == 4)
						gameObject4.GetComponent<RectTransform>().localPosition = new Vector3(2000f, 68f, 0f);

					gameObject4.transform.localScale = new Vector3(1f, 1f, 1f);
					gameObject4.GetComponent<InvSlot>().canvas = gameObject4.transform.parent.GetComponent<Canvas>();
					num++;
					num2++;
				}
			}

			num = 0;
			num2 += __instance.numSlotRows;
			___slotXPos = -200;
			___slotYPos = 0;

			for (int num7 = 0; num7 < __instance.database.npcInvSlots; num7++)
			{
				if (num7 == 0)
					__instance.firstNPCChestSlot = num2;

				GameObject gameObject6 = Object.Instantiate<GameObject>(__instance.slots);
				gameObject6.GetComponent<InvSlot>().slotNumber = num7;
				gameObject6.GetComponent<InvSlot>().totalSlotNumber = num2;
				gameObject6.GetComponent<InvSlot>().slotType = "NPCChest";
				gameObject6.GetComponent<InvSlot>().slotTypeNPCChest = true;
				__instance.Slots.Add(gameObject6.GetComponent<InvSlot>());
				__instance.mainGUI.AllSlots.Add(gameObject6.GetComponent<InvSlot>());
				gameObject6.name = "NPCSlot (" + num7 + ")";
				gameObject6.transform.SetParent(__instance.worldSpaceGUI.npcChest.transform.GetChild(0).transform);
				gameObject6.GetComponent<RectTransform>().localPosition = new Vector3((float)___slotXPos, (float)___slotYPos, 0f);
				___slotXPos += 80;
				gameObject6.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject6.GetComponent<InvSlot>().canvas = gameObject6.transform.parent.transform.parent.GetComponent<Canvas>();
				num++;
				num2++;
			}

			___slotXPos = -80;
			___slotYPos = 0;

			for (int num8 = 0; num8 < __instance.database.chestInvSlots; num8++)
			{
				if (num8 == 0)
					__instance.firstChestSlot = num2;

				GameObject gameObject7 = Object.Instantiate<GameObject>(__instance.slots);
				gameObject7.GetComponent<InvSlot>().slotNumber = num8;
				gameObject7.GetComponent<InvSlot>().totalSlotNumber = num2;
				gameObject7.GetComponent<InvSlot>().slotType = "Chest";
				gameObject7.GetComponent<InvSlot>().slotTypeChest = true;
				gameObject7.transform.Find("ToolbarSlotNum").gameObject.SetActive(false);
				__instance.Slots.Add(gameObject7.GetComponent<InvSlot>());
				__instance.mainGUI.AllSlots.Add(gameObject7.GetComponent<InvSlot>());
				gameObject7.name = "ChestSlot (" + num8 + ")";
				gameObject7.transform.SetParent(__instance.worldSpaceGUI.chest.transform.GetChild(0).transform);
				gameObject7.GetComponent<RectTransform>().localPosition = new Vector3((float)___slotXPos, (float)___slotYPos, 0f);
				___slotXPos += 80;
				gameObject7.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject7.GetComponent<InvSlot>().canvas = gameObject7.transform.parent.transform.parent.GetComponent<Canvas>();
				num++;
				num2++;
			}

			___slotXPos = -128;
			___slotYPos = 32;
			num = 0;

			for (int num9 = 0; num9 < __instance.numSlotCols; num9++)
				for (int num10 = 0; num10 < __instance.numSlotRows; num10++)
				{
					if (num9 == 0 && num10 == 0)
						__instance.firstUseOnSlot = num2;

					GameObject gameObject8 = Object.Instantiate<GameObject>(__instance.slots);
					gameObject8.GetComponent<InvSlot>().slotNumber = num;
					gameObject8.GetComponent<InvSlot>().totalSlotNumber = num2;
					gameObject8.GetComponent<InvSlot>().slotType = "UseOn";
					gameObject8.GetComponent<InvSlot>().slotTypeUseOn = true;
					gameObject8.transform.Find("ToolbarSlotNum").gameObject.SetActive(false);
					__instance.Slots.Add(gameObject8.GetComponent<InvSlot>());
					__instance.mainGUI.AllSlots.Add(gameObject8.GetComponent<InvSlot>());
					gameObject8.name = string.Concat(new object[] { "UseOnSlot (", num9 + 1, ".", num10 + 1, ")" });
					gameObject8.transform.SetParent(__instance.worldSpaceGUI.useOn.transform);
					gameObject8.GetComponent<RectTransform>().localPosition = new Vector3((float)___slotXPos, (float)___slotYPos, 0f);
					___slotXPos += 80;

					if (num10 == __instance.numSlotRows - 1)
					{
						___slotXPos = -128;
						___slotYPos -= 80;

						if (num9 == 3)
							___slotYPos = 112;
					}

					gameObject8.transform.localScale = new Vector3(1f, 1f, 1f);
					gameObject8.GetComponent<InvSlot>().canvas = gameObject8.transform.parent.transform.parent.GetComponent<Canvas>();
					num++;
					num2++;
				}

			if (__instance.mainGUI.agent == GC.playerAgent)
			{
				CharacterSelect component = GameObject.Find("CharacterSelectMenu").GetComponent<CharacterSelect>();
				component.FakeStart();
				___slotXPos = -280;
				___slotYPos = 0;
				num = 0;
				Sprite sprite = __instance.gr.gui[16];

				for (int num11 = 0; num11 < 6; num11++)
					for (int num12 = 0; num12 < 8; num12++)
					{
						if (num11 == 0 && num12 == 0)
							__instance.firstCharacterSelectSlot = num2;

						GameObject gameObject9 = Object.Instantiate<GameObject>(__instance.slots);
						gameObject9.GetComponent<InvSlot>().slotNumber = num;
						gameObject9.GetComponent<InvSlot>().totalSlotNumber = num2;
						gameObject9.GetComponent<InvSlot>().slotType = "CharacterSelect";
						gameObject9.GetComponent<InvSlot>().slotTypeCharacterSelect = true;
						gameObject9.transform.Find("ToolbarSlotNum").gameObject.SetActive(false);
						gameObject9.transform.Find("InvItemIcon").gameObject.SetActive(false);
						gameObject9.transform.Find("InvItemCount").gameObject.SetActive(false);
						__instance.Slots.Add(gameObject9.GetComponent<InvSlot>());
						__instance.mainGUI.AllSlots.Add(gameObject9.GetComponent<InvSlot>());

						if (GC.coopMode || GC.fourPlayerMode)
						{
							GC.playerAgent2.mainGUI.invInterface.Slots.Add(gameObject9.GetComponent<InvSlot>());
							GC.playerAgent2.mainGUI.AllSlots.Add(gameObject9.GetComponent<InvSlot>());

							if (GC.fourPlayerMode)
							{
								GC.playerAgent3.mainGUI.invInterface.Slots.Add(gameObject9.GetComponent<InvSlot>());
								GC.playerAgent3.mainGUI.AllSlots.Add(gameObject9.GetComponent<InvSlot>());
								GC.playerAgent4.mainGUI.invInterface.Slots.Add(gameObject9.GetComponent<InvSlot>());
								GC.playerAgent4.mainGUI.AllSlots.Add(gameObject9.GetComponent<InvSlot>());
							}
						}

						gameObject9.name = string.Concat(new object[] { "CharacterSelectSlot (", num11 + 1, ".", num12 + 1, ")" });
						gameObject9.transform.SetParent(__instance.mainGUI.characterSelect.transform.Find("CharacterBoxes").transform);
						gameObject9.GetComponent<RectTransform>().localPosition = new Vector3((float)___slotXPos, (float)___slotYPos, 0f);
						component.slotAgent[num] = Object.Instantiate<GameObject>(__instance.slotAgent);
						component.slotAgent[num].transform.position = gameObject9.transform.position;
						component.slotAgent[num].transform.SetParent(gameObject9.transform);
						component.slotAgent[num].transform.localScale = new Vector3(1f, 1f, 1f);
						gameObject9.GetComponent<InvSlot>().canvas = gameObject9.transform.parent.transform.parent.GetComponent<Canvas>();
						___slotXPos += 80;

						if (num12 == 7)
						{
							___slotXPos = -280;
							___slotYPos -= 80;
						}

						gameObject9.transform.localScale = new Vector3(1f, 1f, 1f);

						if (num >= 32)
							gameObject9.GetComponent<InvSlot>().itemImage.sprite = sprite;

						num++;
						num2++;
					}
			}

			for (int num13 = 0; num13 < 4; num13++)
				__instance.ItemButtonList.Add(new ItemButton());

			return false;
		}

		[HarmonyPrefix, HarmonyPatch(methodName:nameof(InvInterface.ShowCursorText), argumentTypes:new[] { typeof(string), typeof(string), typeof(PlayfieldObject), typeof(int) })]
		public static bool ShowCursorText_Prefix(string myText, string myText2, PlayfieldObject myPlayfieldObject, int specificColor,	InvInterface __instance) 
		{
			// "Guilty" cursor text and others

			bool player2 = false;
			bool player3 = false;
			bool player4 = false;

			if (GC.levelEnded || __instance.noCursorText)
				return false;

			if (__instance.cursorTextAgent != null)
			{
				__instance.cursorTextAgent.showingCursorText = false;
				__instance.cursorTextAgent = null;
			}

			if (GC.coopMode || GC.fourPlayerMode)
			{
				if (GC.mainGUI2.openedQuestSheet && GC.mainGUI2.questSheetScript.openedByPlayer == GC.playerAgent2)
					player2 = true;

				if (GC.fourPlayerMode)
				{
					if (GC.mainGUI3.openedQuestSheet && GC.mainGUI3.questSheetScript.openedByPlayer == GC.playerAgent3)
						player3 = true;

					if (GC.mainGUI4.openedQuestSheet && GC.mainGUI4.questSheetScript.openedByPlayer == GC.playerAgent4)
						player4 = true;
				}
			}

			if (Cursor.visible || __instance.mainGUI.agent.controllerType != "Keyboard" || player2 || player3 || player4)
			{
				__instance.cursorTextCanvas.enabled = true;
				__instance.cursorTextString.text = myText;

				#region Colors & Health Bar

				if (myPlayfieldObject != null)
				{
					if (myPlayfieldObject.playfieldObjectType == "Agent")
					{
						Agent agent = (Agent)myPlayfieldObject;
						__instance.cursorTextAgent = agent;
						__instance.cursorTextAgent.showingCursorText = true;

						if (GC.levelType == "Normal")
						{
							try
							{
								if (agent.health != agent.healthMax && agent.health != 0f && !agent.localPlayer)
									agent.agentHealthBar.ChangeHealth(true, false);
							}
							catch
							{
								Debug.LogError("Error in AgentHealthBar ChangeHealth: " + agent);
							}
						}

						if (agent.ownerID > 0)
							__instance.cursorTextString.color = new Color32(byte.MaxValue, 225, 0, byte.MaxValue);
						else
							__instance.cursorTextString.color = Color.white;
					}
					else if (myPlayfieldObject.playfieldObjectType == "ObjectReal")
					{
						if (((ObjectReal)myPlayfieldObject).owner > 0)
							__instance.cursorTextString.color = new Color32(byte.MaxValue, 225, 0, byte.MaxValue);
						else
							__instance.cursorTextString.color = Color.white;
					}
					else if (myPlayfieldObject.playfieldObjectType == "Item")
					{
						Item item = (Item)myPlayfieldObject;

						if (item.owner != null)
						{
							if (item.owner.isPlayer == 0)
								__instance.cursorTextString.color = new Color32(byte.MaxValue, 225, 0, byte.MaxValue);
							else
								__instance.cursorTextString.color = Color.white;
						}
						else
							__instance.cursorTextString.color = Color.white;
					}
				}
				else
					__instance.cursorTextString.color = Color.white;

				if (myText2 != "" && myText2 != "\n()")
				{
					if (myText2.Contains("Hateful"))
					{
						__instance.cursorTextString2.color = Color.red;
						__instance.cursorTextString2.text = "\n(" + InvInterface.hatefulName + ")";
					}
					else if (myText2.Contains("Annoyed"))
					{
						__instance.cursorTextString2.color = new Color32(byte.MaxValue, 155, 0, byte.MaxValue);
						__instance.cursorTextString2.text = "\n(" + InvInterface.annoyedName + ")";
					}
					else if (myText2.Contains("Friendly"))
					{
						__instance.cursorTextString2.color = Color.cyan;
						__instance.cursorTextString2.text = "\n(" + InvInterface.friendlyName + ")";
					}
					else if (myText2.Contains("Loyal"))
					{
						__instance.cursorTextString2.color = Color.cyan;
						__instance.cursorTextString2.text = "\n(" + InvInterface.loyalName + ")";
					}
					else if (myText2.Contains("Aligned"))
					{
						__instance.cursorTextString2.color = Color.green;
						__instance.cursorTextString2.text = "\n(" + InvInterface.alignedName + ")";
					}
					else if (myText2.Contains("Submissive"))
					{
						__instance.cursorTextString2.color = Color.green;
						__instance.cursorTextString2.text = "\n(" + InvInterface.submissiveName + ")";
					}
					else if (myText2.Contains("Teleport"))
					{
						__instance.cursorTextString2.color = Color.red;
						__instance.cursorTextString2.text = "\n" + GC.nameDB.GetName(myText2, "Interface");
					}
					else if (myText2.Contains("Requirement"))
					{
						__instance.cursorTextString2.color = Color.red;
						__instance.cursorTextString2.text = "\n(" + GC.nameDB.GetName(myText2, "Unlock") + ")";
					}
					else if (myText2.Contains("Steam"))
					{
						__instance.cursorTextString2.color = Color.red;
						__instance.cursorTextString2.text = "\n(" + GC.nameDB.GetName(myText2, "Interface") + ")";
					}
					else if (myText2.Contains("RightClickToChangeCharacter"))
					{
						__instance.cursorTextString2.color = Color.yellow;
						__instance.cursorTextString2.text = "\n(" + GC.nameDB.GetName(myText2, "Interface") + ")";
					}
					else if (myText2.Contains("OnlyPasswordProtected"))
					{
						__instance.cursorTextString2.color = Color.red;
						__instance.cursorTextString2.text = "\n(" + GC.nameDB.GetName(myText2, "Interface") + ")";
					}
					else if (myText2 != "" && myText2 != null)
					{
						__instance.cursorTextString2.color = Color.white;
						__instance.cursorTextString2.text = myText2;
					}

					if (__instance.cursorTextString2.text.Contains("E_"))
					{
						__instance.cursorTextString2.color = Color.white;
						__instance.cursorTextString2.text = myText2;
					}

					if (!myText2.Contains("Neutral"))
						__instance.cursorTextCanvas2.enabled = true;
					else
						__instance.cursorTextCanvas2.enabled = false;
				}
				else
					__instance.cursorTextCanvas2.enabled = false;

				#endregion

				__instance.cursorTextCanvas4.enabled = false;
				__instance.cursorTextCanvas5.enabled = false;
				bool flag4 = false;

				if (myPlayfieldObject != null && myPlayfieldObject.playfieldObjectType == "Agent")
				{
					Agent agent2 = (Agent)myPlayfieldObject;

					if (agent2.statusEffects.StatusEffectList.Count > 0 && (agent2.isPlayer == 0 || !agent2.localPlayer))
					{
						__instance.cursorTextCanvas4.enabled = true;
						__instance.cursorTextString4.color = Color.magenta;

						if (__instance.cursorTextCanvas2.enabled)
							__instance.cursorTextString4.text = "\n\n(";
						else
							__instance.cursorTextString4.text = "\n(";

						if (agent2.statusEffects.StatusEffectList.Count > 1)
						{
							Text text = __instance.cursorTextString4;
							text.text = text.text + GC.nameDB.GetName(agent2.statusEffects.StatusEffectList[0].statusEffectName, "StatusEffect") + "...)";
						}
						else
						{
							Text text2 = __instance.cursorTextString4;
							text2.text = text2.text + GC.nameDB.GetName(agent2.statusEffects.StatusEffectList[0].statusEffectName, "StatusEffect") + ")";
						}
					}

					bool flag5 = false;

					if ((__instance.mainGUI.agent.enforcer || __instance.mainGUI.agent.bigQuest == "Cop" ||
							__instance.mainGUI.agent.HasTrait<VeryHardOnYourself>()) &&
						!agent2.statusEffects.IsInnocent(__instance.mainGUI.agent) && !agent2.dead)
					{
						flag5 = true;

						if (__instance.cursorTextCanvas4.enabled)
						{
							__instance.cursorTextCanvas5.enabled = true;
							__instance.cursorTextString5.color = new Color32(byte.MaxValue, 155, 0, byte.MaxValue);

							if (__instance.cursorTextCanvas2.enabled)
								__instance.cursorTextString5.text = "\n\n\n(";
							else
								__instance.cursorTextString5.text = "\n\n(";

							Text text3 = __instance.cursorTextString5;
							text3.text = text3.text + InvInterface.guiltyName + ")";
						}
						else
						{
							__instance.cursorTextCanvas4.enabled = true;
							__instance.cursorTextString4.color = new Color32(byte.MaxValue, 155, 0, byte.MaxValue);

							if (__instance.cursorTextCanvas2.enabled)
								__instance.cursorTextString4.text = "\n\n(";
							else
								__instance.cursorTextString4.text = "\n(";

							Text text4 = __instance.cursorTextString4;
							text4.text = text4.text + InvInterface.guiltyName + ")";
						}
					}

					if (__instance.mainGUI.agent.statusEffects.hasSpecialAbility("StealingGlove") && agent2.pickpocketedTimes > 0 && agent2.isPlayer == 0 &&
						agent2.objectMultAgent.emptyInventoryPickpocket)
					{
						if (flag5)
						{
							if (__instance.cursorTextCanvas5.enabled)
							{
								if (__instance.cursorTextCanvas2.enabled)
								{
									Text text5 = __instance.cursorTextString5;
									text5.text = text5.text + " <color=white>" + InvInterface.emptyName + "</color>";
								}
								else
								{
									flag4 = true;
									Text text6 = __instance.cursorTextString5;
									text6.text = text6.text + "\n<color=white>" + InvInterface.emptyName + "</color>";
								}
							}
							else if (__instance.cursorTextCanvas4.enabled)
							{
								__instance.cursorTextCanvas5.enabled = true;
								__instance.cursorTextString5.color = Color.white;

								if (__instance.cursorTextCanvas2.enabled)
									__instance.cursorTextString5.text = "\n\n\n";
								else
									__instance.cursorTextString5.text = "\n\n";

								Text text7 = __instance.cursorTextString5;
								text7.text += InvInterface.emptyName;
							}
						}
						else if (__instance.cursorTextCanvas4.enabled)
						{
							__instance.cursorTextCanvas5.enabled = true;
							__instance.cursorTextString5.color = Color.white;

							if (__instance.cursorTextCanvas2.enabled)
								__instance.cursorTextString5.text = "\n\n\n";
							else
								__instance.cursorTextString5.text = "\n\n";

							Text text8 = __instance.cursorTextString5;
							text8.text += InvInterface.emptyName;
						}
						else
						{
							__instance.cursorTextCanvas4.enabled = true;
							__instance.cursorTextString4.color = Color.white;

							if (__instance.cursorTextCanvas2.enabled)
								__instance.cursorTextString4.text = "\n\n";
							else
								__instance.cursorTextString4.text = "\n";

							Text text9 = __instance.cursorTextString4;
							text9.text += InvInterface.emptyName;
						}
					}
				}

				if (specificColor != 0)
					__instance.cursorTextString.color = new Color32(byte.MaxValue, 225, 0, byte.MaxValue);

				if (__instance.cursorTextString.text != "")
					__instance.cursorTextBackgroundCanvas.enabled = true;

				LayoutRebuilder.ForceRebuildLayoutImmediate(__instance.cursorTextRect);
				__instance.cursorTextBackgroundRect.localPosition = new Vector2(__instance.cursorTextRect.localPosition.x - 17f, 8f);
				float width = __instance.cursorTextRect.rect.width;
				float num = 54.5f;

				if (flag4)
					num += 44f;

				if (__instance.cursorTextString.text.Contains("\n"))
					num += 44f;

				if (__instance.cursorTextCanvas2.enabled)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(__instance.cursorTextRect2);

					if (__instance.cursorTextRect2.rect.width > width)
						width = __instance.cursorTextRect2.rect.width;

					num += 44f;
				}

				if (__instance.cursorTextCanvas4.enabled)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(__instance.cursorTextRect4);

					if (__instance.cursorTextRect4.rect.width > width)
						width = __instance.cursorTextRect4.rect.width;

					num += 44f;
				}

				if (__instance.cursorTextCanvas5.enabled)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(__instance.cursorTextRect5);

					if (__instance.cursorTextRect5.rect.width > width)
						width = __instance.cursorTextRect5.rect.width;

					num += 44f;
				}

				__instance.cursorTextBackgroundRect.sizeDelta = new Vector2(width * 0.5f + 30f, num);
			}

			return false;
		}
	}
}
