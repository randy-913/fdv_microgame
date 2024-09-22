using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public GameObject gun;

    public float xBorderLimit, yBorderLimit;
    private Rigidbody _rigid;

    public static int SCORE = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        var newPos = transform.position;
        if(newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit + 1;
        else if(newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit - 1;
        else if(newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit + 1;
        else if(newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit - 1;
        transform.position = newPos;

        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        Vector3 thrustDirection = transform.right;
        _rigid.AddForce(thrustDirection * thrust * thrustForce);
        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject("Bullet");
            if (bullet != null) {
                bullet.transform.position = gun.transform.position;
                bullet.SetActive(true);
            }
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy_fr")){
            SCORE=0;
            collision.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
