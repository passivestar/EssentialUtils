using System;
using UnityEngine;

namespace EssentialUtils
{
    public static class MonoBehaviourExtensionsEditor
    {
        public static void DrawText(this MonoBehaviour monoBehaviour, object text = null, Vector3 offset = new(), Color? color = null)
        {
            color ??= Color.black;
            DebugHelpers.DrawText(monoBehaviour.gameObject.transform.position, text, offset, color);
        }
    }
}