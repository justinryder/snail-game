using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Snail snail;

    public Texture2D HealyEmpty;
    public Texture2D HealthFull;

    void OnGUI()
    {
        if (snail.isAlive)
        {
            GUI.DrawTexture(new Rect(10, Screen.height - 128 - 10, 128, 64), HealthFull);
        }
        else
        {
            GUI.DrawTexture(new Rect(10, Screen.height - 128 - 10, 128, 64), HealyEmpty);
        }
    }
}
