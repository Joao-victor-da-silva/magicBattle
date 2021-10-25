using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{

    [SerializeField] float velocidade;
    [SerializeField] GameObject painel01, painel02, botao;
    //[SerializeField] Dropdown resolucao, qualidade;
    [SerializeField] TMP_Dropdown resolucao, qualidade;
    [SerializeField] Slider audios;

   
    // Start is called before the first frame update
    void Start()
    {
       // SceneManager.UnloadSceneAsync(1);
        puxarResolucao();
        qualidadeInicial();
        puxarTelaCheia();
        puxarVolume();
        if (gameObject.name != "PanelB")
        {
            deletarManger();
        }
        

        

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name != "PanelB")
        {
            transform.Rotate(0, velocidade * Time.deltaTime, 0);
            if (painel02.activeSelf == true)
            {
                resolucao.transform.Find("Label").GetComponent<TMP_Text>().text = Screen.width + "x" + Screen.height + "@" + Application.targetFrameRate + "Hz";
            }
        }
        else
        {
            resolucao.transform.Find("Label").GetComponent<TMP_Text>().text = Screen.width + "x" + Screen.height + "@" + Application.targetFrameRate + "Hz";
        }
        
        
    }

    //jogar
    public void jogar()
    {
        SceneManager.LoadScene(1);
    }


    //entrar nos opçoes
    public void opcoes()
    {

        if(painel01.activeSelf == true)
        {
            painel01.SetActive(false);
            painel02.SetActive(true);
        }
        else if(painel02.activeSelf == true)
        {
            painel02.SetActive(false);
            painel01.SetActive(true);
        }

    }

    //sair do jogo
    public void sair()
    {
        Application.Quit();
    }

    //puxar resolução
    public void puxarResolucao()
    {
        Resolution[] todasResolucoes = Screen.resolutions;
        resolucao.options.Clear();
        for (int y = 0; y < todasResolucoes.Length; y++)
            resolucao.options.Add(new TMP_Dropdown.OptionData()
            {
                text = todasResolucoes[y].width + "x" + todasResolucoes[y].height + " @ " + todasResolucoes[y].refreshRate + "Hz"
            });
    }

    //setar resolução
    public void setarResolucao()
    {
        Resolution[] todasResolucoes = Screen.resolutions;
        resolucao.options.Clear();
        for (int y = 0; y < todasResolucoes.Length; y++)
            resolucao.options.Add(new TMP_Dropdown.OptionData()
            {
                text = todasResolucoes[y].width + "x" + todasResolucoes[y].height + " @ " + todasResolucoes[y].refreshRate + "Hz"
            });
        Screen.SetResolution(todasResolucoes[resolucao.value].width, todasResolucoes[resolucao.value].height, Screen.fullScreen);
        Application.targetFrameRate = todasResolucoes[resolucao.value].refreshRate;
    }

    //setar tela cheia
    public void teclaCheia()
    {
        if (botao.GetComponent<Toggle>().isOn == false)
        {
            Screen.fullScreen = false;
        }
        if (botao.GetComponent<Toggle>().isOn == true)
        {
            Screen.fullScreen = true;
        }
    }

    //setar o garfico
    public void Grafico()
    {
        QualitySettings.SetQualityLevel(qualidade.value);
    }

    //setar o audio
    public void volume()
    {
        AudioListener.volume = audios.value;
    }

    //puxar Audio
    private void puxarVolume()
    {
        audios.value = AudioListener.volume;
    }

    //puxar Tela cheia
    private void puxarTelaCheia()
    {
        if (Screen.fullScreen == true)
        {
            botao.GetComponent<Toggle>().isOn = true;
        }
        if (Screen.fullScreen == false)
        {
            botao.GetComponent<Toggle>().isOn = false;
        }
    }

    //setar qualidadeinicial
    private void qualidadeInicial()
    {
        qualidade.value = QualitySettings.GetQualityLevel();
    }

    public void deletarManger()
    {

        Destroy(GameObject.Find("NetworkManager").gameObject);
        //Destroy(GameObject.Find("[Debug Updater]").gameObject);
        //Destroy(GameObject.Find("SimpleFileBrowserCanvas(Clone)").gameObject);

    } 

}
