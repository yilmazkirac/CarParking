using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araba : MonoBehaviour
{
    public bool Gitsinmi;
    public bool IlkEngelDurum;
    public Transform PlatformAna;
    public GameObject[] Trail;
    public GameManager _GameManager;
    public GameObject ParticalPoint;

    private void Start()
    {

    }
    private void Update()
    {
        if (!IlkEngelDurum)
        {
            transform.Translate(8 * Time.deltaTime * transform.right);
        }

        if (Gitsinmi)
        {
            transform.Translate(15 * Time.deltaTime * transform.right);
        }


    }
    void ArabaTeknikIslemleri()
    {
        Gitsinmi = false;
        Trail[0].SetActive(false);
        Trail[1].SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlatformDuvar"))
        {
            ArabaTeknikIslemleri();
            transform.SetParent(PlatformAna);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            _GameManager.ArabaAktifEt();
        }
        else if (collision.gameObject.CompareTag("Araba"))
        {
            _GameManager.CarpmaEfekti.transform.position = ParticalPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknikIslemleri();
            //   Destroy(gameObject);
            _GameManager.Kaybettin();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IlkEngel"))
        {
            IlkEngelDurum = true;
        }
        else if (other.CompareTag("Elmas"))
        {
            other.gameObject.SetActive(false);
            _GameManager.ElmasSayisi++;
            _GameManager.Seslerim[0].Play();
        }

        else if (other.CompareTag("Platform"))
        {
            _GameManager.CarpmaEfekti.transform.position = ParticalPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknikIslemleri();
            Destroy(gameObject);
            _GameManager.Kaybettin();
        }

        else if (other.CompareTag("OnDuvar"))
        {
            other.gameObject.GetComponent<OnParking>().ParkingAktiflestir();
        }
    }
}
