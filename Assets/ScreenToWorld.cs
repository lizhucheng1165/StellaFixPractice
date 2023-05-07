using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToWorld : MonoBehaviour
{
    public GameObject sphere;
    public LineRenderer mouseLine;
    LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }

    void Update()
    {
        SelectStar();
        GetMouseLine();
    }

    void SelectStar()
    {
        if (Input.GetMouseButtonUp(0))
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

    void GetMouseLine()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hits;
            if (Physics.Raycast(ray, out hits))
            {
                if (hits.transform.name.Contains("Star"))
                {
                    mouseLine.SetPosition(0, hits.transform.position);
                }
                else 
                {
                    mouseLine.SetPosition(1, hits.point);
                }

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hits;
            if (Physics.Raycast(ray, out hits))
            {
                if (hits.transform.name.Contains("Star"))
                {
                    mouseLine.SetPosition(0, hits.transform.position);
                }
                else
                {
                    mouseLine.SetPosition(1, mouseLine.GetPosition(0));
                }
            }
        }
    }
}
