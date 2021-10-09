using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//отвечает за отдельно взятую клетку
public class FieldProperty : MonoBehaviour
{
    public int posi;
    public int posj;
    public Transform mask;    
    public MakeField FieldEngine;
    [SerializeField]
    private MakeAMove MoveEngine;

    public void SetMoveEngine(MakeAMove engine)
    {
        MoveEngine = engine;
        //  Debug.Log($"Engine was set {MoveEngine}");
    }

    //подсветка клетки
    void OnMouseEnter()
    {
        mask.position = this.transform.position;
    }
    //нажатие на поле. Отвечает за ход пешки на незанятое поле
    void OnMouseDown()
    {
     //   Debug.Log("Try To Move");
        if ((MoveEngine.isPawnSelected())&&(FieldEngine.ThisFieldEmpty(posi,posj))&&(MoveEngine.HisTurn()))
        {

            MoveEngine.MovePawn(transform,posi,posj);

        }
    }
}
