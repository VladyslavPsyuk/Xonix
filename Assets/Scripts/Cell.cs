using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int cellCoordinat_i;
    public int cellCoordinat_j;

    public int cellNumber;

    public GameObject CellPrefub;

    public static int cellValue { get; set; }
    public enum Type
    {
        free,
        full
    }

    public void changeState ()
    {

    }
}
