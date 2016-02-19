using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {
	
	//A dictionary to hold all the stages
	private Dictionary<StateID, State> states = new Dictionary<StateID, State> ();
	
	//The current state we are in
	private State currentState;
	
	void Update () {
		if(currentState != null){
			currentState.Reason();
			currentState.Act();
		}
		
	}

	public void SetState(StateID stateID) {

		if(!states.ContainsKey(stateID))
			return;
		if(currentState != null)
			currentState.Leave();
		currentState = states[stateID];
		currentState.Enter();
	}

	public void AddState(StateID stateID, State state) {
		states.Add( stateID, state );
	}
	
}
