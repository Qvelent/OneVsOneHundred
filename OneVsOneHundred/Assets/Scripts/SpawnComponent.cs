using UnityEngine;


public class SpawnComponent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _prefab;
    
    [ContextMenu("Spawn")]
    public void Spawn()
    {
        Instantiate(_prefab, _target.transform.position, _prefab.transform.rotation);
    }
}
