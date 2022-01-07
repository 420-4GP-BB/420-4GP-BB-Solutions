using System;

public class GameManager
{
	private static GameManager _instance = new GameManager();

	private GameManager()
	{
		EnPause = false;
		NombreBalles = 100;
	}

	public static GameManager Instance()
    {
		return _instance;
    }

	public bool EnPause
    {
		get;
		private set;
    }

	public int NombreBalles
    {
		set;
		get;
    }

	public float VitesseEnnemi
    {
		set;
		get;
    }

	public void InverserPause()
    {
		EnPause = !EnPause;
    }
}
