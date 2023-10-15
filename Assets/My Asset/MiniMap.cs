using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Car;
    private Vector3 offset;
    void Start()
    {
        // Lưu vị trí ban đầu giữa A và B
        offset = transform.position - Car.transform.position;
    }
    // Start is called before the first frame update
    private void LateUpdate()
    {
        transform.position = Car.transform.position + offset;
        transform.LookAt(Car.transform.position);
    }
}
