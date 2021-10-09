using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//стартовое окно и задание правил игры
public class StartGame : MonoBehaviour
{
    public Rules DeRules;
    [SerializeField]
    private Toggle[] rulesToggle=new Toggle[3]; //3 чекбокса соответствующие правилам
    [SerializeField]
    private GameObject StartScreen; //объект стартового покрытия
    public void BTN_StartPress()
    {
        bool tmp = false;
        for (int i = 0; i < 3; i++)
        {
            tmp=tmp||rulesToggle[i].isOn;
            DeRules.ActiveRulles[i] = rulesToggle[i].isOn;
        }
        if (!tmp) { DeRules.ActiveRulles[0] = true; }
        StartScreen.SetActive(false);
    }
}
