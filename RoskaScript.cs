using UnityEngine;

public class RoskaScript : MonoBehaviour
{
    private Transform player;
    private Vector3 offset = new Vector3(0, -0.5f , -3);
    public float followSpeed = 5f;

    public bool seuraa = false;
    public float rotationSpeed = 10f;  
    private float lisa = 0;
    public static RoskaScript instanssi;
    int op;
    //int op2;
    void Start()
    {
        instanssi = this;
        player = GameObject.FindWithTag("player").transform;
        //seuraa = true;
    }

    void LateUpdate()
    {
        if (player != null && seuraa)
        {

            offset = new Vector3(op, 1, -2-lisa);
            // 1. Liikutaan kohti offsetia pelaajan suhteen
            Vector3 targetPosition = player.position + (player.forward * offset.z) + (player.right * offset.x) + (Vector3.up * offset.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // 2. Käännytään samansuuntaiseksi kuin pelaaja
            transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotationSpeed * Time.deltaTime);
        }

    
    }
    public void seuraaPelaajaa()
    {
        seuraa = true;  
        //Debug.Log("Seurataan pian");
        lisa =  (float) (GameController.instanssi.roskatMukana*0.8);
            op = GameController.instanssi.roskatMukana%2;
            //op2 = GameController.instanssi.roskatMukana%2;
    }

    
}