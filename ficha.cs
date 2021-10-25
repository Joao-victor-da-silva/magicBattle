using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ficha : MonoBehaviour
{
    /*
    //informaçoes iniciais
    string nomePersonagem, classe, antecedente, nomeJogador, rasa, alinhamento, xp;
    
    //pericias
    int acrobacia, arcanismo, atletismo, atuacao, enganacao, furtividade, historia, instituicao, lidarAnimais;
    int medicina, natureza, percepcao, persusao, presigitacao, religiao, sobrevivencia;
    //outras Proficiencia e ediomas
    string procienciasIdiomas;
    //equipamento
    string equipamento;
    //caracteristicas e talentos
    string caracteristicasTalentos;
    //caracteristicasPersonagem
    string personalidade, ideais, vinculos, draquezas;
    //vida calsse de armadura iniciativa descolamento etc..
    int ca, inciativa, deslocamento, vidaMaxima, vidaAtual, vidaTemporaria, dadoVida;
    //dinheiro
    int pc, pp, pe, po, pl;
    //savaguarda contra morte
    bool sucesso01, sucesso02, sucesso03, fracasso01, fracasso02, fracasso03;
    //ataquesConjuracoes
    string ataquesConjuracoes;
    //armas
    string nomeArma01, nomeArma02, nomeArma03, bonusAtaque01, bonusAtaque02, bonusAtaque03, danoTipo01, danoTipo02, danoTipo03;
    //caracteriscas do perosnagem
    string idade, altura, peso, corOlhos, corpele, corCabelo, tesouros, historiaPersonagem, alidados,talentos;
    //magias truques
    string classeConjuradora, Atributos, cd, modificadorAtaque, truques, magia01, magia02, magia03, magia04, magia05, magia06, magia07, magia08, magia09;
    */

    [SerializeField] GameObject[] fichas;
    [SerializeField] GameObject[] atributos, modificador, savaguarda, pericias;
    //atributos
    int forca, destreza, constituicao, inteligencia, sabedoria, carisma;

    public GameObject bonusProficiencia, iniciativa, percepcaoPassiva;

    void Start()
    {
        
    }


    void Update()
    {

        atribuir();
    
    }

    public void setarPericias(int valor)
    {
        //forca 0, destreza 1, constituicao 2, inteligencia 3, sabedoria 4, carisma 5

        //acrobacia
        if (pericias[18].GetComponent<Toggle>().isOn == true && valor == 1)
        {
            int valorInt = (int.Parse(modificador[1].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[0].GetComponent<Text>().text = valorString + valorInt;

        }
        else if(pericias[18].GetComponent<Toggle>().isOn == false)
        {
                pericias[0].GetComponent<Text>().text = modificador[1].GetComponent<Text>().text;
            
        }

        //arcanismo
        if (pericias[19].GetComponent<Toggle>().isOn == true && valor == 2)
        {
            int valorInt = (int.Parse(modificador[3].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[1].GetComponent<Text>().text = valorString + valorInt;


        }
        else if(pericias[19].GetComponent<Toggle>().isOn == false)
        {
            pericias[1].GetComponent<Text>().text = modificador[3].GetComponent<Text>().text;
        }


        //atletismo
        if (pericias[20].GetComponent<Toggle>().isOn == true && valor == 3)
        {
            int valorInt = (int.Parse(modificador[0].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[2].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[20].GetComponent<Toggle>().isOn == false)
        {
            pericias[2].GetComponent<Text>().text = modificador[0].GetComponent<Text>().text;
        }
        
        //atuacao
        if(pericias[21].GetComponent<Toggle>().isOn == true && valor == 4)
        {
            int valorInt = (int.Parse(modificador[5].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[3].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[21].GetComponent<Toggle>().isOn == false)
        {
            pericias[3].GetComponent<Text>().text = modificador[5].GetComponent<Text>().text;
        }

        //enganacao
        if (pericias[22].GetComponent<Toggle>().isOn == true && valor == 5)
        {
            int valorInt = (int.Parse(modificador[0].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[4].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[22].GetComponent<Toggle>().isOn == false)
        {
            pericias[4].GetComponent<Text>().text = modificador[0].GetComponent<Text>().text;
        }

        //furtividade
        if (pericias[23].GetComponent<Toggle>().isOn == true && valor == 6)
        {
            int valorInt = (int.Parse(modificador[1].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[5].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[23].GetComponent<Toggle>().isOn == false)
        {
            pericias[5].GetComponent<Text>().text = modificador[1].GetComponent<Text>().text;
        }

        //historia
        if (pericias[24].GetComponent<Toggle>().isOn == true && valor == 7)
        {
            int valorInt = (int.Parse(modificador[3].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[6].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[24].GetComponent<Toggle>().isOn == false)
        {
            pericias[6].GetComponent<Text>().text = modificador[3].GetComponent<Text>().text;
        }

        //imtimidacao
        if (pericias[25].GetComponent<Toggle>().isOn == true && valor == 8)
        {
            int valorInt = (int.Parse(modificador[5].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[7].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[25].GetComponent<Toggle>().isOn == false)
        {
            pericias[7].GetComponent<Text>().text = modificador[5].GetComponent<Text>().text;
        }

        //ituicao
        if (pericias[26].GetComponent<Toggle>().isOn == true && valor == 9)
        {
            int valorInt = (int.Parse(modificador[4].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[8].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[26].GetComponent<Toggle>().isOn == false)
        {
            pericias[8].GetComponent<Text>().text = modificador[4].GetComponent<Text>().text;
        }

        //investigacao
        if (pericias[27].GetComponent<Toggle>().isOn == true && valor == 10)
        {
            int valorInt = (int.Parse(modificador[3].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[9].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[27].GetComponent<Toggle>().isOn == false)
        {
            pericias[9].GetComponent<Text>().text = modificador[3].GetComponent<Text>().text;
        }
        //lidar animais
        if (pericias[28].GetComponent<Toggle>().isOn == true && valor == 11)
        {
            int valorInt = (int.Parse(modificador[4].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[10].GetComponent<Text>().text = valorString + valorInt;
        }
        else if(pericias[28].GetComponent<Toggle>().isOn == false)
        {
            pericias[10].GetComponent<Text>().text = modificador[4].GetComponent<Text>().text;
        }

        //medicina
        if (pericias[29].GetComponent<Toggle>().isOn == true && valor == 12)
        {
            int valorInt = (int.Parse(modificador[4].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[11].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[29].GetComponent<Toggle>().isOn == false)
        {
            pericias[11].GetComponent<Text>().text = modificador[4].GetComponent<Text>().text;
        }

        //natureza
        if (pericias[30].GetComponent<Toggle>().isOn == true && valor == 13)
        {
            int valorInt = (int.Parse(modificador[3].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[12].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[30].GetComponent<Toggle>().isOn == false)
        {
            pericias[12].GetComponent<Text>().text = modificador[3].GetComponent<Text>().text;
        }

        //percepcao
        if (pericias[31].GetComponent<Toggle>().isOn == true && valor == 14)
        {
            int valorInt = (int.Parse(modificador[4].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[13].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[31].GetComponent<Toggle>().isOn == false)
        {
            pericias[13].GetComponent<Text>().text = modificador[4].GetComponent<Text>().text;
        }

        //persuacao
        if (pericias[32].GetComponent<Toggle>().isOn == true && valor == 15)
        {
            int valorInt = (int.Parse(modificador[5].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[14].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[32].GetComponent<Toggle>().isOn == false)
        {
            pericias[14].GetComponent<Text>().text = modificador[5].GetComponent<Text>().text;
        }

        //pretigitacao
        if (pericias[33].GetComponent<Toggle>().isOn == true && valor == 16)
        {
            int valorInt = (int.Parse(modificador[1].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[15].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[33].GetComponent<Toggle>().isOn == false)
        {
            pericias[15].GetComponent<Text>().text = modificador[1].GetComponent<Text>().text;
        }

        //religiao
        if (pericias[34].GetComponent<Toggle>().isOn == true && valor == 17)
        {
            int valorInt = (int.Parse(modificador[3].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[16].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[34].GetComponent<Toggle>().isOn == false)
        {
            pericias[16].GetComponent<Text>().text = modificador[3].GetComponent<Text>().text;
        }

        //sobrevivencia
        if (pericias[35].GetComponent<Toggle>().isOn == true && valor == 18)
        {
            int valorInt = (int.Parse(modificador[4].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            pericias[17].GetComponent<Text>().text = valorString + valorInt;
        }
        else if (pericias[35].GetComponent<Toggle>().isOn == false)
        {
            pericias[17].GetComponent<Text>().text = modificador[4].GetComponent<Text>().text;
        }

        calcularPercpcao();


    }

    public void setarModificadoer(string Modif)
    {
        if (Modif == "forca")
        {
            valoresModificadorHabilidades(forca, 0);
        }
        else if (Modif == "destreza")
        {
            valoresModificadorHabilidades(destreza, 1);
        }
        else if (Modif == "constituicao")
        {
            valoresModificadorHabilidades(constituicao, 2);
        }
        else if (Modif == "inteligencia")
        {
            valoresModificadorHabilidades(inteligencia, 3);
        }
        else if (Modif == "sabedoria")
        {
            valoresModificadorHabilidades(sabedoria, 4);
        }
        else if (Modif == "carisma")
        {
            valoresModificadorHabilidades(carisma, 5);
        }


    }
    public void salvaGuardas(int valor)
    {
        if(savaguarda[6].GetComponent<Toggle>().isOn == true && valor == 1)
        {
            int valorInt = (int.Parse(savaguarda[0].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }
            
            savaguarda[0].GetComponent<Text>().text = valorString + (int.Parse(savaguarda[0].GetComponent<Text>().text)
                + int.Parse(bonusProficiencia.GetComponent<Text>().text));
        }
        else if(savaguarda[6].GetComponent<Toggle>().isOn == false)
        {
            savaguarda[0].GetComponent<Text>().text = modificador[0].GetComponent<Text>().text;
        }

        if (savaguarda[7].GetComponent<Toggle>().isOn == true && valor == 2)
        {
            int valorInt = (int.Parse(savaguarda[1].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }


            savaguarda[1].GetComponent<Text>().text = valorString + (int.Parse(savaguarda[1].GetComponent<Text>().text)
                + int.Parse(bonusProficiencia.GetComponent<Text>().text));
        }
        else if(savaguarda[7].GetComponent<Toggle>().isOn == false)
        {
            savaguarda[1].GetComponent<Text>().text = modificador[1].GetComponent<Text>().text;
        }

        if (savaguarda[8].GetComponent<Toggle>().isOn == true && valor == 3)
        {
            int valorInt = (int.Parse(savaguarda[2].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }


            savaguarda[2].GetComponent<Text>().text = valorString + (int.Parse(savaguarda[2].GetComponent<Text>().text)
                    + int.Parse(bonusProficiencia.GetComponent<Text>().text));
        }
        else if(savaguarda[8].GetComponent<Toggle>().isOn == false)
        {
            savaguarda[2].GetComponent<Text>().text = "" + modificador[2].GetComponent<Text>().text;
        }

        if (savaguarda[9].GetComponent<Toggle>().isOn == true && valor == 4)
        {
            int valorInt = (int.Parse(savaguarda[3].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            savaguarda[3].GetComponent<Text>().text = valorString + (int.Parse(savaguarda[3].GetComponent<Text>().text)
                    + int.Parse(bonusProficiencia.GetComponent<Text>().text));
        }
        else if(savaguarda[9].GetComponent<Toggle>().isOn == false)
        {
            savaguarda[3].GetComponent<Text>().text = modificador[3].GetComponent<Text>().text;
        }

        if (savaguarda[10].GetComponent<Toggle>().isOn == true && valor == 5)
        {
            int valorInt = (int.Parse(savaguarda[4].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            savaguarda[4].GetComponent<Text>().text = valorString + (int.Parse(savaguarda[4].GetComponent<Text>().text)
                            + int.Parse(bonusProficiencia.GetComponent<Text>().text));
        }
        else if(savaguarda[10].GetComponent<Toggle>().isOn == false)
        {
            savaguarda[4].GetComponent<Text>().text = modificador[4].GetComponent<Text>().text;
        }

        if (savaguarda[11].GetComponent<Toggle>().isOn == true && valor == 6)
        {
            int valorInt = (int.Parse(savaguarda[5].GetComponent<Text>().text) + int.Parse(bonusProficiencia.GetComponent<Text>().text));
            string valorString;
            valorString = "";
            if (valorInt > 0)
            {
                valorString = "+";
            }

            savaguarda[5].GetComponent<Text>().text = valorString + (int.Parse(savaguarda[5].GetComponent<Text>().text)
                    + int.Parse(bonusProficiencia.GetComponent<Text>().text));
        }
        else if(savaguarda[11].GetComponent<Toggle>().isOn == false)
        {
            savaguarda[5].GetComponent<Text>().text = modificador[5].GetComponent<Text>().text;
        }
    }

    public void valoresModificadorHabilidades(int valor, int atributoo)
    {
        if(valor == 1)
        {
            //valor = -5;
            modificador[atributoo].GetComponent<Text>().text  = "-5";
            savaguarda[atributoo].GetComponent<Text>().text = "-5";
        }
        else if (valor == 2 || valor == 3)
        {
            //valor = -4;
            modificador[atributoo].GetComponent<Text>().text = "-4";
            savaguarda[atributoo].GetComponent<Text>().text = "-4";
        }
        else if (valor == 4 || valor == 5)
        {
            //valor = -3;
            modificador[atributoo].GetComponent<Text>().text = "-3";
            savaguarda[atributoo].GetComponent<Text>().text = "-3";
        }
        else if (valor == 6 || valor == 7)
        {
            //valor = -2;
            modificador[atributoo].GetComponent<Text>().text = "-2";
            savaguarda[atributoo].GetComponent<Text>().text = "-2";
        }
        else if (valor == 8 || valor == 9)
        {
            //valor = -1;
            modificador[atributoo].GetComponent<Text>().text = "-1";
            savaguarda[atributoo].GetComponent<Text>().text = "-1";
        }
        else if (valor == 10 || valor == 11)
        {
            //valor = 0;
            modificador[atributoo].GetComponent<Text>().text = "0";
            savaguarda[atributoo].GetComponent<Text>().text = "0";
        }
        else if (valor == 12 || valor == 13)
        {
            //valor = 1;
            modificador[atributoo].GetComponent<Text>().text = "+1";
            savaguarda[atributoo].GetComponent<Text>().text = "+1";
        }
        else if (valor == 14 || valor == 15)
        {
            //valor = 2;
            modificador[atributoo].GetComponent<Text>().text = "+2";
            savaguarda[atributoo].GetComponent<Text>().text = "+2";
        }
        else if (valor == 16 || valor == 17)
        {
            //valor = 3;
            modificador[atributoo].GetComponent<Text>().text = "+3";
            savaguarda[atributoo].GetComponent<Text>().text = "+3";
        }
        else if (valor == 18 || valor == 19)
        {
            //valor = 4;
            modificador[atributoo].GetComponent<Text>().text = "+4";
            savaguarda[atributoo].GetComponent<Text>().text = "+4";
        }
        else if (valor == 20 || valor == 21)
        {
            //valor = 5;
            modificador[atributoo].GetComponent<Text>().text = "+5";
            savaguarda[atributoo].GetComponent<Text>().text = "+5";
        }
        else if (valor == 22 || valor == 23)
        {
            //valor = 6;
            modificador[atributoo].GetComponent<Text>().text = "+6";
            savaguarda[atributoo].GetComponent<Text>().text = "+6";
        }
        else if (valor == 24 || valor == 25)
        {
            //valor = 7;
            modificador[atributoo].GetComponent<Text>().text = "+7";
            savaguarda[atributoo].GetComponent<Text>().text = "+7";
        }
        else if (valor == 26 || valor == 27)
        {
            //valor = 8;
            modificador[atributoo].GetComponent<Text>().text = "+8";
            savaguarda[atributoo].GetComponent<Text>().text = "+8";
        }
        else if (valor == 28 || valor == 29)
        {
            //valor = 9;
            modificador[atributoo].GetComponent<Text>().text = "+9";
            savaguarda[atributoo].GetComponent<Text>().text = "+9";
        }
        else if (valor == 30)
        {
            //valor = 10;
            modificador[atributoo].GetComponent<Text>().text = "+10";
            savaguarda[atributoo].GetComponent<Text>().text = "+10";
        }


        iniciativa.GetComponent<Text>().text = modificador[1].GetComponent<Text>().text;



        calcularPercpcao();
        setarPericias(0);
        return;
    }

    public void calcularPercpcao()
    {
        if (pericias[13].GetComponent<Text>().text != "")
        {
            
                //percepcaoPassiva.GetComponent<Text>().text = "" + (10 + int.Parse(modificador[4].GetComponent<Text>().text));
                percepcaoPassiva.GetComponent<Text>().text = "" + (10 + int.Parse(pericias[13].GetComponent<Text>().text));
            
        }
        
    }

    public void atribuir()
    {
        if(atributos[0].GetComponent<Text>().text != "")
        {
            forca = int.Parse(atributos[0].GetComponent<Text>().text);
        }
        if (atributos[1].GetComponent<Text>().text != "")
        {
            destreza = int.Parse(atributos[1].GetComponent<Text>().text);
        }
        if (atributos[2].GetComponent<Text>().text != "")
        {
            constituicao = int.Parse(atributos[2].GetComponent<Text>().text);
        }
        if (atributos[3].GetComponent<Text>().text != "")
        {
            inteligencia = int.Parse(atributos[3].GetComponent<Text>().text);
        }
        if (atributos[4].GetComponent<Text>().text != "")
        {
            sabedoria = int.Parse(atributos[4].GetComponent<Text>().text);
        }
        if (atributos[5].GetComponent<Text>().text != "")
        {
            carisma = int.Parse(atributos[5].GetComponent<Text>().text);
        }

        
       
       
        
        
    }

    public void part01()
    {
        fichas[0].SetActive(true);
        fichas[1].SetActive(false);
        fichas[2].SetActive(false);
    }

    public void part02()
    {
        fichas[0].SetActive(false);
        fichas[1].SetActive(true);
        fichas[2].SetActive(false);
    }

    public void part03()
    {
        fichas[0].SetActive(false);
        fichas[1].SetActive(false);
        fichas[2].SetActive(true);
    }

    public void escala(Slider teste)
    {
        fichas[3].transform.localScale = new Vector3(teste.value, teste.value, teste.value);
    }

    public void close()
    {
        this.gameObject.SetActive(false);
    }

}
