using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uiSitema : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool permitir;
    GameObject grids;

    void Start()
    {
        grids = Camera.main.gameObject;
        permitir = true;

    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        grids.GetComponent<grid>().permitir = false;
        permitir = false;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        grids.GetComponent<grid>().permitir = true;
        permitir = true;

    }

}
