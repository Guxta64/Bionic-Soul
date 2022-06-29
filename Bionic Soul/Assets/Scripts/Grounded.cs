using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private Player hero;
    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hero.SetGroundCheck(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hero.SetGroundCheck(false);
    }
}
