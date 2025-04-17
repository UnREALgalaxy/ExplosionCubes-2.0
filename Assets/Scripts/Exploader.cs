using UnityEngine;

public class Exploader
{
    private Vector3 _direction;
    private float _forceMagnitude = 25f;

    public void SetRandomForce(Rigidbody rigidbody)
    {
        _direction = Random.onUnitSphere;

        rigidbody.AddForce(_direction * _forceMagnitude, ForceMode.Impulse); 
    }
}
