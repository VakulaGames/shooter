using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemysMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;

    private List<NavMeshAgent> _agents;

    private void Start()
    {
        _agents = new List<NavMeshAgent>();
        StartCoroutine(UpdateTarget());
    }

    private IEnumerator UpdateTarget()
    {
        while (true)
        {
            foreach (NavMeshAgent agent in _agents)
            {
                agent.destination = _target.position;
                Debug.Log(agent);
            }
            yield return new WaitForSeconds(_delay);
        }
    }

    public void AddAgent(GameObject enemy)
    {
        NavMeshAgent agent;
        if (enemy.TryGetComponent<NavMeshAgent>(out agent))
        {
            _agents.Add(agent);
        }
    }
}
