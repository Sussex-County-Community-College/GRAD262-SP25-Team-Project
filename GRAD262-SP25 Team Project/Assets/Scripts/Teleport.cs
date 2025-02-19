using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject pad1;
    public GameObject pad2;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D pad1)
    {
        player.transform.position = pad2.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
