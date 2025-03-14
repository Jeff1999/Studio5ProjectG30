using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    // Create a singleton instance for easy access
    public static CameraShake Instance;

    private void Awake()
    {
        // Set up singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Shake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

    // Static method for easier access
    public static void ShakeCamera(float duration, float strength)
    {
        if (Instance != null)
        {
            Instance.Shake(duration, strength);
        }
    }
}

