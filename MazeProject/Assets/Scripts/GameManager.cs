using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public SliderController sliderController;
    [SerializeField] private Button createMazeButton;
    [SerializeField] private TMP_Text sizeText;

    [SerializeField] private Board board;
    [SerializeField] private Player player;

    private void Start() {
        sliderController.SliderValueChange += SetSlideValue;
        createMazeButton.onClick.AddListener(CreateMaze);
    }

    private void SetSlideValue(float val) {
        sizeText.text = val.ToString();
        board.size = (int)val;
    }

    private void CreateMaze() {
        board.Initialze();
        board.Spawn();

        player.Initialze(1, 1, board);
    }
}