﻿using UnityEngine;

namespace _project.Sources.Extensions
{
    public static class TransformExtensions
    {
        public static Transform AttachToParent(this Transform transform, Transform parent)
        {
            transform.parent = parent;

            return transform;
        }
    }
}