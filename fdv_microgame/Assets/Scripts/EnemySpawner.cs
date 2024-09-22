/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimit;
    public float maxTimeLife = 4f;

    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time > spawnNext){
            spawnNext = Time.time + 60/spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xLimit, xLimit);
            Vector2 spawnPosition = new Vector2(rand,8f);
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            Destroy(meteor, maxTimeLife);

        }


    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimit;
    public float tdset = 4f;
    private float spawnNext = 0;


    // Update is called once per frame
    void Update()
    {
        
        if(Time.time > spawnNext){
            spawnNext = Time.time + 60/spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xLimit, xLimit);
            Vector2 spawnPosition = new Vector2(rand,8f);
            //GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            GameObject meteor = ObjectPool.SharedInstance.GetPooledObject("Enemy");
            if (meteor != null) {
                meteor.transform.position = spawnPosition;
                meteor.transform.rotation = Quaternion.identity;

                Rigidbody rb = meteor.GetComponent<Rigidbody>();
                if(rb!=null){
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
                meteor.SetActive(true);
                
            }
        }
    }
}

