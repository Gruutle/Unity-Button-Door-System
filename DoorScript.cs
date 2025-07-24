using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Condition[] Conditions;

    bool ConditionsMet;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Conditions.Length; i++)
        {
            if (!Conditions[i].RequireOff)
            {
                if (Conditions[i].button.IsOn)
                {
                    ConditionsMet = true;
                }
                else
                {
                    ConditionsMet = false;
                    break;
                }
            }
            else
            {
                if (!Conditions[i].button.IsOn)
                {
                    ConditionsMet = true;
                }
                else
                {
                    ConditionsMet = false;
                    break;
                }
            }
        }

        animator.SetBool("Open", ConditionsMet);
    }

    private void OnDrawGizmos()
    {
        foreach (Condition condition in Conditions)
        {
            if (condition.button != null)
            {
                if (condition.button.IsOn)
                {
                    if (condition.RequireOff)
                    {
                        Gizmos.color = Color.red;
                    }
                    else
                    {
                        Gizmos.color = Color.green;
                    }
                }
                else
                {
                    if (condition.RequireOff)
                    {
                        Gizmos.color = Color.green;
                    }
                    else
                    {
                        Gizmos.color = Color.red;
                    }
                }
                Gizmos.DrawLine(transform.position, condition.button.transform.position);
            }
        }
    }
}
