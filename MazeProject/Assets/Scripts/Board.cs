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
        // �ϴ� �� �� ����
        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                // 1. �ܺ��ΰ�?
                if (x == 0 || x == size - 1 || y == 0 || y == size - 1) {
                    tiles[y, x] = TileType.OUTER_WALL;
                }
                // 2. ���� �����ΰ�?
                else if (x == DestX && y == DestY) {
                    tiles[y, x] = TileType.GOAL;
                }
                // 3. �� �� ������(���� �� �Ǵ� �� ����)
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

                // ���� ������ ���̸� ������ �� Ǯ�� ���
                if (y == size - 2) {
                    tiles[y, x + 1] = TileType.EMPTY;
                    continue;
                }

                // ���� �Ʒ��� ���̸� ������ �� Ǯ�� ���
                if (x == size - 2) {
                    tiles[y + 1, x] = TileType.EMPTY;
                    continue;
                }

                // �ᱹ x, y, ��ǥ�� ��� Ȧ���� �ֵ��� �������
                // 0�� 1 �� ���� ����
                // 0�̸� ������ ��հ� ī��Ʈ 1����
                if (Random.Range(0, 2) == 0) {
                    tiles[y, x + 1] = TileType.EMPTY;
                    count++;
                }

                // 1�̸� �Ʒ��� �� �մµ� ���±��� ���������� �վ��� X �� �Ѱ��� ��� ����
                else {
                    //           x - ��°� ���� ������ ���ʿ��� ���������� �հ� �־��� ����
                    //                                      * 2 ���� ������ ¦�� ��ǥ �ֵ��� �ֱ� ������ 2�� ���ؾ���
                    tiles[y + 1, x - Random.Range(0, count) * 2] = TileType.EMPTY;
                    // ��, ���������� 3�� ���� ���¶�� 0, 1, 2 �߿� �ϳ� ���ðŰ�
                    // ���� 2�� ������ ���ϱ� 2 �ؼ� x - 4 ��, �� ���ʿ��� �Ʒ��� ���� ��
                    // �׸��� ī��Ʈ�� �ʱ�ȭ ����
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
