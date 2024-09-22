using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float tdset = 3f;
    private float initialtdset;

    // Start is called before the first frame update
    void Start()
    {
        initialtdset = tdset;
    }

    // Update is called once per frame
    void Update()
    {
        tdset -= Time.deltaTime;
        if(tdset <= 0){
            gameObject.SetActive(false);
            tdset = initialtdset;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Bullet"))
            tdset = initialtdset;
    }
}
