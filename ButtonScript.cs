using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool IsOn;

    public Vector2 Detectbounds;
    public Transform DetectOrigin;
    public LayerMask AcceptedLayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Collider2D[] colls = Physics2D.OverlapBoxAll(DetectOrigin.position, Detectbounds, 0, AcceptedLayers);
        if (colls.Length > 0 )
        {
            IsOn = true;
        }
        else
        {
            IsOn = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (IsOn)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireCube(DetectOrigin.position, Detectbounds);
    }
}
