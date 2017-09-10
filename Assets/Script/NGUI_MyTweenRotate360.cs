using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/360Rotation")]
public class NGUI_MyTweenRotate360 : TweenRotation
{
    protected override void OnUpdate(float factor, bool isFinished)
    {
        cachedTransform.localRotation = Quaternion.Euler(Vector3.Slerp(from, to, factor));
    }
}

