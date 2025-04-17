using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _exprosionVFX;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField, Range(6, 30)] private int _maxNewCubes = 6;
    [SerializeField, Range(2, 26)] private int _minNewCubes = 2;

    private const int MaxSpreadChance = 100;
    private const int ChanceDecreaseRatio = 2;
    private const int ScaleDecreaseRatio = 2;

    private void OnValidate()
    {
        if (_minNewCubes >= _maxNewCubes)
            _minNewCubes = _maxNewCubes - 1;
    }

    private Exploader _exploader = new Exploader();

    private void OnEnable() => _raycaster.OnRaycast += PerformExplosion;

    private void OnDisable() => _raycaster.OnRaycast -= PerformExplosion;

    private void PerformExplosion(GameObject cube)
    {
        Cube parentCubeHandler = cube.GetComponent<Cube>();
        int spreadChance = parentCubeHandler.SpreadChance;

        if (Random.Range(0, MaxSpreadChance) <= spreadChance)
        {
            for (int i = 0; i < Random.Range(_minNewCubes, _maxNewCubes); i++)
            {
                CreateCubes(cube, spreadChance);
            }
        }

        Destroy(cube);
    }

    private void CreateCubes(GameObject parent, int spreadChance)
    {
        Vector3 parentPosition = parent.transform.position;
        Vector3 parentScale = parent.transform.localScale;

        GameObject childCube = Instantiate(_cube, parentPosition, Quaternion.identity);

        Renderer renderer = childCube.GetComponent<Renderer>();
        Rigidbody rigidbody = childCube.GetComponent<Rigidbody>();
        Cube childCubeHandler = childCube.GetComponent<Cube>();

        childCubeHandler.SetChance(spreadChance / ChanceDecreaseRatio);
        childCubeHandler.SetScale(parentScale / ScaleDecreaseRatio);
        _exploader.SetRandomForce(rigidbody);
    }
}
