using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//отвечает за все поле. Переменная в скриптах FieldEngine

public class MakeField : MonoBehaviour
{
    [SerializeField]
    private float step = 3f;
    //набор префабоф клеток и пешек
    [SerializeField]
    private GameObject WhiteField;
    [SerializeField]
    private GameObject BlackField;
    [SerializeField]
    private GameObject WhitePawn;
    [SerializeField]
    private GameObject BlackPawn;
    [SerializeField]
    private Transform Mask;
    //начальное положение поля
    [SerializeField]
    private Vector3 PosStart = new Vector3(-20f, 10f, 0);

public int endi = 8;
public int endj = 8;
public int pawni = 3;
public int pawnj = 3;

    [SerializeField]
    private MakeAMove MoveEngine;
    //поле как массив
    public oneField[,] Board= new oneField[8, 8];
    public class oneField
    {
       public GameObject relatedField=null;
       public GameObject relatedPawn=null;
       public FieldProperty FieldScript=null;
       public Pawn PawnScript = null;
    }
    


    void Awake()
    {
        
        MakeStartBoard();
    }
//создание доски и задание начального положения фигур
   private void MakeStartBoard()
    {

        bool isBlack = false;
        GameObject toSpawn = WhiteField;
        for (int i = 0; i < endi; i++)
        {
            for (int j = 0; j < endj; j++)
            {
                if (isBlack)
                {
                    toSpawn = BlackField;
                }
                else {
                    toSpawn = WhiteField;
                }
                GameObject tmp = Instantiate(toSpawn, new Vector3(PosStart.x + i * step, PosStart.y - j * step, 0), Quaternion.identity);
                Board[i, j] = new oneField();
                Board[i, j].relatedField = tmp;
                Board[i, j].FieldScript = Board[i, j].relatedField.GetComponent<FieldProperty>();
                Board[i, j].FieldScript.posi = i;
                Board[i, j].FieldScript.posj = j;
                Board[i, j].FieldScript.mask = Mask;
                Board[i, j].FieldScript.SetMoveEngine(MoveEngine);
                Board[i, j].FieldScript.FieldEngine = this;
                if ((i < pawni) && (j < pawnj))
                {
                    tmp = Instantiate(WhitePawn, new Vector3(PosStart.x + i * step, PosStart.y - j * step, 0), Quaternion.identity);
                    Board[i, j].relatedPawn = tmp;
                    Board[i, j].PawnScript = Board[i, j].relatedPawn.GetComponent<Pawn>();
                    Board[i, j].PawnScript.mask = Mask;
                    Board[i, j].PawnScript.posi = i;
                    Board[i, j].PawnScript.posj = j;
                    Board[i, j].PawnScript.SetMoveEngine(MoveEngine);
                    Board[i, j].PawnScript.FieldEngine = this;
                }
                if ((i > endi - pawni - 1) && (j > endj - pawnj - 1))
                {
                    tmp = Instantiate(BlackPawn, new Vector3(PosStart.x + i * step, PosStart.y - j * step, 0), Quaternion.identity);
                    Board[i, j].relatedPawn = tmp;
                    Board[i, j].PawnScript = Board[i, j].relatedPawn.GetComponent<Pawn>();
                    Board[i, j].PawnScript.OwnerIsBlack = true;
                    Board[i, j].PawnScript.mask = Mask;
                    Board[i, j].PawnScript.posi = i;
                    Board[i, j].PawnScript.posj = j;
                    Board[i, j].PawnScript.SetMoveEngine(MoveEngine);
                    Board[i, j].PawnScript.FieldEngine = this;
                }

                isBlack = !(isBlack);
            }
            isBlack = !(isBlack);
        }

    }
    //проверка пуста ли клетка с координатами 
    public bool ThisFieldEmpty (int i,int j)
    {
        bool tmp;
        tmp = (Board[i, j].relatedPawn == null);
        return tmp;
    }
}
