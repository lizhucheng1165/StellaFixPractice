using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorld : MonoBehaviour
{
    public GameObject sphere;
    LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    void Update()
    {
        SelectStar();
    }

    void SelectStar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hits;
            if (Physics.Raycast(ray, out hits))
            {
                if (hits.transform.name.Contains("Star"))
                {
                    line.positionCount += 1;
                    line.SetPosition(line.positionCount - 1, hits.transform.position);
                }
                else return;
            }
        }
    }

    
}
