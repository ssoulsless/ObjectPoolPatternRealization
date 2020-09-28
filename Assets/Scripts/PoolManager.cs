using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _capsulePrefab;

    [SerializeField]
    private GameObject _capsuleContainer;

    [SerializeField]
    [Range(10,20)]
    private int amountOfCapsuleToSpawn;

    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Pool Manager is NULL");
            return _instance;
        }
    }
    private List<GameObject> _capsuleBuffer = new List<GameObject>();
    private void Awake()
    {
        _instance = this;
        _capsuleBuffer = GenerateBullets(amountOfCapsuleToSpawn);
    }
    private List<GameObject> GenerateBullets(int amountOfBullets)
    {
        for (int i = 0; i < amountOfBullets; i++)
        {
            GameObject capsule = Instantiate(_capsulePrefab);
            capsule.transform.parent = _capsuleContainer.transform;
            _capsuleBuffer.Add(capsule);
            _capsuleBuffer.Add(capsule);
        }
        return _capsuleBuffer;
    }
    public GameObject RequestCapsule()
    {
        foreach (var caps in _capsuleBuffer)
        {
            if (!caps.activeInHierarchy)
            {
                caps.SetActive(true);
                return caps;
            }
        }
        GameObject capsule = Instantiate(_capsulePrefab);
        capsule.transform.parent = _capsuleContainer.transform;
        _capsuleBuffer.Add(capsule);
        return capsule;
    }
}
