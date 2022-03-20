using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSphereRed : MonoBehaviour
{
    private bool isRed = false;

    public void MakeRed()
    {
        MeshRenderer sphereRenderer = gameObject.GetComponent<MeshRenderer>();
        if (isRed)
        {
            sphereRenderer.material.SetColor("_Color", Color.gray);
            isRed = false;
        }
        else
        {
            sphereRenderer.material.SetColor("_Color", Color.red);
            isRed = true;
        }
    }
}
