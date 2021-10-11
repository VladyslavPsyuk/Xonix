using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spavner : MonoBehaviour
{
    public GameObject sectorSelector;
    public int sectorSelectorCount;
    public bool isInside;
    public bool algoOn;

    public int selectorInRowCount;
    // Start is called before the first frame update
    //instantiate spavner at min position
    void Start()
    {
        isInside = false;
        algoOn = false;
        sectorSelectorCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("f"))
        //{
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z), 10000f);
            if (transform.position.x > 30) // set max figure position
            {
                transform.position = new Vector3(0, 0.5f, transform.localPosition.z + 1f);
                selectorInRowCount = 0;
                isInside = false;
                algoOn = false;
            }
            if (transform.position.z > 30)
            {
                transform.position = new Vector3(0, 0.5f, 0);
            }
            ChecPosition();
        //}
    }
  
    public void ChecPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.localPosition, new Vector3(0f, -1f, 0f), out hit, 10f))
        {
            Debug.Log("You hit " + hit.transform.name +  "by spavner");
         
            //if (hit.transform.name == "Cell(Clone)" && isInside == false)
            //{
               

            //}
           
            if (hit.transform.name == "Selector(Clone)" && isInside == false)
            {
                selectorInRowCount++;
                isInside = true;
            }

            if (hit.transform.name == "Selector(Clone)" && selectorInRowCount % 2 == 0)
            {
                algoOn = false;
            }
            if (hit.transform.name == "Cell(Clone)" && isInside == true)
            {
                Instantiate(sectorSelector, new Vector3(hit.transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
                algoOn = true;
            }

            if (hit.transform.name == "Selector(Clone)" && isInside == true && algoOn == true)
            {
                Debug.Log("Out");
                isInside = false;
                algoOn = false;
            }
            //if (hit.transform.name == "Cell(Clone)" && selectorInRowCount == 1 && algoOn == true)
            //{
            //    isInside = false;
            //    algoOn = false;
               
            //}

        }

    }
}
