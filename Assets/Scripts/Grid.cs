using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int width;
    public int hight;
    private float cellSize;
    private int [,] gridArray;
    GameObject Cell;
    public List<GameObject> CellList = new List<GameObject>();

    public Grid ( int width, int hight, GameObject Cell)
    {
        this.width = width;
        this.hight = hight;

        gridArray = new int[width, hight];
        

        for (int xi=0; xi<gridArray.GetLength(0);xi++)
        {
            for (int zi = 0; zi < gridArray.GetLength(1); zi++)
            {
                CellList.Add(Instantiate(Cell, new Vector3(Cell.transform.position.x+xi, Cell.transform.position.y, Cell.transform.position.z+zi ), Quaternion.identity));

                //CellList[xi+zi].GetComponent<Cell>().cellCoordinat_i = xi;
                //CellList[xi+zi].GetComponent<Cell>().cellCoordinat_j = zi;
                
               // Debug.Log(CellList[zi].GetComponent<Cell>().cellCoordinat_j);
            }
           
            //Debug.Log(CellList[xi].GetComponent<Cell>().cellCoordinat_i);
        }
      
        Debug.Log(CellList.Count);

    }


}
