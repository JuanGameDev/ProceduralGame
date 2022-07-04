
using UnityEngine;

public class Atack : MonoBehaviour
{
    //Variables locales
    private movement move_cs;
    private Jump jump_cs;
    private Animator animator;
    private float startSpeed;
    private void Start()
    {
        //Obtener dependencias locales
        move_cs = GetComponent<movement>();
        jump_cs = GetComponent<Jump>();
        animator = GetComponent<Animator>();
        //Almacenamos velocidad inicial
        startSpeed = move_cs.speed;
    }
    private void Update()
    {
        //Comprobar input para ataque normal
        if (Input.GetMouseButtonDown(0) && jump_cs.inGround)
        {
            animator.SetTrigger("atack");
        }
        //Comprobar si se ataca para reducir la velocidad , esto no afecta a la velocidad en modo magia
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("player_atack")) move_cs.speed = startSpeed /4;
        else if(!animator.GetCurrentAnimatorStateInfo(0).IsName("player_magic")) move_cs.speed = startSpeed;
    }
}
