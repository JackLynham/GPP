using UnityEngine;

public class Interactble : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    void Update()
    {
       // Debug.Log(player);
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
               // Debug.Log("Interact");
                
            }
        }
    }
    public void Onfocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        Debug.Log("A");
        player = null;
    }

    public virtual void Interact()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
