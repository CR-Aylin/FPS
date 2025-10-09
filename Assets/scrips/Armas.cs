using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(fileName = "Armas", menuName = "Scriptable Objects/Armas")]

public class Arma : ScriptableObject
{
    string nombre;
    string tipo;
    int dano;
    int balasIniciales;
    // coordenadas de  la mira 
    //int balas_curret;

    public void SetArma(tipoArmas tipo)
    {
        switch (tipo)
        {
            case tipoArmas.A:
                this.nombre = "AAAAAAAA";
                this.tipo = "A";
                this.dano = 1;
                this.balasIniciales = 2;
                break;
            case tipoArmas.B:
                this.nombre = "BBBBBBB";
                this.tipo = "B";
                this.dano = 1;
                this.balasIniciales = 2;
                break;
            case tipoArmas.C:
                this.nombre = "CCCC";
                this.tipo = "A";
                this.dano = 1;
                this.balasIniciales = 2;
                break;
        }
    }
}
public enum tipoArmas
{
    A, B,C
};
