using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject panel;
    public string dialogo;
    public Text caixaD;
    public float TempoDestroi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            panel.SetActive(true);
            caixaD.text = dialogo;
            StartCoroutine("timerD");
        }
    }

    public IEnumerator timerD()
    {
       
        yield return new WaitForSeconds(TempoDestroi);
        panel.SetActive(false);
        Destroy(this.gameObject);
    }
        
    
}
