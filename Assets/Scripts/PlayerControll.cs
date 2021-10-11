using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{

    //public GameObject Player;
    public GameObject sectorSelector;
    public GameObject Spavner;

    public List<GameObject> selectorList = new List<GameObject>();
    public bool isOpen;

    public int scoreToWin;
    public Text score;

    public int sectorSelectorCount;
    public float movementSpeed = 5f;
    public float playerDistanceToMove =1f;
    Vector3 prevPos;


    void OnEnable()
    {
        scoreToWin = PlayerPrefs.GetInt("score");
    }
    // Start is called before the first frame update
    void Start()
    {
       
       isOpen = true;
       Player.playerLives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = sectorSelectorCount.ToString();
        Vector3 movementDirection = (transform.position - prevPos).normalized;
        if (Input.GetKey("a"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(this.transform.position.x - playerDistanceToMove, this.transform.position.y, this.transform.position.z ), Time.deltaTime * movementSpeed);
           // transform.rotation = Quaternion.LookRotation(movementDirection.normalized);
        }
        if (Input.GetKey("w"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + playerDistanceToMove), Time.deltaTime * movementSpeed);
            //transform.rotation = Quaternion.LookRotation(movementDirection.normalized);
        }
        if (Input.GetKey("s"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - playerDistanceToMove), Time.deltaTime * movementSpeed);
            //transform.rotation = Quaternion.LookRotation(movementDirection.normalized);
        }
        if (Input.GetKey("d"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(this.transform.position.x + playerDistanceToMove, this.transform.position.y, this.transform.position.z ), Time.deltaTime * movementSpeed);
            //transform.rotation = Quaternion.LookRotation(movementDirection.normalized);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 50), transform.position.y, Mathf.Clamp(transform.position.z, 0, 50));

        if(isOpen == false)
        {
           // CreateSpavner();
        }

        ChecPosition();
        prevPos = transform.position;

        if (sectorSelectorCount == scoreToWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        if (Player.playerLives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void ChecPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.localPosition, new Vector3(0f, -1f, 0f), out hit, 10f))
        {
            // Debug.Log("You hit " + hit.transform.name);
            if (hit.transform.name == "Cell(Clone)")
            {
                selectorList.Add(Instantiate(sectorSelector, new Vector3(hit.transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity));
                isOpen = true;
                sectorSelectorCount++;
                Debug.Log("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                Debug.Log(sectorSelectorCount);
            }
            if (hit.transform.name == "Selector(Clone)" || hit.transform.name == "Wall(Clone)")
            {
                isOpen = false;
                Debug.Log("---------------------------------------------------");
            }

        }
    }

    public void CreateSpavner ()
    {
        List<GameObject> sorted = selectorList.OrderBy(x => x.transform.position.z).ToList();
        var firstPosition = sorted.First();
        var lastPosition = sorted.Last();
        Instantiate(Spavner, new Vector3(0, 0, firstPosition.transform.position.z), Quaternion.identity);

        if (Spavner.transform.position.z < lastPosition.transform.position.z)
        {
            Destroy(Spavner);
        }
        sorted.Clear();
        selectorList.Clear();
    }
   
    //void chekChain(List<GameObject> chainList)
    //{
    //    foreach (GameObject ch in chainList)
    //    if(chainList[0]==)
    //        {
    //            isClose = true;
    //        }

    //}


}
