using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class spawnTokem : NetworkBehaviour
{

    [SerializeField] public GameObject[] tokens;
    GameObject id, menuCor;
    [SyncVar(hook = nameof(modelo))] public int idModelo;
    [SyncVar(hook = nameof(Cor))] public int idCor;
    [SerializeField] int chao, rola;
    [SyncVar] public int oi, io, sinCor;
    Material inicial;
    int cont, cont02, cont03;
    public GameObject filhos;
    Animator anim;
    string bucito;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        oi = 99999;
        chao = 0;
        if (io != 0)
        {
            oi = 1;
        }

        menuCor = GameObject.Find("menu");
        id = Camera.main.gameObject;

    }

    void animestado()
    {
        if (bucito == "cubo") return;

        anim.Play("cubo");

        bucito = "cubo";
    } 

    private void Update()
    {

        if (cont03 == 0)
        {
            cont03 = 1;
            animestado();
        }


        if(idCor != 0 && cont02 == 0 && isServer == false)
        {
            cont02 = 1;
            print("isServer: " + isServer);
            Cor(0, idCor);
        }

        if (gameObject.name != "Cube")
        {
            if (isServer == true)
            {
                sicronizarModelo(); //
                if (filhos != null)
                {
                    sincronizarCor();
                }

            }
        }

        

    }



    [Command]
    public void Valorid(int ids)
    {
        rola = 1;
        ids = id.GetComponent<trocarModelo>().modelo;
        this.idModelo = ids;
        print("carei cuzão");
        oi = id.GetComponent<trocarModelo>().modelo;
        io = 1;


        //idModelo = id.GetComponent<trocarModelo>().modelo;

    }

    [Command]
    public void pegarid()
    {
        filhos.GetComponent<trocarmaterial>().passarIdCor();
    }

    public void sincronizarCor()
    {


        if (filhos.activeSelf == true && cont == 0)
        {
            if (filhos.GetComponent<trocarmaterial>().filho != null)
            {
                cont = 1;
                inicial = filhos.GetComponent<trocarmaterial>().filho.GetComponent<Renderer>().material;
            }

        }

        if (gameObject.tag == "pesas" && filhos.activeSelf == true && inicial != null)
        {
            if (inicial != filhos.GetComponent<trocarmaterial>().filho.GetComponent<Renderer>().material)
            {
                sinCor = 1;
            }

        }

        if (sinCor != 0 && filhos.activeSelf == true && this.gameObject.tag == "pesas")
        {
            pegarid();
            filhos.GetComponent<trocarmaterial>().filho.GetComponent<Renderer>().material = menuCor.GetComponent<menu>().cor[idCor];
            //print("bbbbbb");
        }



        //////////////////////////
        /*
        if (tokens[idModelo].activeSelf == true && this.gameObject.tag == "pesas" && gameObject.name != "Cube")
        {
            tokens[idModelo].GetComponent<trocarmaterial>().filho.GetComponent<Renderer>().material = menuCor.GetComponent<menu>().cor[corDepois];
        }

        print("zzzzzz");
        */
    }
    public void sicronizarModelo()
    {



        if (rola == 0)
        {
            Valorid(idModelo); ///
        }

        if (oi != 99999 && chao == 0)
        {
            chao = 1;
            if (gameObject.name != "Cube")
            {
                if (filhos == null)
                {
                    Quaternion rotationAgora = this.gameObject.transform.rotation;
                    this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    filhos = Instantiate(tokens[idModelo], this.gameObject.transform.position + tokens[idModelo].transform.position, tokens[idModelo].transform.rotation);
                    filhos.transform.SetParent(this.gameObject.transform);
                    filhos.name = tokens[idModelo].name;
                    this.gameObject.transform.rotation = rotationAgora;
                }


                //tokens[idModelo].gameObject.SetActive(true);
            }
        }

        ///////////////////////////

        /*
        if (gameObject.name != "Cube")
        {
            tokens[ValorNovo].gameObject.SetActive(true);
        }
        print("zzzbbbb");
        */
    }


    public void Cor(int valorAntigo, int valornovo)
    {
        if (filhos != null)
        {
            if (sinCor != 0 && filhos.activeSelf == true && this.gameObject.tag == "pesas")
            {
                pegarid();
                filhos.GetComponent<trocarmaterial>().filho.GetComponent<Renderer>().material = menuCor.GetComponent<menu>().cor[valornovo];
                print("aaaaaaaaaaaa");
            }
        }
    }

    public void modelo(int valorAntigo, int valornovo)
    {
        if (filhos == null)
        {
            Quaternion rotationAgora = this.gameObject.transform.rotation;
            this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            filhos = Instantiate(tokens[idModelo], this.gameObject.transform.position + tokens[idModelo].transform.position, this.gameObject.transform.rotation);
            filhos.transform.SetParent(this.gameObject.transform);
            filhos.name = tokens[idModelo].name;
            this.gameObject.transform.rotation = rotationAgora;
        }
        
    }


}
