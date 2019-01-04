using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initializer : MonoBehaviour {

	//vars
	public int turn;
	public Sprite[] sprite_icon;
	public Image turnimg;
	public Text winner, xtext, otext;
	public Button[] tictactoe;
	public Button reset;
	public int[] markedButton;
	public int check = -1;
	public int checker, count = 0;
	public int x_score = 0, o_score = 0;

	//initialize
	public void varInitializer()
	{
		count = 0;
		winner.text = null;
		xtext.text = x_score.ToString();
		otext.text = o_score.ToString();
		checker = -1;
		check = -1;
		reset.interactable = false;
		turn = 0;

		for(int i = 0; i< tictactoe.Length; i++)
		{
			tictactoe[i].interactable = true;
			tictactoe[i].GetComponent<Image>().sprite = null;
		}

		for(int i = 0; i < tictactoe.Length; i++)
			if(markedButton[i] == -1)
				tictactoe[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

		for(int i = 0; i< markedButton.Length; i++)
			markedButton[i] = -1;

		Debug.Log("Everything it's ok!");
	}


	public void initialize()
	{
		varInitializer();
		xtext.text = "0";
		otext.text = "0";
		x_score = 0;
		o_score = 0;
	}

	//button functionality
	public void buttonFunctionality(int player)
	{
		count++;
		tictactoe[player].image.sprite = sprite_icon[turn];
		tictactoe[player].interactable = false;

		markedButton[player] = turn;

		if(turn == 0)
			turn = 1;
		else
			turn = 0;
		
		solution();
		if(check == 0)
			x_score++;
		else if(check == 1)
			o_score++;
	}

	public void solution()
	{
		//oblique
		if(markedButton[0] == 0 && markedButton[4] == 0 && markedButton[8] == 0)
			check = 0;
		else if(markedButton[0] == 1 && markedButton[4] == 1 && markedButton[8] == 1)
			check = 1;

		if(markedButton[2] == 0 && markedButton[4] == 0 && markedButton[6] == 0)
			check = 0;
		else if(markedButton[2] == 1 && markedButton[4] == 1 && markedButton[6] == 1)
			check = 1;
		
		//horizontal
		if(markedButton[0] == 0 && markedButton[1] == 0 && markedButton[2] == 0)
			check = 0;
		else if(markedButton[0] == 1 && markedButton[1] == 1 && markedButton[2] == 1)
			check = 1;

		if(markedButton[3] == 0 && markedButton[4] == 0 && markedButton[5] == 0)
			check = 0;
		else if(markedButton[3] == 1 && markedButton[4] == 1 && markedButton[5] == 1)
			check = 1;

		if(markedButton[6] == 0 && markedButton[7] == 0 && markedButton[8] == 0)
			check = 0;
		else if(markedButton[6] == 1 && markedButton[7] == 1 && markedButton[8] == 1)
			check = 1;
		
		//vertical
		if(markedButton[0] == 0 && markedButton[3] == 0 && markedButton[6] == 0)
			check = 0;
		else if(markedButton[0] == 1 && markedButton[3] == 1 && markedButton[6] == 1)
			check = 1;

		if(markedButton[1] == 0 && markedButton[4] == 0 && markedButton[7] == 0)
			check = 0;
		else if(markedButton[1] == 1 && markedButton[4] == 1 && markedButton[7] == 1)
			check = 1;

		if(markedButton[2] == 0 && markedButton[5] == 0 && markedButton[8] == 0)
			check = 0;
		else if(markedButton[2] == 1 && markedButton[5] == 1 && markedButton[8] == 1)
			check = 1;
	}

	int text_winner()
	{
		if(check == 0){
			winner.text = "X is the winner";
			return 0;
		}
		else if(check == 1)
		{
			winner.text = "O is the winner";
			return 1;
		}
		return -1;
	}
	
	void Start () {
		varInitializer();
	}
	
	// Update is called once per frame
	void Update () {
		text_winner();

		checker = text_winner();

		if(checker == 0 || checker == 1)
		{	
			for(int i = 0; i < tictactoe.Length; i++)
				if(markedButton[i] == -1)
					tictactoe[i].GetComponent<Image>().color = new Color(0.3f, 0.4f, 0.6f, 0.0f);
				
			for(int i = 0; i < tictactoe.Length; i++)
				tictactoe[i].interactable = false;
		}
		
		if(checker == 0 || checker == 1 || count == 9)
			reset.interactable = true;
		
		turnimg.sprite = sprite_icon[turn];
	}
}
