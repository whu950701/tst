using UnityEngine;

public class TouchImage : MonoBehaviour
{
    public GameObject targetObject; // 要顯示/隱藏的指定物件

    void OnMouseEnter()
    {
        targetObject.SetActive(true); // 顯示指定物件
    }

    void OnMouseExit()
    {
        targetObject.SetActive(false); // 隱藏指定物件
    }
}