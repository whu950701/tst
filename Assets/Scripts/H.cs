using UnityEngine;

public class H : MonoBehaviour
{
    public Camera playerCamera; // 玩家摄像机
    public float pickUpRange = 5.0f; // 可拾取范围
    public float holdDistance = 2.0f; // 持有物体的距离
    public float smoothFactor = 10.0f; // 平滑移动的因子
    private GameObject pickedObject = null; // 当前拾取的物体
    private Vector3 objectInitialOffset; // 初始偏移量

    void Update()
    {
        // 当鼠标左键按下时拾取物体
        if (Input.GetMouseButtonDown(0))
        {
            TryPickUpObject();
        }

        // 当鼠标左键释放时放下物体
        if (Input.GetMouseButtonUp(0))
        {
            DropObject();
        }

        // 更新持有物体的位置
        if (pickedObject != null)
        {
            MoveObjectWithMouse();
        }
    }

    private void TryPickUpObject()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                pickedObject = hit.collider.gameObject;
                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.freezeRotation = true;
                objectInitialOffset = hit.point - pickedObject.transform.position;
            }
        }
    }

    private void DropObject()
    {
        if (pickedObject != null)
        {
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.freezeRotation = false;
            pickedObject = null;
        }
    }

    private void MoveObjectWithMouse()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPosition = ray.origin + ray.direction * holdDistance;
        pickedObject.transform.position = Vector3.Lerp(pickedObject.transform.position,
            targetPosition - objectInitialOffset, Time.deltaTime * smoothFactor);
    }
}