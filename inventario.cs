using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventario : MonoBehaviour
{

    public GameObject mouseItem, pai, teste, pai02;

    public void DreagItem( GameObject item)
    {
        mouseItem = item;
        pai = item.transform.parent.gameObject;
        //mouseItem.transform.position = Input.mousePosition;
    }

    public void DropItem(GameObject item)
    {
        if (mouseItem != null)
        {
            Transform aux = mouseItem.transform.parent;
            mouseItem.transform.SetParent(item.transform.parent);
            item.transform.SetParent(aux);
            if (this.gameObject.name == "PanelIniciativas")
            {
                pai.GetComponent<iniciativa>().filho = pai.transform.Find("botaoFicha").gameObject;
            }
           
            
        }
    }
    
    public void acharFilho(GameObject item)
    {

        StartCoroutine(pais(item));

    }

    
    public IEnumerator pais(GameObject item)
    {
        yield return new WaitForSeconds(0.1f);
        item.transform.parent.GetComponent<iniciativa>().filho = item;
        pai02 = item.transform.parent.gameObject;
    }

}
