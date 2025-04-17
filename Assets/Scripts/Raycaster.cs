using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public event Action<GameObject> OnRaycast;

    private void Update()
    {
        PerformClick();
    }

    private void PerformClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50f))
            {
                GameObject cube = hit.collider.gameObject;
                OnRaycast?.Invoke(cube);
            }
        }
    }
}
