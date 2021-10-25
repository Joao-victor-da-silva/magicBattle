using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Examples.Chat;
using UnityEngine.UI;

public class gridNetWork : NetworkBehaviour
{
    [SerializeField] public GameObject d4t, d6t, d8t, d10t, d12t, d20t, d100t;
    public Transform pai, cubinho, carinha, dadinhos;
    public Player player;
    int cont;

    [SerializeField] Image cdado, cnumero, cresultado;
    [SerializeField] Toggle customizar;

    // Start is called before the first frame update
    void Start()
    {
        pai = transform.parent;
    }

    private void Update()
    {
        print("NetworkServer.active: " + NetworkServer.active);
        if (NetworkServer.active == true || NetworkClient.isConnected == true)
        {
            if (player == null)
            {
                StartCoroutine(aaa());
            }
            else if(player != null && cont == 0)
            {
                colocarDados();
            }

            if(player != null)
            {
                player.gameObject.GetComponent<gerarDados>().corBase = cdado.color;
                player.gameObject.GetComponent<gerarDados>().corNumeros = cnumero.color;
                player.gameObject.GetComponent<gerarDados>().corResultado = cresultado.color;
                player.gameObject.GetComponent<gerarDados>().costumisavel = customizar.isOn;
            }
        }
       
    }

    public void indicarIniciativaa(GameObject teste)
    {
        player.gameObject.GetComponent<gerarDados>().indicarIniciativa(teste);
    }



    public void criarOb()
    {
        criar();
    }

    [Command]
    void criar()
    {


        cubinho = Instantiate(pai.GetComponent<grid>().cubePrefeb, pai.GetComponent<grid>().tilepos, pai.GetComponent<grid>().cube.transform.rotation);
        carinha = cubinho;
        NetworkServer.Spawn(cubinho.gameObject);
        carinha.gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
        print("objeto spalnou");

    }

    public void criarDados(GameObject dados)
    {

        player.criarDados(dados);

    }


    IEnumerator aaa()
    {
        yield return new WaitForSeconds(0.2f);
        player = NetworkClient.connection.identity.GetComponent<Player>();
        
    }

    private void colocarDados()
    {
        cont++;
        player.gameObject.GetComponent<gerarDados>().d4t = d4t;
        player.gameObject.GetComponent<gerarDados>().d6t = d6t;
        player.gameObject.GetComponent<gerarDados>().d8t = d8t;
        player.gameObject.GetComponent<gerarDados>().d10t = d10t;
        player.gameObject.GetComponent<gerarDados>().d12t = d12t;
        player.gameObject.GetComponent<gerarDados>().d20t = d20t;
        player.gameObject.GetComponent<gerarDados>().d100t = d100t;
    }


       
   

}
