using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject tipPrefab;
    [SerializeField] private float minimalCuttingSpeed = 1f;

    public bool isCutting = false;

    private Vector2 lastPointerPosition;

    public bool IsCutting
    {
        get => isCutting;
        set
        {
            if (value == isCutting)
            {
                return;
            }

            isCutting = value;
            if (isCutting)
            {
                Vector2 pointer = camera.ScreenToWorldPoint(Input.mousePosition);
                tip = Instantiate(tipPrefab, pointer, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Destroy(tip, 2f);
                tip = null;
            }
        }
    }

    private GameObject tip;

    void Update()
    {
        Vector2 position = camera.ScreenToWorldPoint(Input.mousePosition);
        float pointerSpeed = (position - lastPointerPosition).magnitude / Time.deltaTime;
        IsCutting = (Input.GetMouseButton(0) && pointerSpeed > minimalCuttingSpeed);
        lastPointerPosition = position;

        if (tip)
        {
            tip.transform.position = position;
        }
    }
}
