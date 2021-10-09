using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Скрипт отвечает за обработку отдельной пешки
*/
public class Pawn : MonoBehaviour
{
    public bool OwnerIsBlack=false;
    public int posi;
    public int posj;
    public Transform mask;
    [SerializeField]
    private MakeAMove MoveEngine;
    public MakeField FieldEngine;

    //Фикс странного бага: без этой функции 1 белая и 1 черная (нижняя правая белая и первая во втором ряду черная)
    //пешки перестает работать (колайдер не реагирует на функции)
    void Start()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }


    public void SetMoveEngine(MakeAMove engine)
    {
        MoveEngine = engine;
      //  Debug.Log($"Engine was set {MoveEngine}");
    }

    //подсветка клетки при наведении на пешку
    void OnMouseEnter()
    {
        mask.position = this.transform.position;
    }
    //выбор пешки по нажатию
    void OnMouseDown()
    {
        Debug.Log("try to select");
        MoveEngine.SelectPawn(this.gameObject,this);
    }
    //команда на изменение положение текущей пешки на доске
    public void ILeaveTo(int newi,int newj)
    {
        FieldEngine.Board[posi, posj].relatedPawn = null;
        FieldEngine.Board[posi, posj].PawnScript = null;
        FieldEngine.Board[newi, newj].relatedPawn = gameObject;
        FieldEngine.Board[newi, newj].PawnScript = this;
        posi = newi;
        posj = newj;
    }
}
