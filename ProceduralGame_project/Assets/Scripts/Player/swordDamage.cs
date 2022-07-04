
using UnityEngine;


public class swordDamage : MonoBehaviour
{
    [Header("Dependencias")]
    public EffectsBrain effects_cs;
    public killsUI killUI_cs;
    [Header("Configuracion")]
    public int damage;
    //Variables privadas
    private Main main_cs;
    private void Start()
    {
        //Obtener dependencias globales
        main_cs = GameObject.FindWithTag("Main").GetComponent<Main>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBrain enemy_cs = collision.GetComponent<EnemyBrain>();
        //Si obtenemos el enemi brain proseguimos
        if (enemy_cs != null)
        {
            //Shakeamos la camara y activamos efecto su el enemigo tiene mas vida
            if (enemy_cs.healthPoints > 0)
            {
                //Sacudimos la camara
                main_cs.shakeNow(0.2f);
                //Enviamos la nueva ubicacion del efecto
                effects_cs.Hit(collision.gameObject.transform.position);


                //Enviamos el daño 
                enemy_cs.SendDamage(damage);

                //Finalmente si la vida del enemigo es cero aumentamos nuestras kills
                //Este es de uso UI , no afecta en nada mas , solo cuenta
                if (enemy_cs.healthPoints == 0) killUI_cs.KillUp();
            }
        }
        else Debug.Log("[!]El enemigo (" + collision.transform.name + ") no contiene un EnemyBrain");
    }
}
