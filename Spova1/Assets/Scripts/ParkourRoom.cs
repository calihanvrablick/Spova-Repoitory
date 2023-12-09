using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourRoom : MonoBehaviour
{

    public GameObject spikePrefab;

    // Start is called before the first frame update
    void Start()
    {
        int amountOfSpikes = Random.Range(7, 14);
        for (int i = 0; i < amountOfSpikes; i++)
        {
            GameObject thisSpike = Instantiate(spikePrefab);

            float xRange = transform.localScale.x / 3;
            float zRange = transform.localScale.z / 3;

            thisSpike.transform.localPosition = new Vector3(Random.Range(-xRange, xRange)+ transform.localPosition.x, .1f, Random.Range(-zRange, zRange)+ transform.localPosition.z);
            //thisSpike.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
