﻿using System;
using UnityEngine;

namespace TouchScript.Layers {
    [ExecuteInEditMode()]
    public class LayerBase : MonoBehaviour {
        public String Name;

        public virtual HitResult Hit(TouchPoint touch, out RaycastHit hit, out Camera hitCamera) {
            hit = new RaycastHit();
            hitCamera = null;
            return HitResult.Miss;
        }

        protected virtual void Awake() {
            if (GetComponents<LayerBase>().Length > 1) {
                DestroyImmediate(this);
                return;
            }

            setName();
            TouchManager.AddLayer(this);
        }

        protected virtual void OnDestroy() {
            TouchManager.RemoveLayer(this);
        }

        protected virtual void setName() {
            if (String.IsNullOrEmpty(Name) && camera != null) Name = camera.name;
        }

    }

    public enum HitResult {
        Hit,
        Miss,
        Loss,
        Error
    }
}
