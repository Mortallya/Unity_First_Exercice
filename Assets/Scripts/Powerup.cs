using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    public void Pickup(){
        //cacher, désactiver l'objet
        Debug.Log("+1");
        GetComponent<AudioSource>().Play();

        GetComponent<BoxCollider>().enabled = false;
        transform.Find("Visual").gameObject.SetActive(false);
        Invoke("DestroyPowerUp", 1f);

        gameManager.AddScore();    
        }
    
    private void DestroyPowerUp(){
        Destroy(gameObject);
    }
}
