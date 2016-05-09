using UnityEngine;
using System.Collections;
using System;

public class Spring_script : MonoBehaviour {

    private Vector3 currentPosition;
    private Vector3 screenPoint;
    private Vector3 offset;
    private float x_farst, y_farst; 

    void Start()
    {
        x_farst = this.transform.position.x;
        y_farst = this.transform.position.y;
        Console.WriteLine(x_farst);
        Console.WriteLine(y_farst);

    }

    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
     
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.localPosition = currentPosition;
    }

    void OnMouseUp()
    {
        float x = Input.mousePosition.x-x_farst;
        float y = Input.mousePosition.y-y_farst;
        calculation c = new calculation();
        float z = c.Norm(x, y);

        this.GetComponent<Rigidbody>().AddForce(z*new Vector3(-x,-y,0)*0.01f);
    }

    public class calculation
    {
        public float Norm(float x, float y)
        {
            float N = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
            return N;
        }

    }
}
