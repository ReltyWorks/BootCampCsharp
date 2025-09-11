using UnityEngine;

public enum TileType {
    NONE,
    EMPTY,
    OUTER_WALL,
    INNER_WALL,
    GOAL
}

public class Board : MonoBehaviour {

    public TileType[,] tiles;
    public int size { get; set; }

    public int DestY { get; set; }
    public int DestX { get; set; }

    Transform maze;
    Shader shader;
    Material errorMat;
    Material emptyMat;
    Material outerWallMat;
    Material innerWallMat;
    Material goalMat;

    public void Initialze() {
        DestY = size - 2;
        DestX = size - 2;

        shader = Shader.Find("Universal Render Pipeline/Lit");
        errorMat = new Material(shader);
        errorMat.color = Color.magenta;

        emptyMat = new Material(shader);
        emptyMat.color = Color.white;

        outerWallMat = new Material(shader);
        outerWallMat.color = new Color(0.99f, 0.46f, 0.32f);

        innerWallMat = new Material(shader);
        innerWallMat.color = new Color(0.32f, 0.46f, 0.99f);

        goalMat = new Material(shader);
        goalMat.color = new Color(0.99f, 0.99f, 0.32f);

        tiles = new TileType[size, size];
        this.size = size;

        GenerateBySideWinder();
        Camera.main.transform.position = new Vector3(size / 2, size, -size / 2);
        Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
    }

    void GenerateBySideWinder() {
        // 일단 길 다 막음
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                // 1. 외벽인가?
                if (x == 0 || x == size - 1 || y == 0 || y == size - 1) {
                    tiles[y, x] = TileType.OUTER_WALL;
                }
                // 2. 골인 지점인가?
                else if (x == DestX && y == DestY) {
                    tiles[y, x] = TileType.GOAL;
                }
                // 3. 그 외 나머지(내부 벽 또는 빈 공간)
                else {
                    if (x % 2 == 0 || y % 2 == 0) {
                        tiles[y, x] = TileType.INNER_WALL;
                    }
                    else {
                        tiles[y, x] = TileType.EMPTY;
                    }
                }
            }
        }
        for (int y = 0; y < size; y++) {
            int count = 1;
            for (int x = 0; x < size; x++) {
                if (x % 2 == 0 || y % 2 == 0) continue;

                if (y == size - 2 && x == size - 2) continue;

                // 가장 오른쪽 끝이면 무조건 벽 풀고 길로
                if (y == size - 2) {
                    tiles[y, x + 1] = TileType.EMPTY;
                    continue;
                }

                // 가장 아래쪽 끝이면 무조건 벽 풀고 길로
                if (x == size - 2) {
                    tiles[y + 1, x] = TileType.EMPTY;
                    continue;
                }

                // 결국 x, y, 좌표가 모두 홀수인 애들을 대상으로
                // 0과 1 중 랜덤 뽑음
                // 0이면 오른쪽 길뚫고 카운트 1증가
                if (Random.Range(0, 2) == 0) {
                    tiles[y, x + 1] = TileType.EMPTY;
                    count++;
                }

                // 1이면 아래쪽 길 뚫는데 여태까지 오른쪽으로 뚫었던 X 중 한개를 골라서 뚫음
                else {
                    //           x - 라는건 지금 진행이 왼쪽에서 오른쪽으로 뚫고 있었기 때문
                    //                                      * 2 해준 이유는 짝수 좌표 애들이 있기 때문에 2를 곱해야함
                    tiles[y + 1, x - Random.Range(0, count) * 2] = TileType.EMPTY;
                    // 즉, 오른쪽으로 3번 뚫은 상태라면 0, 1, 2 중에 하나 나올거고
                    // 만약 2가 나오면 곱하기 2 해서 x - 4 즉, 맨 왼쪽에서 아래로 길이 남
                    // 그리고 카운트를 초기화 해줌
                    count = 1;
                }

            }
        }
    }

    public void Spawn() {

        if (maze != null) Despawn();

        maze = new GameObject().transform;
        maze.parent = transform;
        maze.name = "Maze";

        for (int y = 0; y < size; y++) {
            for(int x = 0; x < size; x++) {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(x, 0, -y);
                go.transform.parent = maze;

                if (tiles[y, x] == TileType.EMPTY)
                    go.transform.localScale = new Vector3(1f, 0.1f, 1f);
                else if (tiles[y, x] == TileType.GOAL)
                    go.transform.localScale = new Vector3(1f, 0.5f, 1f);
                else
                    go.transform.localScale = new Vector3(1f, 1.5f, 1f);

                go.GetComponent<MeshRenderer>().sharedMaterial = GetTileColor(tiles[y, x]);
            }
        }
    }

    Material GetTileColor(TileType _type) {
        switch (_type) {
            case TileType.EMPTY:
                return emptyMat;
            case TileType.OUTER_WALL:
                return outerWallMat;
            case TileType.INNER_WALL:
                return innerWallMat;
            case TileType.GOAL:
                return goalMat;
        }
        return errorMat;
    }

    void Despawn() {
        Destroy(maze.gameObject);
        maze = null;
    }
}
