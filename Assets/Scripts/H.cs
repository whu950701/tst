/*using UnityEngine;

public class Draggable2: MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition; // 保存物件的初始位置

    public Camera cameraToUse; // 指定要使用的攝影機

    private void Start()
    {
        // 保存物件的初始位置
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        // 当鼠标按下时，记录物体与鼠标之间的偏移量
        offset = gameObject.transform.position - GetMouseWorldPosition();
        isDragging = true;
    }



    private void Update()
    {
        if (isDragging)
        {
            // 根据鼠标位置更新物体的位置
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // 获取鼠标在世界空间中的位置
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -cameraToUse.transform.position.z; // 使用指定的攝影機
        return cameraToUse.ScreenToWorldPoint(mousePosition);
    }
}*/
using UnityEngine;

public class FirstPersonPickUp : MonoBehaviour
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
        pickedObject.transform.position = Vector3.Lerp(pickedObject.transform.position, targetPosition - objectInitialOffset, Time.deltaTime * smoothFactor);
    }
}

