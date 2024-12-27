using UnityEngine;

namespace Code.Common.Extensions
{
  public static class TransformExtensions
  {
    public static UnityEngine.Transform SetWorldXY(this UnityEngine.Transform transform, float x, float y)
    {
      transform.position = new Vector3(x, y, transform.position.z);
      return transform;
    }

    public static UnityEngine.Transform SetWorldX(this UnityEngine.Transform transform, float x)
    {
      transform.position = transform.position.SetX(x);
      return transform;
    }

    public static UnityEngine.Transform AddWorldX(this UnityEngine.Transform transform, float x)
    {
      transform.position = transform.position.AddX(x);
      return transform;
    }

    public static UnityEngine.Transform SetLocalX(this UnityEngine.Transform transform, float x)
    {
      transform.localPosition = transform.localPosition.SetX(x);
      return transform;
    }

    public static UnityEngine.Transform LocalScaleX(this UnityEngine.Transform transform, float x)
    {
      transform.localScale = transform.localScale.SetX(x);
      return transform;
    }
    
    public static UnityEngine.Transform LocalScaleY(this UnityEngine.Transform transform, float y)
    {
      transform.localScale = transform.localScale.SetY(y);
      return transform;
    }
    
    public static void SetScaleX(this UnityEngine.Transform t, float scale) =>
      t.localScale = new Vector3(scale, t.localScale.y, t.localScale.z);

    public static UnityEngine.Transform AddLocalX(this UnityEngine.Transform transform, float x)
    {
      transform.localPosition = transform.localPosition.AddX(x);
      return transform;
    }

    public static UnityEngine.Transform SetWorldY(this UnityEngine.Transform transform, float y)
    {
      transform.position = transform.position.SetY(y);
      return transform;
    }

    public static UnityEngine.Transform AddWorldY(this UnityEngine.Transform transform, float y)
    {
      transform.position = transform.position.AddY(y);
      return transform;
    }

    public static UnityEngine.Transform SetLocalY(this UnityEngine.Transform transform, float y)
    {
      transform.localPosition = transform.localPosition.SetY(y);
      return transform;
    }

    public static UnityEngine.Transform AddLocalY(this UnityEngine.Transform transform, float y)
    {
      transform.localPosition = transform.localPosition.AddX(y);
      return transform;
    }
  }
}