using UnityEngine;
using System.Collections;

//currently just a placeholder for the game manager for ui purposes

public class UIDebug : MonoBehaviour {

	// initializes the visible game elements for player1 and player2
	public string p1_name = "Player1";
	public int p1_will = 2000;
	public int p1_ima = 2000;
	public int p1_cyclesLeft = 7;
	public int p1_stagesLeft = 7;
	public int p1_sleepStage = 0;

	public string p2_name = "Player2";
	public int p2_will = 2000;
	public int p2_ima = 2000;
	public int p2_cyclesLeft = 7;
	public int p2_stagesLeft = 7;
	public int p2_sleepStage = 0;
	
	void Update () {
	
		// sets up button keys for altering the visible game elements

		if (Input.GetKey(KeyCode.Q))
		{
			AddWill(1,1);
		}
		
		if (Input.GetKey(KeyCode.W))
		{
			AddWill(1,-1);
		}
		
		if (Input.GetKey(KeyCode.E))
		{
			AddWill(2,1);
		}
		
		if (Input.GetKey(KeyCode.R))
		{
			AddWill(2,-1);
		}

		if (Input.GetKey(KeyCode.A))
		{
			AddImagination(1,1);
		}

		if (Input.GetKey(KeyCode.S))
		{
			AddImagination(1,-1);
		}

		if (Input.GetKey(KeyCode.D))
		{
			AddImagination(2,1);
		}

		if (Input.GetKey(KeyCode.F))
		{
			AddImagination(2,-1);
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			AddStage(1,-1);
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			AddStage(2,-1);
		}
	}

	void AddWill( int player, int will )
	{
		// adds to the player x's will
		if (player==1)
		{
			p1_will += will;
		}
		else if (player==2)
		{
			p2_will += will;
		}
	}

	void AddImagination( int player, int ima )
	{
		// adds to the player x's imagination
		if (player==1)
		{
			p1_ima += ima;
		}
		else if (player==2)
		{
			p2_ima += ima;
		}
	}

	void AddCycle( int player, int cycle )
	{
		// moves the player up a cycle
		if (player==1)
		{
			p1_cyclesLeft += cycle;
		}
		else if (player==2)
		{
			p2_cyclesLeft += cycle;
		}
	}

	void AddStage( int player, int stage )
	{
		// moves the player up a stage in the sleep cycle;
		// the current sleep cycles is a debug sleep cycle that moves through the stages: theta, wave, rem, and lucid
		// once the player surpasses a sleep stage it cycles back to the first one
		// once the player surpasses a sleep cycle it cycles back to the next cycle and decrements from the total sleepcycles
		if (player==1)
		{
			p1_stagesLeft += stage;
			p1_sleepStage += 1;

			if (p1_sleepStage > 3)
			{
				p1_sleepStage = 0;
			}

			if (p1_stagesLeft == -1)
			{
				AddCycle(1,-1);
				p1_stagesLeft = 7;
			}
		}
		else if (player==2)
		{
			p2_stagesLeft += stage;
			p2_sleepStage += 1;

			if (p2_sleepStage > 3)
			{
				p2_sleepStage = 0;
			}

			if (p2_stagesLeft == -1)
			{
				AddCycle(2,-1);
				p2_stagesLeft = 7;
			}
		}
	}

}
