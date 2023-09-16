using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("--------DIGER AYARLAR")]
    



    [Header("--------ARABA AYARLARI")]
    public GameObject[] Arabalar;
    int ArabaAktifIndex=0;
    public int KacArabaOlsun;
    public Sprite YerlesenArac;



    public GameObject IlkEngel;
    public GameObject[] ArabaImage;




    [Header("--------PLATFORM AYARLARI")]
    public GameObject Platform;
    public float[] PlatformHiz;
    private void Start()
    {
        Arabalar[ArabaAktifIndex].SetActive(true);
        for (int i = 0; i < KacArabaOlsun; i++)
        {
            ArabaImage[i].SetActive(true);
        }
    }
    public void ArabaAktifEt()
    {
        IlkEngel.SetActive(true);
        if (KacArabaOlsun>ArabaAktifIndex)
        {
            Arabalar[ArabaAktifIndex].SetActive(true);
        }
        ArabaImage[ArabaAktifIndex - 1].GetComponent<Image>().sprite = YerlesenArac;


    }
private void Update()
    {
        Platform.transform.Rotate(new Vector3(0, 0, PlatformHiz[0]));


        if (Input.GetMouseButtonDown(0))
        {
            Arabalar[ArabaAktifIndex].GetComponent<Araba>().Gitsinmi = true;
            ArabaAktifIndex++;
        }

    }
}
