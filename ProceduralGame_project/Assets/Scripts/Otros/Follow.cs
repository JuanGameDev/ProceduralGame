
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        //Nos movemos al target
        transform.position = new Vector3(target.position.x , target.position.y , transform.position.z);
    }
}
