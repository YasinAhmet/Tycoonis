using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDrag : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        canvas = transform.parent.parent.GetComponent<Canvas>();
    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,
            pointerData.position, canvas.worldCamera, out position);

        transform.position = canvas.transform.TransformPoint(position);
    }
}
