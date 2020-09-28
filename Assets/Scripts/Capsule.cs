using System.Collections;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private Transform _transform;

    [SerializeField]  
    [Range(1,5)]
    private float speed;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (isActiveAndEnabled)
                _transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void OnEnable()
    {
        StartCoroutine(DisableRoutine());
    }
    private IEnumerator DisableRoutine()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
