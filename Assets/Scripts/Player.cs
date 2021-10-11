using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int playerCoordinat_x { get; set; }
    public static int playerCoordinat_y { get; set; }

    public static int playerScore;
    public static int playerLives;
    public static int playerTime;
    enum PlayerState
    {
        elive,
        dead
    }
 
}
