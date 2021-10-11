using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int selectedCellsCount;
    public int sectorCellsCount;
    public int cellsToWinCount;
    public GameObject BorderCell;
    public GameObject Cell;
    public GameObject Enemie;

    public AudioSource audioSource;

    public int size =30;

    public int gridWidth;
    public int griHight;
    public int enemiesCount;
  
    public List<GameObject> selectedArea = new List<GameObject>();

    public bool isInside;
    Grid grid;
    void OnEnable()
    {
        enemiesCount = PlayerPrefs.GetInt("count");
    }
    void Start()
    {
        audioSource.Play();
        size = gridWidth = griHight =30;
        grid = new Grid(size, size, Cell);
        GenerateBorders(size, size);
        SpawnEnemies(enemiesCount);
     
    }

    public void GenerateBorders (int width, int length)
    {
        int metric;

        for (int i = -width/2; i<= width/2; i++)
        { 
            for (int j = -length/2; j<= length/2; j++)
            {
                if(Mathf.Abs(i) == width/2 || Mathf.Abs(j)==length/2)
                {
                    Instantiate(BorderCell, new Vector3(i+ width / 2, 0, j+ length / 2), Quaternion.identity);
                        
                } 
            } 
        }
    }

    public void SpawnEnemies(int enemiesCount)
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            Instantiate(Enemie, RandomVector(1,49), Quaternion.identity);
        }
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = UnityEngine.Random.Range(min, max);
        var y = 0;
        var z = UnityEngine.Random.Range(min, max);

        return new Vector3(x, y, z);
    }

}
