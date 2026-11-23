using UnityEngine;

public class ColorPlatform : MonoBehaviour
{
    public Renderer Platform;

    private void OnEnable()
    {
        Platform.material.color = Color.darkGreen;
    }
}
