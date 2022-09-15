using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial_1, tutorial_2, tutorial_3, tutorial_4;
    int textT;
    // Start is called before the first frame update
    void Start()
    {
        textT = 0;
        tutorial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            textT = textT + 1;
        }
    }
    void tutorial()
    {
        switch (textT)
        {
            case 1:
                print(textT);
                break;
            case 2:
                print(textT);
                break;

                
        }

    }
}
