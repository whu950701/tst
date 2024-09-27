using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public float rotationSpeed = 200.0f;  // 旋转速度

    private GameObject currentItem;

    void Start()
    {
        enabled = false; // 初始状态下禁用旋转功能
    }

    void Update()
    {
        // 按住鼠标中键旋转物品
        if (Input.GetMouseButton(2))
        {
            RotateObject();
        }
    }

    void RotateObject()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, -horizontal, Space.World);
        transform.Rotate(Vector3.right, vertical, Space.World);
    }
}