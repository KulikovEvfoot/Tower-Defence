using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Common
{
    public static class TweenExtensions
    {
        public static TweenerCore<float, float, FloatOptions> DOMoveInTarget(this Transform transform, Transform target, float duration)
        {
            float currentProgress = 0;
            var startPosition = Vector3.zero;
    
            var t = DOTween.To(
                () => currentProgress,
                x => currentProgress = x,
                1f, 
                duration);
            t.OnStart(() => startPosition = transform.position);
            t.SetTarget(transform);
            t.OnUpdate(() =>
            {
                transform.position =
                    Vector3.Lerp(startPosition, target.position, currentProgress);
            });
    
            return t;
        }

    }
}