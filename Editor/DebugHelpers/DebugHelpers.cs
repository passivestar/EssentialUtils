using System;
using UnityEngine;
using UnityEditor;

namespace EssentialUtils
{
    public static class DebugHelpers
    {
        static Action onNextDrawGizmos;

        static DebugHelpers()
        {
            MonoBehaviourHelper.Instance.onDrawGizmos += () =>
            {
                onNextDrawGizmos?.Invoke();
                onNextDrawGizmos = null;
            };
        }

        public static void DrawText(Vector3 position, object text, Vector3 offset = new(), Color? color = null)
        {
            onNextDrawGizmos += () =>
            {
                color ??= Color.black;
                GUI.color = (Color)color;
                Handles.Label(position + offset, text.ToString());
            };
        }
    }
}