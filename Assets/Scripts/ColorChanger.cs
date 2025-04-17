using UnityEngine;

public class ColorChanger 
{
    public void Set(Renderer renderer)
    {
        renderer.material.color = Random.ColorHSV();
    }
}
