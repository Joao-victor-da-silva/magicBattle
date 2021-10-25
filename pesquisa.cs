using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
//using System.Linq;

public class pesquisa : MonoBehaviour
{
    public GameObject barra, temp;
    public List<GameObject> filho, pai, avo;
    public int mais, menos;
    public bool teste = false;
    public int cont, cont02;
    public string convertido;

    private void Start()
    {
        for (int i = 0; i < filho.Count; i++)
        {
            pai[i] = filho[i].transform.parent.gameObject;
        }
    }


    private void Update()
    {

        convertido = barra.GetComponent<Text>().text.ToUpper(new CultureInfo("en-US", false));

        if (barra.GetComponent<Text>().text == "")
        {
            teste = true;
            if (teste == true)
            {
                teste = false;
                filtro02();
            }
        }
        else
        {
            teste = false;
        }
        
    }


    public void filtro()
    {
        if (barra.GetComponent<Text>().text != "")
        {
            for (int i = 0; i < filho.Count; i++)
            {
                cont = 0;
                pai[i].SetActive(false);
            }
        }
       
    }

    public  void filtro02()
    {
        if (cont == 0)
        {
            cont = 1;
            for (int i = 0; i < filho.Count; i++)
            {
                pai[i].SetActive(true);
                filho[i].SetActive(true);
                filho[i].gameObject.transform.parent = pai[i].transform;
                filho[i].gameObject.name = "bloco";
                if (i == filho.Count - 1)
                {
                    filtro03();
                }
            }
        }

    }

    public void filtro03()
    {
        for (int i = 0; i < avo.Count; i++)
        {
            if (avo[i].transform.Find("blocoIslot"))
            {
                avo[i].SetActive(true);
                if (avo[i].transform.Find("blocoIslot").gameObject.activeSelf == false)
                {
                    avo[i].SetActive(false);
                }
                
            }
            else
            {
                avo[i].SetActive(false);
            }
        }
    }


    public void pesquisando()
    {
        mais = 0;
        for (int i = 0; i < filho.Count; i++)
        {
            string convertidoTemp = filho[i].transform.Find("Text").GetComponent<Text>().text.ToUpper(new CultureInfo("en-US", false));
            if (string.IsNullOrEmpty(convertido) || convertidoTemp.Contains(convertido))
            {
                
               
                if (filho[i] == filho[mais])
                {
                    filho[mais].SetActive(true);
                    
                }
                else
                {
                   // filho[mais].SetActive(false);
                    if (temp != null)
                    {
                        temp.SetActive(true);
                    }
                   
                }


                //filho = filho.OrderBy(o => o.transform.Find("Text").GetComponent<Text>().text).ToList();
                //filho[mais] = filho[i];
                
                filho[i].gameObject.name = "blocoMovido";
               
                filho[i].gameObject.transform.parent = pai[mais++].transform;
                filho[i].gameObject.transform.parent.gameObject.SetActive(true);

                if (i != 0)
                {
                    temp = filho[i];
                }

            }
            if (pai[i])
            {
                if (pai[i].transform.Find("bloco"))
                {
                    pai[i].transform.Find("bloco").gameObject.SetActive(false);
                }
            }
           
            


            if (string.IsNullOrEmpty(barra.GetComponent<Text>().text))
            {
                filho[i].gameObject.transform.parent = pai[i].transform;
                filho[i].gameObject.name = "bloco";
                pai[i].SetActive(true);
            }

            if(i == filho.Count - 1)
            {
                filtro03();
            }

        }
    }


}
