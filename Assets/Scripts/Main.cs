using UnityEngine;

public class Main : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject capsule = PoolManager.Instance.RequestCapsule();
            capsule.transform.position = Vector3.zero;
        }
    }
}
