using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class listaFicha : MonoBehaviour, IPointerDownHandler
{

    public GameObject painelPlayer, painelMonstro, exemplo, painelB, ficha, clone;
    public GameObject[] fichas;
    [SerializeField] int cont, id;

    private RectTransform primeiro;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "botaoFicha(Clone)")
        {
            if (clone == null)
            {
                clone = Instantiate(ficha, ficha.transform.position, ficha.transform.rotation);
                clone.transform.parent = ficha.transform.parent;
                clone.transform.localScale = ficha.transform.localScale;
                clone.SetActive(true);
            }
            else
            {
                clone.SetActive(true);
                primeiro = clone.GetComponent<RectTransform>();
                primeiro.SetAsLastSibling();
            }
        }

    }

    public void fechar()
    {

        if(painelPlayer.activeSelf == true)
        {
            painelPlayer.SetActive(false);
        }
        else
        {
            painelPlayer.SetActive(true);
        }
        
        painelPlayer.transform.position = new Vector3(798.2f, 437.8f, 0);
        painelPlayer.transform.Find("nome...").GetComponent<InputField>().text = "";

    }

    public void addMonstrol()
    {
        if (painelMonstro.activeSelf == true)
        {
            painelMonstro.SetActive(false);
        }
        else
        {
            painelMonstro.SetActive(true);
        }
        
        painelMonstro.transform.position = new Vector3(798.2f, 437.8f, 0);
    }

    public void criar()
    {


        cont++;
        fichas[cont] = Instantiate(fichas[0], exemplo.transform.position, exemplo.transform.rotation);
        fichas[cont].transform.parent = exemplo.transform.parent;
        fichas[cont].transform.localScale = new Vector3(1, 1, 1);
        fichas[cont].transform.Translate(0, (-70 * cont), 0);
        fichas[cont].transform.Find("Text").GetComponent<Text>().text = painelPlayer.transform.Find("nome...").GetComponent<InputField>().text;
        fichas[cont].GetComponent<listaFicha>().id = cont;
        fichas[cont].SetActive(true);
        fechar();
        
        
    }

    public void excluir(int contas)
    {
        Destroy(fichas[contas]);
        cont--;
        organizar(contas);
    }

    public void organizar(int contas)
    {
        if(contas != cont)
        {
            contas++;
            if(fichas[contas] != null)
            {
                fichas[contas].transform.Translate(0, (70 * cont), 0);
                organizar(contas);
            }
            
        }
        
    }

    public void ids()
    {
        painelB.GetComponent<listaFicha>().excluir(id);
        Destroy(clone);
        
    }

}
