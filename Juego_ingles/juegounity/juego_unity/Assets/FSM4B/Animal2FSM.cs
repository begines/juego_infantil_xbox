using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal2FSM : BaseFSM {

    int numWaypoint = -1;
    float auxVelocidad;

    public float tiempoEspera = 0;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        auxVelocidad = agentNPC.speed;

	}
	
	// Update is called once per frame
	void Update ()
    {
        EstadoPatrullaje();
        EstadoAlerta();
	}

    protected override void EstadoPatrullaje()
    {
        if (estadoActual == EstadoAgent.patrullaje)
        {
            agentNPC.isStopped = false;
            agentNPC.stoppingDistance = 0f;
            agentNPC.speed = auxVelocidad;
            if (vida != maxVida)
            {
                estadoActual = EstadoAgent.cazar;
                return;
            }
            else
            {
                agentNPC.stoppingDistance = 0;
                if (agentNPC.remainingDistance <= agentNPC.stoppingDistance && !agentNPC.pathPending)
                {
                    numWaypoint = (numWaypoint + 1) % waypoints.Length;
                    agentNPC.destination = waypoints[numWaypoint].position;
                }
            }
        }
    }

    protected override void EstadoAlerta()
    {
        if (estadoActual == EstadoAgent.alerta)
        {
            agentNPC.stoppingDistance = 1.8f;
            transform.LookAt(target.transform.position);
            Debug.Log("Distancia, enemigo y player: " + Vector3.Distance(transform.position, target.transform.position));
            if (!cazar)
            {
                if (Vector3.Distance(transform.position, target.transform.position) > distanciaTarget)
                {
                    tiempoEspera++;
                    if (tiempoEspera == 60)
                    {
                        estadoActual = EstadoAgent.patrullaje;
                        return;
                    }
                }
            }
            else
            {
                agentNPC.speed = auxVelocidad + 8f;
            }

            if (target != null && Vector3.Distance(transform.position, target.transform.position) <= distanciaTarget)
            {
                agentNPC.isStopped = false;
                agentNPC.destination = target.transform.position;
                if (agentNPC.remainingDistance <= agentNPC.stoppingDistance && !agentNPC.pathPending)
                {
                    agentNPC.isStopped = true;
                    estadoActual = EstadoAgent.atacar;
                    EstadoAtacar();
                }
            }
        }
    }

    protected override void EstadoAtacar()
    {
        Debug.Log("Ataco");
    }

    protected override void EstadoCazar()
    {
        throw new NotImplementedException();
    }

    protected override void EstadoHuir()
    {
        throw new NotImplementedException();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player" || cazar)
        {
            target = obj.gameObject;
            estadoActual = EstadoAgent.alerta;
            agentNPC.isStopped = true;
            tiempoEspera = 0;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Player")
        {
            target = null;
            agentNPC.isStopped = false;
            estadoActual = EstadoAgent.patrullaje;
            tiempoEspera = 0;
        }
    }
}
