using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class SecurityFindTarget : MonoBehaviour, IFindTarget
{
    [SerializeField] int _visitAgentTypeID;
    public Vector3 Target { get; set; }
    private NavMeshAgent[] _visitors;

    private void Start()
    {
        FindAllVisitors();
    }

    public void FindTarget()
    {
        FindAllVisitors();
        if (_visitors.Length != 0)
        {
            
            var numberOfTarget = Random.Range(0, _visitors.Length);
            Target = _visitors[numberOfTarget].transform.position;
        }
        else
            Target = transform.position;
    }

    private void FindAllVisitors()
    {
        var allAgent = FindObjectsByType<NavMeshAgent>(FindObjectsSortMode.None);
        var filteredList = new List<NavMeshAgent>();
        foreach (var agent in allAgent)
        {
            if(agent.agentTypeID == _visitAgentTypeID)
            {
                filteredList.Add(agent);
            }
        }
        _visitors = filteredList.ToArray();
    }
}
