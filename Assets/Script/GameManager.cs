using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("--------DIGER AYARLAR")]
    public int ElmasSayisi;
    public ParticleSystem CarpmaEfekti;
    public AudioSource[] Seslerim;
    bool DokunmaKilidi;


    [Header("--------ARABA AYARLARI")]
    public GameObject[] Arabalar;
    int ArabaAktifIndex = 0;
    public int KacArabaOlsun;
    int KalanAracSayisi;



    [Header("--------CANVAS AYARLAR")]
    public Sprite YerlesenArac;
    public GameObject[] ArabaImage;
    public TextMeshProUGUI[] Textler;
    public GameObject[] Panellerim;
    public GameObject[] Buttons;




    [Header("--------PLATFORM AYARLARI")]
    public GameObject Platform;
    public GameObject PlatformCember;
    bool DonusVarmi = true;
    public float[] PlatformHiz;


    private void Start()
    {
        DokunmaKilidi = true;

        VarsayilanDeggerleriKontrolEt();
        Arabalar[ArabaAktifIndex].SetActive(true);
        for (int i = 0; i < KacArabaOlsun; i++)
        {
            ArabaImage[i].SetActive(true);
        }

        KalanAracSayisi = KacArabaOlsun;
    }
    public void ArabaAktifEt()
    {

        KalanAracSayisi--;

        if (KacArabaOlsun > ArabaAktifIndex)
        {
            Arabalar[ArabaAktifIndex].SetActive(true);
        }
        else
        {
            Kazandin();
        }

        ArabaImage[ArabaAktifIndex - 1].GetComponent<Image>().sprite = YerlesenArac;
    }
    private void Update()
    {


        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (DokunmaKilidi)
                {
                    Panellerim[0].SetActive(false);
                    Panellerim[3].SetActive(true);
                    DokunmaKilidi = false;
                }
                else
                {

                    Arabalar[ArabaAktifIndex].GetComponent<Araba>().Gitsinmi = true;
                    ArabaAktifIndex++;
                }
            }
        }

        if (DonusVarmi)
        {
            Platform.transform.Rotate(new Vector3(0, 0, PlatformHiz[0]));
            if (PlatformCember != null)
                PlatformCember.transform.Rotate(new Vector3(0, 0, -PlatformHiz[1]));
        }
    }
    public void Kaybettin()
    {
        //  PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas") + ElmasSayisi);
        DonusVarmi = false;
        Textler[6].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[7].text = SceneManager.GetActiveScene().name;
        Textler[8].text = (KacArabaOlsun - KalanAracSayisi).ToString();
        Textler[9].text = ElmasSayisi.ToString();
        Seslerim[1].Play();
        Seslerim[3].Play();
        Panellerim[1].SetActive(true);
        Panellerim[3].SetActive(false);
        Invoke("KaybettinButonuCikar", 2f);


    }

    void KaybettinButonuCikar()
    {
        Buttons[0].SetActive(true);
    }
    void KazandinButonuCikar()
    {
        Buttons[1].SetActive(true);
    }
    public void IzleVeDevamEt()
    {

    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SonrakiLevel()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Kazandin()
    {
        PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas") + ElmasSayisi);
        Textler[2].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[3].text = SceneManager.GetActiveScene().name;
        Textler[4].text = (KacArabaOlsun - KalanAracSayisi).ToString();
        Textler[5].text = ElmasSayisi.ToString();
        Seslerim[2].Play();
        Panellerim[2].SetActive(true);
        Panellerim[3].SetActive(false);
        Invoke("KazandinButonuCikar", 2f);

    }
    void VarsayilanDeggerleriKontrolEt()
    {

        Textler[0].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[1].text = SceneManager.GetActiveScene().name;

    }
}
