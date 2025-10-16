using UnityEngine;
using UnityEditorInternal;

public class Armas
{
    bool cooldown;
    int dano;
    int balasIniciales;
    // coordenadas de  la mira 
    //int balas_curret;

    public void SetArma(tipoArmas tipo)
    {
        switch (tipo)
        {
            case tipoArmas.Pistola:
                cooldown = true;
                this.dano = 30;
                this.balasIniciales = 200;
                break;
            case tipoArmas.Metralleta:
                this.dano = 5;
                this.balasIniciales = 300;
                cooldown = false;
                break;
        }
    }
    
}



