using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// переменная в скриптах MoveEngine
// Выполнение движения и расчет его результатов
public class MakeAMove : MonoBehaviour
{
    public Rules rules; //скрипт выбранных правил
    [SerializeField]
    private Text TurnName = null;
    [SerializeField]
    private Text WinName;
    [SerializeField]
    private GameObject EndGamePanel; //объект панели конца игры
    public string[] Names =new string[] {"Player 1", "Player 2"};
    private GameObject SelectedPawn=null; //текущая выбранная пешка
    private Pawn SelectedPawnScript = null;
    private bool NowTurnBlack = false; //"Сейчас ходят черные" определяет чей ход

    //Выбор пешки. Запускается из Pawn.cs
    public void SelectPawn(GameObject pawn, Pawn Script)
    {
    //    Debug.Log($"Try selected {pawn}");
        SelectedPawn = pawn;
        SelectedPawnScript = Script;
//   Debug.Log($"Pawn was selected {SelectedPawn}");
    }
    //Проерка выбрана ли пешка
    public bool isPawnSelected()
    {
        return !(SelectedPawn==null);
    }
    //Движение пешки в указаную клетку соответствующую правилам. Запускается из FieldProperty.cs
    public void MovePawn(Transform MoveTo,int i, int j)
    {
        if (rules.RulesAgree(SelectedPawnScript.posi, SelectedPawnScript.posj,i,j)) { 
        SelectedPawn.transform.position = MoveTo.position;
        SelectedPawnScript.ILeaveTo(i,j);
        NowTurnBlack = !NowTurnBlack;
        TurnName.text = Names[Convert.ToInt32(NowTurnBlack)];
            //   SelectedPawnScript.posi = i;
            //   SelectedPawnScript.posj = j;
            rules.CheckWin();
        }
    }
    //Ходит ли сейчас хозяин выбранной пешки
    public bool HisTurn()
    {
        return (SelectedPawnScript.OwnerIsBlack==NowTurnBlack);
    }
    //Показать паель окончания игры и имя победителя
    public void ShowWin(int nameN)
    {
        EndGamePanel.SetActive(true);
        WinName.text = Names[nameN];
    }
}
