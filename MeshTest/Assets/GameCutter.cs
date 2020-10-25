using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCutter : MonoBehaviour
{
    private Mesh mesh;
    Vector3 point1;
    Vector3 point2;
    int curpoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        //TEST CONCLUSION: IF A POINT IS ON THE SIDE OF THE PLANE THAT THE NORMAL IS POINTING TO, IT IS "LEFT" - RETURNS TRUE.
        //MESHCUTTER RETURNS CLONE WITH RIGHT MESH (FALSE SIDE - OPPOSITE OF PLANE'S NORMAL)
        /*
        Plane test = new Plane(new Vector3(0, 0, 1), new Vector3(0, 0, 0));
        Debug.Log("Is left? - (100, 100, 1): " + test.GetSide(new Vector3(100, 100, 1)));
        Debug.Log("Is left? - (-100, -100, -1): " + test.GetSide(new Vector3(-100, -100, -1)));
        */
    }

    private void OnMouseDown()
    {
        //get mouse position on object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mousePos = hit.point;

        //meshcut
        //Debug.Log("Point " + curpoints + 1 + ": " + hit.point.ToString());
        if (curpoints == 0)
        {
            point1 = mousePos;
            curpoints++;
        }
        else if (curpoints == 1)
        {
            point2 = mousePos;
            MeshCutter.MeshCutter.Cut(gameObject, MeshCutter.MeshCutter.createPlane(point1, point2, transform.up));
            //GameObject newObject = MeshCutter.MeshCutter.Cut(gameObject, point1, point2, transform.up);
            //newObject.transform.position += Vector3.up * 10f + Vector3.right;
            //newObject.transform.rotation = Quaternion.Euler(45, 0, 0);
            //transform.position += Vector3.up * 10f;
        }
    }

    private void OnMouseExit()
    {
        curpoints = 0;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.TransformPoint(mesh.bounds.center), 0.5f);
    }*/
}
