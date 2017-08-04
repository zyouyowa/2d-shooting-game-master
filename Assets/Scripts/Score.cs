using UnityEngine;

public class Score : MonoBehaviour {

    public static Score instance{ get; private set; }

    public GUIText scoreText;
    public GUIText highScoreText;

    private int score;
    private int highScore;
    private string highScoreKey = "highScore";

    void Awake () {
        if (instance != null) {
            Destroy (gameObject);
        }
        instance = this;
        Initialize ();
    }

    void Update () {
        if (score > highScore) {
            highScore = score;
        }
        scoreText.text = score.ToString ();
        highScoreText.text = "HighScore : " + highScore.ToString ();
    }

    public void Initialize () {
        score = 0;
        highScore = PlayerPrefs.GetInt (highScoreKey, 0);
    }

    public void AddPoint (int point) {
        score += point;
    }

    public void Save () {
        PlayerPrefs.SetInt (highScoreKey, highScore);
        PlayerPrefs.Save ();

        Initialize ();
    }
}
