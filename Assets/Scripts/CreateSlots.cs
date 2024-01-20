using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlots : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject[] firstPos;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {

        for (int i = 0; i < 4; i++)
        {
            float xOffset = 0f;
            for (int j = 0; j < 14; j++)
            {
                GameObject newSlot = Instantiate(slotPrefab, new Vector3(firstPos[i].transform.position.x + xOffset, firstPos[i].transform.position.y, firstPos[i].transform.position.z), Quaternion.identity, firstPos[i].transform);
                newSlot.name = i.ToString() + " " + j.ToString();

                xOffset = xOffset + 1.5f;
            }
        }
    }
}
