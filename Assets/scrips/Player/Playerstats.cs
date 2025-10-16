using UnityEngine;

[CreateAssetMenu(fileName = "Playerstats", menuName = "Scriptable Objects/Playerstats")]
public class Playerstats : ScriptableObject
{
    public int vidas = 3;

    public void ResetStats()
    {
        vidas = 3;
    }

}
