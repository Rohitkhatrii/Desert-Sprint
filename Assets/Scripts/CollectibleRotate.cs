using UnityEngine;

public class CollectibleRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 2.5f;

    void Update()
    {
        transform.Rotate(0 , rotateSpeed ,0, Space.World);
    }
}
