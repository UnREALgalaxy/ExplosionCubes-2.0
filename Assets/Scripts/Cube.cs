using UnityEngine;

public class Cube : MonoBehaviour
{
    private ColorChanger _colorChanger = new ColorChanger();

    public int SpreadChance { get; private set; } = 100;

    public void SetChance(int newChance)
    {
        SpreadChance = newChance;
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    private void Start()
    {
        _colorChanger.Set(GetComponent<Renderer>());
    }
}
