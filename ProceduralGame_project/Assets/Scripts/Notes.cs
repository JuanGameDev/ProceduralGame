//Correcto Funcionamiento de un Enemigo y sus Conexiones

//Debe tener un Collider con el script DamageSend , sera
//el que se encargue de enviarle el daño , la animacion , la escala
//y la fuerza al jugador , es  muy importante

//El collider Hurt del jugador y el collider Damage del enemigo deben estar en 
//la capa were , para evitar confunciones con multiples colliders anidados , esto
//se debe cumplir

//El collider de la espada debe tener un tag "sword" , para que el hurt del enemigo lo
//pueda detectar





//swordDamage y EnemyBrain trabajan en conjunto , sworDamage va en en colllider de la espada , 
//se encarga de humo y enviar daño , mientras quew EnemyBrain se encarga de la vida del enemigo maneja eventos
//Estos son necesarios , el sendDamage sera el "swordDamage" de los enemigos , este debe ir en el hit de los
//enemigos para que el jugador reciba el daño



//funcionamiento de las monedas , si el enemigo usa enemy brain al morir debera activar el objeto
//coinBoom que le agregamos dentro , el se encargara del resto , los scripts esta ya en funcionamiento
//hay distintos tipos de coin booom
