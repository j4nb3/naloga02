using UnityEngine;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour
{

    // textures
    public Texture2D healthBackground; // back segment
    public Texture2D healthForeground; // front segment
    public Texture2D healthDamage; // draining segment
    public GUIStyle HUDSkin; // Styles up the health integer

    //values   
    private float previousHealth; //a value for reducing previous current health through attacks
    private float healthBarWidth; //a value for creating the health bar size
    private float myFloat; // an empty float value to affect drainage speed
    public static float curHP; // current HP
    public static float maxHP; // maximum HP

    void Start()
    {
        curHP -= 0; // drain the current HP to test the health (Assign a value to drain the health)
        previousHealth = maxHP; // assign the empty value to store the value of max health
        healthBarWidth = 100f; // create the health bar value
        myFloat = (maxHP / 100) * 10; // affects the health drainage
    }

    void Update()
    {
        adjustCurrentHealth();
    }

    public void adjustCurrentHealth()
    {

        /**Deduct the current health value from its damage**/

        if (previousHealth > curHP)
        {
            previousHealth -= ((maxHP / curHP) * (myFloat)) * Time.deltaTime; // deducts health damage
        }
        else
        {
            previousHealth = curHP;
        }

        if (previousHealth < 0)
        {
            previousHealth = 0;
        }

        if (curHP > maxHP)
        {
            curHP = maxHP;
            previousHealth = maxHP;
        }

        if (curHP < 0)
        {
            curHP = 0;
        }
    }

    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int height = 15;

        float previousAdjustValue = (previousHealth * healthBarWidth) / maxHP;
        float percentage = healthBarWidth * (curHP / maxHP);

        GUI.DrawTexture(new Rect(posX, posY, (healthBarWidth * 2), height), healthBackground);

        GUI.DrawTexture(new Rect(posX, posY, (previousAdjustValue * 2), height), healthDamage);

        GUI.DrawTexture(new Rect(posX, posY, (percentage * 2), height), healthForeground);

        HUDSkin = new GUIStyle();

        if (curHP == maxHP)
        {
            HUDSkin.normal.textColor = Color.green;
            HUDSkin.fontStyle = FontStyle.BoldAndItalic;
            HUDSkin.fontSize = 16;
            GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);

        }
        else if (curHP < maxHP)
        {

            if (percentage <= 50 && percentage >= 25){
                HUDSkin.normal.textColor = Color.yellow;
                HUDSkin.fontStyle = FontStyle.BoldAndItalic;
                HUDSkin.fontSize = 16;
                GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);

            } else if (percentage < 25)
            {
                HUDSkin.normal.textColor = Color.red;
                HUDSkin.fontStyle = FontStyle.BoldAndItalic;
                HUDSkin.fontSize = 16;
                GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);

            }
            else
            {
                HUDSkin.normal.textColor = Color.white;
                HUDSkin.fontStyle = FontStyle.BoldAndItalic;
                HUDSkin.fontSize = 16;
                GUI.Label(new Rect(30, 28, 100, 50), (int)(previousHealth) + "/" + maxHP.ToString(), HUDSkin);
            }
        }
    }
}