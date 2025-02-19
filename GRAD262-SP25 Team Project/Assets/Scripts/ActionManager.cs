using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public GameObject player;
    public float minDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Detected Enter");
            DoActions();
        }
    }

    private void DoActions()
    {
        Actionable[] actionables = GameObject.FindObjectsOfType<Actionable>();
        Debug.Log("Found " + actionables.Length + " Actionables");
        foreach (Actionable actionable in actionables)
        {
            float distance = Vector2.Distance(player.transform.position, actionable.transform.position);
            if(distance <= minDistance)
            {
                actionable.DoAction();
            }
        }
    }
}
