using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KienNguUtilities
{
    public static TextMeshPro SpawnTextObject(string text, Vector3 position)
    {
        GameObject go = new GameObject("TextObject", typeof(TextMeshPro));
        Transform trans = go.transform;
        trans.position = position;
        TextMeshPro tmp = go.GetComponent<TextMeshPro>();
        tmp.fontSize = 2;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.text = text;
        return tmp;
    }
}
