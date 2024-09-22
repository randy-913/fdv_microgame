using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public Dictionary<string, List<GameObject>> pooledObjects; //listas para cada objeto
    public List<GameObject> objectsToPool; //los objetos a los que se les va a implementar esta tecnica
    public List<int> amountsToPool; //cantidades para cada prefab

    void Awake()
    {
        SharedInstance = this;
        pooledObjects = new Dictionary<string, List<GameObject>>();
    }

    void Start()
    {

        for(int i=0; i<objectsToPool.Count; i++){
            List<GameObject> t_pool = new List<GameObject>();
            GameObject tmp;
            for(int j=0; j< amountsToPool[i]; j++){
                tmp = Instantiate(objectsToPool[i]);
                tmp.SetActive(false);
                t_pool.Add(tmp);
            }
            pooledObjects.Add(objectsToPool[i].tag, t_pool);
        }
       
    }

    public GameObject GetPooledObject(string object_tag){
        if(pooledObjects.ContainsKey(object_tag)){
           List<GameObject> t_pool = pooledObjects[object_tag];
           for(int i=0; i<t_pool.Count; i++){
                if(!t_pool[i].activeInHierarchy){
                    return t_pool[i];
                }
        
           }
        }
        return null;
    }
    
}
