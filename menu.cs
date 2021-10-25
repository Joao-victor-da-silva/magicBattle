using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Mirror.Examples.Chat;

public class menu : MonoBehaviour
{

    [SerializeField] GameObject grid, painel, save01, menusave;
    [SerializeField] GameObject painel01, painel02, painel03, butao01, butao02, butao03;
    [SerializeField] bool seguir;
    [SerializeField] public Material[] cor;
    public GameObject pesaCor;
    //[SerializeField] int cont;
    [SerializeField] GameObject lus, cameraa;
    [SerializeField] Material material;
    [SerializeField] Color preto;
    [SerializeField] public InputField nome;
    [SerializeField] GameObject painelChatt, painelEditarr, nomeObi, combate, fichass, configuracoes;
    [SerializeField] float ok;
    [SerializeField] GameObject painelM, paineldice, painelConfig;
    [SerializeField] pegarCores cor01, cor02, cor03, cor04;
    [SerializeField] GameObject corzinha;

    // Start is called before the first frame update
    void Start()
    {
        painel.SetActive(false);
        seguir = true;
    }

    // Update is called once per frame
    void Update()
    {

        colores();

        ok = Input.GetAxisRaw("Submit");

        if (pesaCor != null)
        {
            iniciativas();
        }

        if (pesaCor != null && painel.activeSelf == false)
        {
            nome.text = pesaCor.transform.parent.GetComponent<trocarmaterial>().nickNeme;
        }


        if(grid.GetComponent<grid>().Hit.collider != null)
        {
            if (grid.GetComponent<grid>().Hit.collider.gameObject.name != "Cubo" &&
            grid.GetComponent<grid>().Hit.collider.gameObject.tag == "pesas")
            {
                if (grid.GetComponent<grid>().editar == false)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        seguir = false;
                        painel.SetActive(true);
                    }
                }
            }
        }
        
        if(painel.activeSelf == true)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) && nomeObi.GetComponent<uiSitema>().permitir == true)
            {
                painel.SetActive(false);
                seguir = true;
                trocarNome();
            }
        }


        if (seguir == true)
        {
            transform.position = Input.mousePosition;
        }
        if(pesaCor != null && grid.GetComponent<grid>().selecionado != null)
        {
            /*
                if (Input.GetKeyDown(KeyCode.C))
                {
                    trocarCor();
                }
            */
        }
        
        if(painelChatt.activeSelf == true && ok != 0)
        {
            painelM.GetComponent<ChatWindow>().OnSend();
        }

        if(pesaCor != null)
        {
            grid.GetComponent<LineRenderer>().material = pesaCor.GetComponent<Renderer>().material;
        }

    }

    public void trocarCor(int cont)
    {
        pesaCor.GetComponent<Renderer>().material = new Material(cor[cont]);
        grid.GetComponent<LineRenderer>().material = new Material(cor[cont]);
        pesaCor.transform.parent.GetComponent<trocarmaterial>().nome.color = cor[cont].color;
        pesaCor.transform.parent.GetComponent<trocarmaterial>().idCor = cont;
        /*
        cont++;
        if(cont == 12)
        {
            cont = 0;
        }
        */
    }

    public void luz()
    {
        if(pesaCor.transform.parent.GetComponent<trocarmaterial>().luz.activeSelf == false)
        {
            pesaCor.transform.parent.GetComponent<trocarmaterial>().luz.SetActive(true);
        }
        else
        {
            pesaCor.transform.parent.GetComponent<trocarmaterial>().luz.SetActive(false);
        }
        
    }

    public void noite()
    {
        if(lus.activeSelf == true)
        {
            lus.SetActive(false);
           
        }
        else
        {
            lus.SetActive(true);
           // RenderSettings.skybox = material;
        }
    }

    public void fundoo()
    {
        if(RenderSettings.skybox != null)
        {
            RenderSettings.skybox = null;
            RenderSettings.ambientIntensity = 0.1f;
            RenderSettings.ambientLight = preto;
        }
        else
        {
            RenderSettings.skybox = material;
            RenderSettings.ambientIntensity = 1;
        }
        
    }

    public void sair()
    {
        SceneManager.LoadScene(0);
    }

    public void save()
    {
        if(save01.activeSelf == true)
        {
            save01.SetActive(false);
        }
        else
        {
            save01.SetActive(true);
        }
        save01.transform.position = new Vector3(798.2f, 437.8f, 0);
    }

    public void menuSair()
    {
        if (menusave.activeSelf == true)
        {
            menusave.SetActive(false);
        }
        else
        {
            menusave.SetActive(true);
        }
        menusave.transform.position = new Vector3(798.2f, 437.8f, 0);
    }

    public void painelEditar()
    {
        fichass.SetActive(false);
        combate.SetActive(false);
        //painelChatt.SetActive(false);
        painelEditarr.SetActive(true);
        configuracoes.SetActive(false);
    }

    public void PainelChat()
    {
        fichass.SetActive(false);
        combate.SetActive(false);
        //painelChatt.SetActive(true);
        painelEditarr.SetActive(false);
        configuracoes.SetActive(false);
    }

    public void combat( )
    {
        combate.SetActive(true);
        painelEditarr.SetActive(false);
        //painelChatt.SetActive(false);
        fichass.SetActive(false);
        configuracoes.SetActive(false);
    }

    public void fichas()
    {
        fichass.SetActive(true);
        combate.SetActive(false);
        //painelChatt.SetActive(false);
        painelEditarr.SetActive(false);
        configuracoes.SetActive(false);
    }
    public void config()
    {
        configuracoes.SetActive(true);
        fichass.SetActive(false);
        combate.SetActive(false);
        //painelChatt.SetActive(false);
        painelEditarr.SetActive(false);
    }

    public void congifuration()
    {
        if (paineldice.activeSelf == true)
        {
            paineldice.SetActive(false);
            painelConfig.SetActive(true);
        }
        
    }
    public void congifuration02()
    {
        if(paineldice.activeSelf == false)
        {
            paineldice.SetActive(true);
            painelConfig.SetActive(false);
        }
    }

    public void iniciativas()
    {
        if(pesaCor.transform.parent.GetComponent<trocarmaterial>().combate == true)
        {
            painel.transform.Find("iniciativa").GetComponent<Button>().interactable = false;
        }
        else
        {
            painel.transform.Find("iniciativa").GetComponent<Button>().interactable = true;
        }
    }


    public void editar()
    {
        /*
        if (butao01.GetComponent<Button>().interactable == false)
        {
            butao01.GetComponent<Button>().interactable = true;
            butao02.GetComponent<Button>().interactable = true;
            butao03.GetComponent<Button>().interactable = true;
            painel01.SetActive(true);
        }
        */
    }


    public void celecionar()
    {
        /*
        butao01.GetComponent<Button>().interactable = false;
        butao02.GetComponent<Button>().interactable = false;
        butao03.GetComponent<Button>().interactable = false;
        painel01.SetActive(false);
        painel02.SetActive(false);
        painel03.SetActive(false);
        */
    }

    public void players()
    {

        if (painel01.activeSelf == false)
        {
            painel01.SetActive(true);
            painel02.SetActive(false);
            painel03.SetActive(false);
        }
    }
    public void inimigos()
    {

        if (painel02.activeSelf == false)
        {
            painel02.SetActive(true);
            painel01.SetActive(false);
            painel03.SetActive(false);
        }
    }
    public void grids()
    {

        if (painel03.activeSelf == false)
        {
            painel03.SetActive(true);
            painel02.SetActive(false);
            painel01.SetActive(false);
        }
    }

    public void trocarNome()
    {
        if(pesaCor.transform.parent.GetComponent<trocarmaterial>().nome.enabled == false)
        {
            pesaCor.transform.parent.GetComponent<trocarmaterial>().nome.enabled = true;
            pesaCor.transform.parent.GetComponent<trocarmaterial>().nickNeme = nome.text;
            pesaCor.transform.parent.GetComponent<trocarmaterial>().trocarNome();
        }
        else
        {
            pesaCor.transform.parent.GetComponent<trocarmaterial>().nickNeme = nome.text;
            pesaCor.transform.parent.GetComponent<trocarmaterial>().trocarNome();
        }
        
    }

    public void colores()
    {
        if (cor01.ligar == true && cor02.ligar == false && cor03.ligar == false && cor04.ligar == false)
        {
            corzinha.SetActive(true);
        }
        else if (cor01.ligar == false && cor02.ligar == true && cor03.ligar == false && cor04.ligar == false)
        {
            corzinha.SetActive(true);
        }
        else if (cor01.ligar == false && cor02.ligar == false && cor03.ligar == true && cor04.ligar == false)
        {
            corzinha.SetActive(true);
        }
        else if (cor01.ligar == false && cor02.ligar == false && cor03.ligar == false && cor04.ligar == true)
        {
            corzinha.SetActive(true);
        }
        else if (cor01.ligar == false && cor02.ligar == false && cor03.ligar == false && cor04.ligar == false)
        {
            corzinha.SetActive(false);
        }
    }


}
