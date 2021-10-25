using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using Mirror.Examples.Chat;

public class gerarDados : NetworkBehaviour
{

    [SerializeField] private GameObject d4, d6, d8, d10, d12, d20, d100;
    [SerializeField] private GameObject bd4, bd6, bd8, bd10, bd12, bd20, bd100, roll;
    [SerializeField] public GameObject d4t, d6t, d8t, d10t, d12t, d20t, d100t;
    [SerializeField] GameObject cameraa, dono, camerafilha;
    [SerializeField] int d4n, d6n, d8n, d10n, d12n, d20n, d100n;
    [SerializeField] int cont20, cont4, cont6, cont8, cont10, cont12, cont100;
    [SerializeField] bool jogardados;

    [SerializeField] Player player;

    [SyncVar] public Color corBase, corNumeros, corResultado;
    public Shader shederBase;
    public Texture texturaBase;
    [SyncVar] public bool costumisavel;
    public Material exemple;
    [SyncVar] GameObject eu;
    public GameObject ini;

    // Start is called before the first frame update
    void Start()
    {
        eu = this.gameObject;
        //shederBase = Shader.Find("UniversalRenderPipeline/Lit");
        player = NetworkClient.connection.identity.GetComponent<Player>();
        jogardados = false;
        cameraa = Camera.main.gameObject;
        camerafilha = cameraa.transform.Find("filho").gameObject;
       

        if(player.gameObject == this.gameObject) 
        {
            bd4 = GameObject.Find("D4B");
            bd6 = GameObject.Find("D6B");
            bd8 = GameObject.Find("D8B");
            bd10 = GameObject.Find("D10B");
            bd12 = GameObject.Find("D12B");
            bd20 = GameObject.Find("D20B");
            bd100 = GameObject.Find("D100B");
            roll = GameObject.Find("roll");

            bd4.GetComponent<Button>().onClick.AddListener(jogard4Offline);
            bd6.GetComponent<Button>().onClick.AddListener(jogard6Offline);
            bd8.GetComponent<Button>().onClick.AddListener(jogard8Offline);
            bd10.GetComponent<Button>().onClick.AddListener(jogard10Offline);
            bd12.GetComponent<Button>().onClick.AddListener(jogard12Offline);
            bd20.GetComponent<Button>().onClick.AddListener(jogard20Offline);
            bd100.GetComponent<Button>().onClick.AddListener(jogard100Offline);
            roll.GetComponent<Button>().onClick.AddListener(jogardadosOffline);
        }
        


        d4t = camerafilha.GetComponent<gridNetWork>().d4t;
        d6t = camerafilha.GetComponent<gridNetWork>().d6t;
        d8t = camerafilha.GetComponent<gridNetWork>().d8t;
        d10t = camerafilha.GetComponent<gridNetWork>().d10t;
        d12t = camerafilha.GetComponent<gridNetWork>().d12t;
        d20t = camerafilha.GetComponent<gridNetWork>().d20t;
        d100t = camerafilha.GetComponent<gridNetWork>().d100t;




    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            if(ini == null)
            {
                print("deu ruin porra");
            }
            else
            {
                print("deu bom");
            }
        }

        if (jogardados == true)
        {

            if (!isLocalPlayer)
            {
                return;
            }
            if (d4n != 0)
            {
                if (cont4 != d4n)
                {
                    cont4++;
                    CmdJogarDadoD4(corBase, corNumeros, corResultado, costumisavel, eu);

                }
                else if (cont4 >= d4n)
                {
                    cont4 = 0;
                    d4n = 0;
                    
                }
            }
            if (d6n != 0)
            {
                if (cont6 != d6n)
                {
                    cont6++;
                    CmdJogarDadoD6(corBase, corNumeros, corResultado, costumisavel, eu);
                }
                else if (cont6 >= d6n)
                {
                    cont6 = 0;
                    d6n = 0;
                   
                }
            }
            if (d8n != 0)
            {
                if (cont8 != d8n)
                {
                    cont8++;
                    CmdJogarDadoD8(corBase, corNumeros, corResultado, costumisavel, eu);
                }
                else if (cont8 >= d8n)
                {
                    cont8 = 0;
                    d8n = 0;
                    
                }
            }
            if (d10n != 0)
            {
                if (cont10 != d10n)
                {
                    cont10++;
                    CmdJogarDadoD10(corBase, corNumeros, corResultado, costumisavel, eu);
                }
                else if (cont10 >= d10n)
                {
                    cont10 = 0;
                    d10n = 0;
                    
                }
            }
            if (d12n != 0)
            {
                if (cont12 != d12n)
                {
                    cont12++;
                    CmdJogarDadoD12(corBase, corNumeros, corResultado, costumisavel, eu);
                }
                else if (cont12 >= d12n)
                {
                    cont12 = 0;
                    d12n = 0;
                   
                }
            }

            if (d20n != 0)
            {
                if (cont20 != d20n)
                {
                    cont20++;
                    CmdJogarDadoD20(corBase, corNumeros, corResultado, costumisavel, eu);
                }
                else if (cont20 >= d20n)
                {
                    cont20 = 0;
                    d20n = 0;
                    
                }
            }
            if (d100n != 0)
            {
                if (cont100 != d100n)
                {
                    cont100++;
                    CmdJogarDadoD100(corBase, corNumeros, corResultado, costumisavel, eu);
                }
                else if (cont100 >= d100n)
                {
                    cont100 = 0;
                    d100n = 0;
                    
                }
            }
        }

