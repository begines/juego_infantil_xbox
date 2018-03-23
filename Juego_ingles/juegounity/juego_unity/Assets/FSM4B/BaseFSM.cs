using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseFSM : MonoBehaviour {

    public enum EstadoAgent { patrullaje, cazar, alerta, atacar, huir};
    public EstadoAgent estadoActual;
    public bool cazar = false;
    public float distanciaTarget;
    public GameObject target;
    public int maxVida = 10;
    public int vida;
    public int maxEnergia = 10;
    public int energia;
    public Transform[] waypoints;

    public NavMeshAgent agentNPC;

	// Use this for initialization
	protected virtual void Start ()
    {
        energia = maxEnergia;
        vida = maxVida;
        agentNPC = GetComponent<NavMeshAgent>();
		
	}

    protected abstract void EstadoPatrullaje();

    protected abstract void EstadoCazar();

    protected abstract void EstadoAlerta();

    protected abstract void EstadoAtacar();

    protected abstract void EstadoHuir();
}
