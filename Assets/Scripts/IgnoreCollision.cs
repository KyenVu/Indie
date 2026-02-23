using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] private LayerMask layersToIgnore;

    void Awake()
    {
        IgnoreCollisionsWithLayers(layersToIgnore);
    }

    public void IgnoreCollisionsWithLayers(LayerMask layerMask, bool ignore = true)
    {
        int layerCount = 32; // Unity supports up to 32 layers
        int thisLayer = this.gameObject.layer;

        for (int i = 0; i < layerCount; i++)
        {
            if ((layerMask.value & (1 << i)) != 0)
                Physics2D.IgnoreLayerCollision(thisLayer, i, ignore);
        }
    }
}