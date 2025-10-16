using UnityEngine;
using UnityEditorInternal;

[CreateAssetMenu(fileName = "Arma", menuName = "Scriptable Objects/Arma")]
public class Arma : ScriptableObject
{
    string tipo;
    int dano;
    int balasIniciales;
    // coordenadas de  la mira 
    //int balas_curret;

    public void SetArma(tipoArmas tipo)
    {
        switch (tipo)
        {
            case tipoArmas.Pistola:
                this.tipo = "A";
                this.dano = 1;
                this.balasIniciales = 200;
                break;
            case tipoArmas.Metralleta:
                this.tipo = "B";
                this.dano = 1;
                this.balasIniciales = 300;
                break;
        }
    }
    
}


public enum tipoArmas
{
    Pistola, Metralleta
};
