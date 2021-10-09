using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// набор правил и проверка на победу
public class Rules : MonoBehaviour
{
    public MakeField FieldEngine;
    public MakeAMove MoveEngine;
    public bool[] ActiveRulles=new bool[3];

    //проверка можно ли с текущими правилами попасть из одной клетки в другую
    public bool RulesAgree(int curi, int curj, int tari, int tarj)
    {
        
        bool tmp=(ActiveRulles[0]&&StepAside(curi, curj, tari, tarj))||(ActiveRulles[1]&&JumpAside( curi,  curj,  tari,  tarj))||(ActiveRulles[2] && JumpAcross(curi, curj, tari, tarj));
        Debug.Log($"Rulles: {tmp}");
        return tmp;
    }
//правило шага в любом направлении
    public bool StepAside(int curi,int curj,int tari,int tarj)
    {
        Debug.Log($"{Mathf.Abs(curi - tari) } {Mathf.Abs(curj - tarj)}");             
        bool tmp = ((Mathf.Abs(curi - tari) == 1) || (Mathf.Abs(curj - tarj) == 1))&&((Mathf.Abs(curi - tari) <= 1)&& (Mathf.Abs(curj - tarj) <= 1));
        Debug.Log($"Step aside {tmp}");
//        if ((Mathf.Abs(curi - tari) == 1) ^ (Mathf.Abs(curj - tarj) == 1)) {

//        }

        return tmp;
    }
//правило прыжка через фигуру по прямой
    public bool JumpAside(int curi, int curj, int tari, int tarj)
    {
     //   Debug.Log("try to Jump");
     //   Debug.Log($"pawn between {FieldEngine.Board[tari - (tari - curi) / 2, tarj - (tarj - curj) / 2].relatedPawn}");
        bool tmp = ((Mathf.Abs(curi - tari) == 2) ^ (Mathf.Abs(curj - tarj) == 2))&& (FieldEngine.Board[tari - (tari - curi) / 2,tarj - (tarj - curj) / 2].relatedPawn != null);
        Debug.Log($"Jump aside {tmp}");
        //        if ((Mathf.Abs(curi - tari) == 1) ^ (Mathf.Abs(curj - tarj) == 1)) {

        //        }

        return tmp;
    }
//правило прыжка через фигуру по диагонали
    public bool JumpAcross(int curi, int curj, int tari, int tarj)
    {
      //  Debug.Log("try to Jump");
      //  Debug.Log($"pawn between {FieldEngine.Board[tari - (tari - curi) / 2, tarj - (tarj - curj) / 2].relatedPawn}");
        bool tmp = ((Mathf.Abs(curi - tari) == 2) && (Mathf.Abs(curj - tarj) == 2)) && (FieldEngine.Board[tari - (tari - curi) / 2, tarj - (tarj - curj) / 2].relatedPawn != null);
        Debug.Log($"Jump across {tmp}");
        //        if ((Mathf.Abs(curi - tari) == 1) ^ (Mathf.Abs(curj - tarj) == 1)) {

        //        }

        return tmp;
    }
//проверка на победу
    public void CheckWin()
    {
        bool tmp = true;
        for (int i = 0; i < FieldEngine.pawni; i++)
        {
            for (int j = 0; j < FieldEngine.pawnj; j++)
            {
                tmp = tmp&& (FieldEngine.Board[i, j].relatedPawn!=null) && (FieldEngine.Board[i,j].PawnScript.OwnerIsBlack);
            }
        }
        if (tmp)
        {
            Debug.Log("BlackWin");
            MoveEngine.ShowWin(1);
        }
        tmp = true;
        for (int i = FieldEngine.endi- FieldEngine.pawni; i < FieldEngine.endi ; i++)
        {
            for (int j = FieldEngine.endj - FieldEngine.pawnj; j < FieldEngine.endj; j++)
            {
                tmp = tmp && (FieldEngine.Board[i, j].relatedPawn != null) && !(FieldEngine.Board[i, j].PawnScript.OwnerIsBlack);
                Debug.Log(tmp);
            }
        }
        if (tmp)
        {
            Debug.Log("WhiteWin");
            MoveEngine.ShowWin(0);
        }
    }

}
