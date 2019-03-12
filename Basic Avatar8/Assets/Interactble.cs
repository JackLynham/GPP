using UnityEngine;

public class Interactble : MonoBehaviour
{
    public float radius = 3f;

  void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
