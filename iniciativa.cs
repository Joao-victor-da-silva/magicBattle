using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iniciativa : MonoBehaviour
{

    public GameObject exemplo, painelB, menus, token, cameraFilha;
    public Button proximo, voltarndo;
    public Text titulo;
    public GameObject[] fichas;
    public int cont, id, vez;
    public bool combatendo;
    public Button dadoss;
    public int valorDosDados;

    [SerializeField] Color amarelo, normal;
    [SerializeField] public GameObject filho, pai;
    int conts;
    public Toggle botao;


    // Start is called before the first frame update
    void Start()
    {
        combatendo = true;
        if (this.gameObject.name == "iniciativaCreatura(Clone)")
        {
            filho = transform.Find("botaoFicha").gameObject;
        }
        if (this.gameObject.name == "botaoFicha")
        {
            pai = transform.parent.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {



        if (token == null && gameObject.name == "botaoFicha")
        {
            ids();
        }
        if (gameObject.name == "botaoFicha")
        {
            id = this.gameObject.transform.parent.GetComponent<iniciativa>().id;
            remapearLista();
        }

        if (cont < 0)
        {
            cont = 0;
        }

    }

    public void acharFilhos()
    {

        if(filho.transform.parent.gameObject != this.gameObject &&  conts != 0)
        {
            cont = 1;
            StartCoroutine(voltarFilho());
        }
    }
    IEnumerator voltarFilho()
    {
        yield return new WaitForSeconds(1f);
        filho.transform.SetParent(this.gameObject.transform);
        cont = 0;
    }

    public void criar()
    {
        fichas[0].GetComponent<iniciativa>().filho.GetComponent<Image>().color = normal;
        cont++;
        fichas[cont] = Instantiate(fichas[0], exemplo.transform.position, exemplo.transform.rotation);
        fichas[cont].transform.parent = exemplo.transform.parent;
        fichas[cont].transform.localScale = new Vector3(1, 1, 1);
        fichas[cont].transform.Translate(0, (-70 * cont), 0);
        fichas[cont].GetComponent<iniciativa>().filho.transform.Find("Text").GetComponent<Text>().text = menus.GetComponent<menu>().pesaCor.transform.parent.GetComponent<trocarmaterial>().nickNeme;
        //fichas[cont].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().id = cont;
        fichas[cont].GetComponent<iniciativa>().id = cont;
        fichas[cont].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token = menus.GetComponent<menu>().pesaCor.transform.parent.gameObject;
        fichas[cont].SetActive(true);
        fichas[cont].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combate = true;
        fichas[cont].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().iniciativas = this.gameObject;


    }

    public void excluir(int contas)
    {
        fichas[contas] = null;
        //Destroy(fichas[contas]);
        //cont--;
        organizar(contas);
    }

    public void organizar(int contas)
    {
        if (contas != cont)
        {
            contas++;
            if (fichas[contas] != null)
            {
                fichas[contas].GetComponent<iniciativa>().filho.transform.Translate(0, (70 * cont), 0);
                organizar(contas);
            }

        }

    }

    public void passar()
    {
        if(fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token != null)
        {
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().enabled = false;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = false;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.white;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 2;
        }
       
        fichas[vez].GetComponent<iniciativa>().filho.GetComponent<Image>().color = normal;
        vez++;
        if (fichas[vez] != null)
        {
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<Image>().color = amarelo;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = true;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().enabled = true;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.red;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 6;
        }


        if (vez > cont)
        {
            vez = 1;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<Image>().color = amarelo;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = true;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().enabled = true;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.red;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 6;
        }

        

    }

    public void voltar()
    {
        if (painelB.GetComponent<iniciativa>().vez != 0)
        {
            if (fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token != null)
            {
                fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().enabled = false;
                fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = false;
                fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.white;
                fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 2;
            }
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<Image>().color = normal;
            vez--;
            if (fichas[vez] != null)
            {
                fichas[vez].GetComponent<iniciativa>().filho.GetComponent<Image>().color = amarelo;
                if (fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token != null)
                {
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = true;
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().enabled = true;
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.red;
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 6;
                }
            }


            if (vez < 1)
            {
                vez = cont;
                fichas[vez].GetComponent<iniciativa>().filho.GetComponent<Image>().color = amarelo;
                if (fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token != null)
                {
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = true;
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().enabled = true;
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.red;
                    fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 6;
                }

            }
        }
    }

    public void iniciar()
    {
        if (fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token != null)
        {
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.white;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 2;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = false;
            fichas[vez].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combate = false;
        }
        
        vez = 0;
        if(cont > 0 && proximo.interactable == false)
        {
            combatendo = true;
            proximo.interactable = true;
            voltarndo.interactable = true;
            titulo.text = "Fechar Combate";
        }

        else if (proximo.interactable == true)
        {
            combatendo = false;
            StartCoroutine(ativar());
            titulo.text = "Iniciar Combate";
            proximo.interactable = false;
            voltarndo.interactable = false;
            destroir();
        }

    }
    IEnumerator ativar()
    {
        yield return new WaitForSeconds(0.5f);
        combatendo = true;
    }


    public void destroir()
    {
        if (cont != 0)
        {
            Destroy(fichas[cont]);
            cont--;
            destroir();
        }
        
    }

    public void ids()
    {
        //painelB.GetComponent<iniciativa>().vez = 0;
        if (token != null)
        {
            token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineColor = Color.white;
            token.GetComponent<trocarmaterial>().filho.GetComponent<Outline>().OutlineWidth = 2;
            token.GetComponent<trocarmaterial>().combate = false;
            painelB.GetComponent<iniciativa>().fichas[id].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().token.GetComponent<trocarmaterial>().combatendo = false;
        }
        
        
        painelB.GetComponent<iniciativa>().fichas[id].GetComponent<iniciativa>().filho.GetComponent<Image>().color = normal;
        painelB.GetComponent<iniciativa>().excluir(id);
        Destroy(this.gameObject.transform.parent.gameObject);
        

    }

    IEnumerator esperar()
    {

        yield return new WaitForSeconds(0.2f);


    }


    public void remapearLista()
    {
        if (painelB.GetComponent<iniciativa>().fichas[id - 1] == null)
        {
            print("oiiiiiiiiiiiiii");
            painelB.GetComponent<iniciativa>().fichas[id - 1] = this.gameObject.transform.parent.gameObject;
            painelB.GetComponent<iniciativa>().fichas[id] = null;
            id--;
           


        }
        if (valorDosDados != 0 && id != 1 && botao.isOn == true)
        {
            if (painelB.GetComponent<iniciativa>().fichas[id - 1].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().valorDosDados < valorDosDados)
            {
                this.gameObject.transform.parent.gameObject.GetComponent<iniciativa>().acharFilhos();
                painelB.GetComponent<iniciativa>().fichas[id - 1].GetComponent<iniciativa>().filho.GetComponent<iniciativa>().id++;
                painelB.GetComponent<iniciativa>().fichas[id - 1].GetComponent<iniciativa>().filho.transform.parent = painelB.GetComponent<iniciativa>().fichas[id].transform;
                this.gameObject.transform.parent.gameObject.GetComponent<iniciativa>().filho = painelB.GetComponent<iniciativa>().fichas[id - 1].GetComponent<iniciativa>().filho;
                id--;
                this.gameObject.transform.parent = painelB.GetComponent<iniciativa>().fichas[id].transform;
                this.gameObject.transform.parent.GetComponent<iniciativa>().filho = this.gameObject;
            }
        }
        



    }
    public void reapropriar()
    {
        painelB.GetComponent<iniciativa>().cont--;
        if(painelB.GetComponent<iniciativa>().vez != 0)
        {
            painelB.GetComponent<iniciativa>().vez--;
        }
        
        if (painelB.GetComponent<iniciativa>().fichas[painelB.GetComponent<iniciativa>().vez].GetComponent<iniciativa>().filho == this.gameObject)
        {
            
        }
        
    }

    public void jogarDados()
    {
        dadoss.interactable = false;
        StartCoroutine(oi());
        cameraFilha.GetComponent<gridNetWork>().indicarIniciativaa(this.gameObject);
    }
    IEnumerator oi()
    {
        yield return new WaitForSeconds(4.4f);
        dadoss.gameObject.GetComponent<Image>().enabled = false;
        dadoss.transform.Find("Text").GetComponent<Text>().text = ("" + valorDosDados);
    }


}
