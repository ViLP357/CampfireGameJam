using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int roskatMukana = 0;
    public int roskatRoskiksessa = 0;
    public static GameController instanssi;

    public Transform[] roskaPaikat;
    public Transform[] timanttiPaikat;
    public GameObject muovipussi;
    public GameObject timantti;
    public GameObject vesipullo;
    public TMP_Text pisteTeksti; 
    public GameObject alkuvalikko;
    public GameObject kuolemavalikko;
    public GameObject voittovalikko;
    public TMP_Text aikaTeksti;
    public TMP_Text voittoaika;
    //private float aloitusaika;
    private float viimeAika;
    float viive = 0;
    bool voitto = false;
    void Awake()
    {
        instanssi = this;
    }
    void Start()
    {   
        Time.timeScale = 0;
        alkuvalikko.SetActive(true);
        kuolemavalikko.SetActive(false);
        voittovalikko.SetActive(false);
        
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
        for (int i =0; i<timanttiPaikat.Length;i++)
        {
            Transform kohta = timanttiPaikat[i];
            Instantiate(timantti, kohta.position, kohta.rotation);
        }
        ///aloitusaika = Time.time;
    }
    void Update()
    {
        //Debug.Log("mukana " + roskatMukana);
        //aikaTeksti.text = muunnaTekstiksi(Time.time-aloitusaika);
        pisteTeksti.text =  roskatRoskiksessa.ToString();
        
        if (Time.time-viive >= 1.0f && voitto == true)
        {
            Time.timeScale = 0;
            voittovalikko.SetActive(true);
        } 
        //Debug.Log(voitto + " " + (Time.time-viive).ToString() + " " +viive);

        int nykyinenAika = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        if (nykyinenAika != viimeAika) 
        {
            String muunnettuAika = muunnaTekstiksi(nykyinenAika);
            aikaTeksti.text = muunnettuAika;
           
            viimeAika = nykyinenAika;
        }
        if (roskatRoskiksessa >= roskaPaikat.Length && voitto == false)
        {
            Debug.Log("VOitetaan");
            voittoaika.text = aikaTeksti.text;
            viive = Time.time;
            voitto = true;
        }
    }
    public void aloitaPeli()
    {
        Time.timeScale = 1;
        alkuvalikko.SetActive(false);

    }

    private string muunnaTekstiksi(int aika) {
        int tunnit = aika / 3600;
        int minuutit = (aika % 3600) / 60;
        int sekunnit = aika % 60;
        if (tunnit > 0) 
            return string.Format("{0:D2}:{1:D2}:{2:D2}", tunnit, minuutit, sekunnit);
        return string.Format("{0:D2}:{1:D2}", minuutit, sekunnit);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void Kuolema()
    {
        Time.timeScale = 0;
        kuolemavalikko.SetActive(true);
    }
}