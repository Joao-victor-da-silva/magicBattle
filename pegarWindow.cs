using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pegarWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{

    [SerializeField] private RectTransform pegarTransform;
    [SerializeField] private Canvas canvas;


    private void Awake()
    {
        if(pegarTransform == null){
            pegarTransform = transform.GetComponent<RectTransform>();
        }

        if(canvas == null)
        {
            Transform testCanvasTransform = transform.parent;
            while(testCanvasTransform != null)
            {
                canvas = testCanvasTransform.GetComponent<Canvas>();
                if(canvas != null)
                {
                    break;
                }
                testCanvasTransform = testCanvasTransform.parent;
            }
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        pegarTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pegarTransform.SetAsLastSibling();
    }


}
