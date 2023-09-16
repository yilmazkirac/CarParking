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
    private void OnCollisionEnter(Collision collision)
    {

           if (collision.gameObject.CompareTag("IlkEngel"))
        {
            IlkEngelDurum = true;
            _GameManager.IlkEngel.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("PlatformDuvar"))
        {
            transform.SetParent(PlatformAna);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Trail[0].SetActive(false);
            Trail[1].SetActive(false);
            Gitsinmi =false;
            _GameManager.ArabaAktifEt();
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Araba"))
        {
            Destroy(gameObject);
        }

        
    }
}
