using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer)
    {
        var a = 1 << layer;
        var b = mask;
        var c = mask & (1 << layer);
        var d = (mask & (1 << layer)) != 0;
        return (mask & (1 << layer)) != 0;
    }
}
