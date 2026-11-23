using UnityEngine;

public class TreeColor : MonoBehaviour
{
    public Renderer TreeSphere;
    public Renderer TreeCylinder;

    private void OnEnable()
    {
        TreeSphere.material.color = Color.green;
        TreeCylinder.material.color = Color.sandyBrown;
    }
}
