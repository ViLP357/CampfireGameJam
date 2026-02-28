using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    public Transform alkupaikka;

    private List<GameObject> roskat = new List<GameObject>();
    //GameController gameController;
    private float viimeRoska = 0;
    void Start()
    {
        //gameController = FindObjectOfType<GameController>();
        //GameController.instanssi.roskatMukana += 1;
        
        Debug.Log("Aloitetaan");
        transform.position = alkupaikka.transform.position;
        transform.rotation = alkupaikka.transform.rotation;
        
    }

    void Update()
    {
        // Liikkeen input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Liikettä vektori
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * turnSpeed);

            transform.rotation = Quaternion.Euler(0, angle, 0);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    
    {
        //Debug.Log("collsion");
        if (collision.transform.tag == "roska" && Time.time-viimeRoska > 0.5)
        {
            Debug.Log("Uusi roska");
            GameObject otherCollider = collision.gameObject;

            RoskaScript target = otherCollider.GetComponent<RoskaScript>();
            target.seuraaPelaajaa();
            GameController.instanssi.roskatMukana += 1;
            //Debug.Log("lisatty " + otherCollider.tag);
            roskat.Add(otherCollider);
            viimeRoska = Time.time;


        } else if (collision.transform.tag == "roskis")
            {
                //Debug.Log("Roskis");
                //GameController.instanssi.roskatRoskiksessa += GameController.instanssi.roskatMukana;
                GameController.instanssi.roskatMukana = 0;
                //Debug.Log("roskia " +roskat.le);
                foreach (GameObject g in roskat) 
                {
                    GameController.instanssi.roskatRoskiksessa+=1;
                    Destroy(g);
                }
                roskat =  new List<GameObject>();;
            }
            
    }
}