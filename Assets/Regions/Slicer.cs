using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject tipPrefab;
    [SerializeField] private float minimalCuttingSpeed = 5f;

    public bool isCutting = false;

    private Vector2 lastTipPosition;
    private Vector2 currentTipPosition;
    private GameObject tip;
    private bool wasCutting = false;

    public Vector2 Direction => CurrentTipPosition - lastTipPosition;

    public Vector2 CurrentTipPosition => currentTipPosition;

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
                tip = Instantiate(tipPrefab, CurrentTipPosition, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Destroy(tip, 2f);
                tip = null;
            }
        }
    }


    void Update()
    {
        lastTipPosition = currentTipPosition;
        currentTipPosition = camera.ScreenToWorldPoint(Input.mousePosition);

        float pointerSpeed = (currentTipPosition - lastTipPosition).magnitude / Time.deltaTime;
        bool willCut = Input.GetMouseButton(0) && (pointerSpeed > minimalCuttingSpeed);
        IsCutting = (willCut || wasCutting);
        wasCutting = willCut;

        if (tip)
        {
            tip.transform.position = currentTipPosition;
        }
    }
}
