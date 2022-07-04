
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [Header("Displays")]
    public Text DF_display;
    public Text DM_display;
    public Text HP_display;
    public Text MP_display;
    public Text NV_display , NV_Hud_display;
    [Header("Sliders")]
    public Slider HP_slider;
    public Slider MP_slider;
    [Header("Scripts")]
    public swordDamage damage_cs;
    public CoinUI coinUI_cs;
    [Header("Price Config")]
    public Text priceDisplay;
    public int priceStart;
    public int priceScale;
    [Header("Stats Scale Config")]
    public int damageScale;
    public int magicScale;
    public int healthScale;
    public int manaScale;

    [Header("Events")]
    public UnityEvent AlMejorar;
    //Variables privadas
    private int DF;
    private int DM;
    private int HP;
    private int MP;
    private int NV;
    //
    private int price;

    private void Start()
    {
        //Asignamos los valores correspondientes
        DF = damage_cs.damage;
        DM = 5;

        HP = (int)HP_slider.maxValue;
        MP = (int)MP_slider.maxValue;

        NV = 1;
        //
        price = priceStart;
        //
        DisplayUpdate();

    }
    public void UpgradeStats()//Llamar aqui para mejorar en general <===
    {
        //Permitira la mejora solo si se tiene el dinero correspondiente
        if(coinUI_cs.coinValue - price > 0)
        {
            //Aqui mejoraremos los atributos de forma escalar
            DF += damageScale;
            DM += magicScale;
            HP += healthScale;
            MP += manaScale;

            NV++;
            //
            price += priceScale;
            //
            StatsUpdate();
            //
            DisplayUpdate();
            //
            if(AlMejorar != null)AlMejorar.Invoke();
        }
    }
    private void DisplayUpdate()
    {
        //Actualizamos los valores de UI
        DF_display.text = "Daño Fisico: " + DF.ToString() + " -> " + (DF + damageScale).ToString();
        DM_display.text = "Daño Magico: " + DM.ToString() + " -> " + (DM + magicScale).ToString();
        HP_display.text = "Vida Maxima: " + HP.ToString() + " -> " + (HP + healthScale).ToString();
        MP_display.text = "Mana Maximo: " + MP.ToString() + " -> " + (MP + manaScale).ToString();

        NV_Hud_display.text = NV_display.text = "Nivel: " + NV;
        //
        priceDisplay.text = price.ToString() + "$";
    }
    private void StatsUpdate()
    {
        //Aqui asignaremos los atributos mejorados para que apliquen

        damage_cs.damage = DF;
        //
        HP_slider.maxValue = HP;
        MP_slider.maxValue = MP;
        //
        coinUI_cs.CoinDown(price);
    }

}
