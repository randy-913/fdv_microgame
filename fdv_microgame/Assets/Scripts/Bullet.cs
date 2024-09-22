using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    public GameObject frag_meteor;
    public float tdset = 3f;
    private float initialtdset;

    

    // Start is called before the first frame update
    void Start()
    {
        Collider colliderPlayer, colliderBullet;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        colliderPlayer = player.GetComponent<Collider>();
        colliderBullet = gameObject.GetComponent<Collider>();
        Physics.IgnoreCollision(colliderPlayer, colliderBullet);
        initialtdset = tdset;
    }

    // Update is called once per frame
    void Update()
    {
        tdset -= Time.deltaTime;
        transform.Translate(speed * targetVector * Time.deltaTime);
        if(tdset <= 0){
            gameObject.SetActive(false);
            tdset = initialtdset;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            float xcoord = Random.Range(1, 8);
            float prob_fragmentation = Random.Range(0, 11);
            Vector3 pos = collision.gameObject.transform.position;
            IncreaseScore();
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            if(prob_fragmentation > 5){
                pos.x = pos.x-1;
                GameObject meteor1 = ObjectPool.SharedInstance.GetPooledObject("Enemy_fr");
                activateMeteorFr(meteor1, pos, -xcoord);
                pos.x = pos.x+2;
                GameObject meteor2 = ObjectPool.SharedInstance.GetPooledObject("Enemy_fr");
                activateMeteorFr(meteor2, pos, xcoord);
            }
        }
        else if(collision.gameObject.CompareTag("Enemy_fr")){
            IncreaseScore();
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    private void activateMeteorFr(GameObject meteor_fr, Vector3 pos, float xcoord){
            if (meteor_fr != null) {
                meteor_fr.transform.position = pos;
                meteor_fr.transform.rotation = Quaternion.identity;

                Rigidbody rb = meteor_fr.GetComponent<Rigidbody>();
                if(rb!=null){
                    rb.velocity = Vector3.zero;
                    rb.velocity = new Vector3(xcoord,-7,0);
                    rb.angularVelocity = Vector3.zero;
                }
                meteor_fr.SetActive(true);
            }
    }

    private void IncreaseScore(){
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText(){
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }


}