        if (d4n == 0 && d6n == 0 && d8n == 0 && d10n == 0 && d12n == 0 && d20n == 0 && d100n == 0)
        {
            jogardados = false;
        }
        
    }


    [Command]
    public void CmdJogarDadoD4(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;

        var dice4 = Instantiate(d4, d4.transform.position, d4.transform.rotation);
        dice4.GetComponent<diceStatc>().eu = eus;
        dice4.name = d4.name;
        dice4.transform.position = d4t.transform.position;
        dice4.transform.localScale = new Vector3(99, 99, 99);

        NetworkServer.Spawn(dice4.gameObject);

        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;

            
            dice4.GetComponent<Renderer>().materials = novoRender;
            dice4.GetComponent<diceGlow>().resultado = resultado;
        }

        

    }
    [Command]
    public void CmdJogarDadoD6(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;


        var dice6 = Instantiate(d6, d6.transform.position, d6.transform.rotation);
        dice6.GetComponent<diceStatc>().eu = eus;
        dice6.name = d6.name;
        dice6.transform.position = d6t.transform.position;
        dice6.transform.localScale = new Vector3(100, 100, 100);
        NetworkServer.Spawn(dice6.gameObject);

        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;


            dice6.GetComponent<Renderer>().materials = novoRender;
            dice6.GetComponent<diceGlow>().resultado = resultado;
        }

    }
    [Command]
    public void CmdJogarDadoD8(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;


        var dice8 = Instantiate(d8, d8.transform.position, d8.transform.rotation);
        dice8.GetComponent<diceStatc>().eu = eus;
        dice8.name = d8.name;
        dice8.transform.position = d8t.transform.position;
        dice8.transform.localScale = new Vector3(90, 90, 90);
        NetworkServer.Spawn(dice8.gameObject);

        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;


            dice8.GetComponent<Renderer>().materials = novoRender;
            dice8.GetComponent<diceGlow>().resultado = resultado;
        }

    }
    [Command]
    public void CmdJogarDadoD10(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;

        var dice10 = Instantiate(d10, d10.transform.position, d10.transform.rotation);
        dice10.GetComponent<diceStatc>().eu = eus;
        dice10.name = d10.name;
        dice10.transform.position = d10t.transform.position;
        dice10.transform.localScale = new Vector3(175, 175, 175);
        NetworkServer.Spawn(dice10.gameObject);

        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;


            dice10.GetComponent<Renderer>().materials = novoRender;
            dice10.GetComponent<diceGlow>().resultado = resultado;
        }

    }
    [Command]
    public void CmdJogarDadoD12(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;



        var dice12 = Instantiate(d12, d12.transform.position, d12.transform.rotation);
        dice12.GetComponent<diceStatc>().eu = eus;
        dice12.name = d12.name;
        dice12.transform.position = d12t.transform.position;
        dice12.transform.localScale = new Vector3(76, 76, 76);
        NetworkServer.Spawn(dice12.gameObject);

        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;


            dice12.GetComponent<Renderer>().materials = novoRender;
            dice12.GetComponent<diceGlow>().resultado = resultado;
        }

    }
    [Command]
    public void CmdJogarDadoD20(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;


        var dice20 = Instantiate(d20, d20.transform.position, d20.transform.rotation);
        dice20.GetComponent<diceStatc>().eu = eus;
        dice20.name = d20.name;
        dice20.transform.position = d20t.transform.position;
        dice20.transform.localScale = new Vector3(77, 77, 77);
        NetworkServer.Spawn(dice20.gameObject);

        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;


            dice20.GetComponent<Renderer>().materials = novoRender;
            dice20.GetComponent<diceGlow>().resultado = resultado;
        }
    }
    [Command]
    public void CmdJogarDadoD100(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;


        var dice100 = Instantiate(d100, d100.transform.position, d100.transform.rotation);
        dice100.GetComponent<diceStatc>().eu = eus;
        var dice10002 = Instantiate(d10, d10.transform.position, d10.transform.rotation);
        dice10002.GetComponent<diceStatc>().eu = eus;
        dice100.name = d100.name;
        dice10002.name = d10.name;
        dice100.transform.position = d100t.transform.position;
        dice10002.transform.position = d10t.transform.position;
        dice100.transform.localScale = new Vector3(175, 175, 175);
        dice10002.transform.localScale = new Vector3(175, 175, 175);
        NetworkServer.Spawn(dice100.gameObject);
        NetworkServer.Spawn(dice10002.gameObject);


        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;


            dice100.GetComponent<Renderer>().materials = novoRender;
            dice100.GetComponent<diceGlow>().resultado = resultado;
            dice10002.GetComponent<Renderer>().materials = novoRender;
            dice10002.GetComponent<diceGlow>().resultado = resultado;

        }
    }
   
    public void jogardadosOffline()
    {
        bd4.transform.Find("Text").GetComponent<Text>().text = "D4";
        bd6.transform.Find("Text").GetComponent<Text>().text = "D6";
        bd8.transform.Find("Text").GetComponent<Text>().text = "D8";
        bd10.transform.Find("Text").GetComponent<Text>().text = "D10";
        bd12.transform.Find("Text").GetComponent<Text>().text = "D12";
        bd20.transform.Find("Text").GetComponent<Text>().text = "D20";
        bd100.transform.Find("Text").GetComponent<Text>().text = "D100";

        if (isLocalPlayer)
        {
            jogardados = true;
        }
    }

    public void jogard4Offline()
    {
        d4n++;
        bd4.transform.Find("Text").GetComponent<Text>().text = d4n + "D4";
    }
    public void jogard6Offline()
    {
        d6n++;
        bd6.transform.Find("Text").GetComponent<Text>().text = d6n + "D6";
    }
    public void jogard8Offline()
    {
        d8n++;
        bd8.transform.Find("Text").GetComponent<Text>().text = d8n + "D8";
    }
    public void jogard10Offline()
    {
        d10n++;
        bd10.transform.Find("Text").GetComponent<Text>().text = d10n + "D10";
    }
    public void jogard12Offline()
    {
        d12n++;
        bd12.transform.Find("Text").GetComponent<Text>().text = d12n + "D12";
    }
    public void jogard20Offline()
    {
        d20n++;
        bd20.transform.Find("Text").GetComponent<Text>().text = d20n + "D20";
    }
    public void jogard100Offline()
    {
        d100n++;
        bd100.transform.Find("Text").GetComponent<Text>().text = d100n + "D100";
    }

    public void indicarIniciativa(GameObject teste)
    {
        ini = teste;
        print(teste.name + " deu nessa caraalha");
        print(ini.name + "deu????");
        CmdIniciativa(corBase, corNumeros, corResultado, costumisavel, eu, ini);
    }


    //[Command]
    public void CmdIniciativa(Color cbase, Color cnumeros, Color cresultado, bool costom, GameObject eus, GameObject testando)
    {

        corBase = cbase;
        corNumeros = cnumeros;
        corResultado = cresultado;
        costumisavel = costom;
        eu = eus;

        var dice20 = Instantiate(d20, d20.transform.position, d20.transform.rotation);
        dice20.GetComponent<diceStatc>().eu = eus;
        dice20.GetComponent<diceStatc>().iniciativaas = testando;
        dice20.name = d20.name;
        dice20.transform.position = d20t.transform.position;
        dice20.transform.localScale = new Vector3(77, 77, 77);
        //NetworkServer.Spawn(dice20.gameObject);

        if (costom == true)
        {
            Material bases = new Material(shederBase);
            bases.color = cbase;

            Material numeros = new Material(shederBase);
            numeros.CopyPropertiesFromMaterial(exemple);
            numeros.mainTexture = texturaBase;
            numeros.color = cnumeros;


            Material resultado = new Material(shederBase);
            resultado.CopyPropertiesFromMaterial(exemple);
            resultado.mainTexture = texturaBase;
            resultado.color = cresultado;

            Material[] novoRender = new Material[2];
            novoRender[0] = bases;
            novoRender[1] = numeros;


            dice20.GetComponent<Renderer>().materials = novoRender;
            dice20.GetComponent<diceGlow>().resultado = resultado;
        }
    }



}
