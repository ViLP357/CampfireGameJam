using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    public int roskatMukana = 0;
    public int roskatRoskiksessa = 0;
    public static GameController instanssi;

    public Transform[] roskaPaikat;
    public GameObject muovipussi;
    public GameObject vesipullo;
    public TMP_Text pisteTeksti; 
    public GameObject alkuvalikko;
    void Awake()
    {
        instanssi = this;
    }
    void Start()
    {   
        Time.timeScale = 0;
        alkuvalikko.SetActive(true);
        //Random random = new Random();
        for (int i = 0; i < roskaPaikat.Length; i++) {
            Transform kohta = roskaPaikat[i];
            
            int n = Random.Range(0,2); //0-1
            if (n==0) {
                Instantiate(muovipussi, kohta.position, kohta.rotation);
                Debug.Log("muovipussi lisätty");
            } else if(n==1)
            {   
                Instantiate(vesipullo, kohta.position, kohta.rotation);
                Debug.Log("vesipullo lisätty");
            }
            //Instantiate(stopPlace, kohta.position, kohta.rotation);
        }   
    }
    void Update()
    {
        //Debug.Log("mukana " + roskatMukana);
        pisteTeksti.text = "Kerätyt roskat " + roskatRoskiksessa;
    }
    public void aloitaPeli()
    {
        Time.timeScale = 1;
        alkuvalikko.SetActive(false);

    }
}