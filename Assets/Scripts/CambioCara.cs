using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CambioCara : MonoBehaviour
{
    [SerializeField] private ARFaceManager managerCara;

    public List<Material> mascaras = new List<Material>();

    public List<Mesh> modelos = new List<Mesh>();

    private int indexMascara = 0;

    private int indexModelo = 0;

    // Start is called before the first frame update
    void Start()
    {
        managerCara = GetComponent<ARFaceManager>();   
    }

    public void cambioTextura()
    {
        foreach (ARFace cara in managerCara.trackables)
        {
            cara.GetComponent<MeshRenderer>().material = mascaras[indexMascara];
        }

        indexMascara++;

        if (indexMascara == mascaras.Count)
        {
            indexMascara = 0;
        }
    }

    public void cambioModelo()
    {
        foreach (ARFace cara in managerCara.trackables)
        {
            Mesh mesh = cara.GetComponent<MeshFilter>().mesh = modelos[indexModelo];
            Mesh mesh2 = Instantiate(mesh);
            GetComponent<MeshFilter>().mesh = mesh2;
        }

        indexModelo++;

        if (indexModelo == modelos.Count)
        {
            indexModelo = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
