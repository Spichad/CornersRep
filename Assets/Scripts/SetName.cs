using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//обработка полей ввода имени
public class SetName : MonoBehaviour
{
    [SerializeField]
    private MakeAMove MoveEngine;
    [SerializeField]
    private InputField ThisField;
    public void SetNameTo(int plnumber)
    {
        MoveEngine.Names[plnumber] =ThisField.text;
    } 
}
