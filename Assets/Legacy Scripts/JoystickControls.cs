using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickControls : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform rectTransform;

    [SerializeField]
    float dragThreshold = 0.6f;
    [SerializeField]
    int dragMovementDistance = 80;
    [SerializeField]
    int dragOffsetDistance = 100;

    public event Action<Vector2> OnMove;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, null, out offset);

		offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
		Debug.Log(offset);
		rectTransform.anchoredPosition = offset * dragMovementDistance;

        Vector2 inputVector = CalculateMovementInput(offset);
        OnMove?.Invoke(inputVector);
	}

    private Vector2 CalculateMovementInput(Vector2 offset)
    {
        float x = MathF.Abs(offset.x) > dragThreshold ? offset.x : 0;
		float y = MathF.Abs(offset.y) > dragThreshold ? offset.y : 0;
        return new Vector2(x, y);
	}

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = Vector2.zero;
        OnMove?.Invoke(Vector2.zero);
    }

    void Awake()
    {
        rectTransform = (RectTransform)transform;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
