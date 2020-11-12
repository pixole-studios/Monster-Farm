using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBuilder : MonoBehaviour
{
    [SerializeField] private GameObject eyeColorObj;

    [SerializeField] private GameObject mainBodyEyeObj;
    
    // Sets materials to different parts of the eye
    // Eye color is set here, as are areas of the eye model that may need to match the monster body
    public void SetMaterials(Material bodyMat, Material eyeMat)
    {
        if (mainBodyEyeObj != null)
        {
            mainBodyEyeObj.GetComponent<MeshRenderer>().material = bodyMat;
        }
        eyeColorObj.GetComponent<MeshRenderer>().material = eyeMat;
    }
}