using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{

    public float wavesHeight = 7f;

    public float wavesFrequency = 7f;

    public float wavesSpeed = 4f;

    public Transform ocean;

    Material Water1;

    Texture2D wavesDisplacement;



    void Start()
    {
        SetVariables();
    }

    void SetVariables()
    {
        Water1 = ocean.GetComponent<Renderer>().sharedMaterial;
        wavesDisplacement = (Texture2D)Water1.GetTexture("_WavesDisplacement");
    }

    public float WaterHeightAtPosition(Vector3 position)
    {
        return ocean.position.y + wavesDisplacement.GetPixelBilinear(position.x * wavesFrequency / 100, position.z * wavesFrequency / 100 + Time.time * wavesSpeed / 100).g * wavesHeight / 100 * ocean.localScale.x;
    }
    void OnValidate()
    {
        if (!Water1)
            SetVariables();
        UpdateMaterial();
    }
    void UpdateMaterial()
    {
        Water1.SetFloat("_WavesFrequency", wavesFrequency / 100);
        Water1.SetFloat("_WavesSpeed", wavesSpeed / 100);
        Water1.SetFloat("_WavesHeight", wavesHeight / 100);
    }

}