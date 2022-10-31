# Essential Utils For Unity

⚠️ Early version, not for production use ⚠️

A library of utility classes for Unity. It's meant to fill in some gaps in Unity API and make it easier to work in action-based workflow. It was originally inspired by Unity Visual Scripting and programming style that it facilitates.

## Some usage examples:

Some basic examples to show how the library works:

### Example 1

Using `ChildActivator`, `Timer`, `ValueAnimator` and `IActivatable` to sequentially show game objects with some interval:

```csharp
using UnityEngine;
using EssentialUtils;

public class ActivationTest : MonoBehaviour
{
    void Start()
    {
        var childActivator = new ChildActivator(
            gameObject,
            activationMethod: ActivationMethod.IActivatable
        );

        var timer = new Timer(
            duration: 1.5f,
            loop: true,
            onFinished: childActivator.ActionNext
        );

        timer.Start();
    }
}
```

```csharp
using UnityEngine;
using EssentialUtils;

public class ActivatableTest : MonoBehaviour, IActivatable
{
    ValueAnimatorFloat valueAnimator;

    void Awake()
    {
        valueAnimator = new(duration: .5f);
        valueAnimator.OnUpdate += () => transform.SetUniformScale(valueAnimator.Value);
    }

    public void Activate() => valueAnimator.Play();
    public void Deactivate() => valueAnimator.Reverse();
}
```

### Example 2

Using `VisibilityWatcher`, `TransitionLerpFloat`, `MapRange` and `SetUniformScale` to show interaction hints:

```csharp
using UnityEngine;
using EssentialUtils;
using TMPro;

public class TargetTest : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] AnimationCurve curve;

    TMP_Text text;

    void Start()
    {
        var vw = new VisibilityWatcher(target);
        var transition = new TransitionLerpFloat(speed: 1f);
        text = GetComponent<TMP_Text>();

        this.OnUpdate(() => {
            text.alpha = curve.Evaluate(transition.Run(vw.IsClose && vw.IsVisible ? 1f : 0f));
            transform.SetUniformScale(Math.MapRange(vw.CurrentDistance, 5f, 1f, .5f, 1f));
        });
    }
}
```

### Example 3

Using `WatcherBoolean` to watch rotation angle enter/exit certain range:

```csharp
using UnityEngine;
using EssentialUtils;

public class InteractableValve : MonoBehaviour
{
    WatcherBoolean rangeWatcher = new (
        onBecameTrue: () => Debug.Log("Angle entered the range"),
        onBecameFalse: () => Debug.Log("Angle left the range")
    );

    public void OnPlayerInteractMove((RaycastHit hit, Vector2 delta, Vector2 totalDelta) data)
    {
        transform.Rotate(new Vector3(data.delta.x * -10, 0, 0));
        rangeWatcher.Run(transform.rotation.eulerAngles.x is > 50f and < 100f);
    }
}
```