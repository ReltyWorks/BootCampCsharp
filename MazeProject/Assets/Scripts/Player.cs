using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

class Pos {
    public Pos(int _y, int _x) { y = _y; x = _x; }
    public int y;
    public int x;
}

public class Player : MonoBehaviour {
    public int PosY {  get; set; }
    public int PosX { get; set; }

    Board board;
    bool isBoardCreated = false;

    enum Dir {
        UP,
        LEFT,
        DOWN,
        RIGHT
    }

    int dir = (int)Dir.UP;

    List<Pos> points = new List<Pos>();

    public void Initialze(int _posY, int _posX, Board _board) {
        PosY = _posY;
        PosX = _posX;
        board = _board;

        transform.position = new Vector3(PosX, 0, -PosY);

        points.Clear();
        lastIndex = 0;

        AStar();

        isBoardCreated = true;
    }

    struct PQNode : IComparable<PQNode> {

        // ��Ʈ��Ʈ�� ���� ����
        // 1. �������̶� �� �Ҵ� => GC�δ��� ����
        //  class�� ���������̶� new �� ������ ��(heap)�� ��ü�� �����, GC�� �����ؾ���
        //  struct�� �� �����̶� ����(stack) �̳� �迭 ���ο� �ٷ� ���� ��
        //  ��, �켱���� ť���� ��û ���� ��带 Push/Pop�� �� GC Alloc�� �ٰ� ������ ������ �� ����.

        // 2. ũ�Ⱑ ���� ������ �����̱� ������ struct�� ����
        //  PQNode�� ��� �ִ� �ʵ尡 � �ȵɰŰ�
        //  struct�� �� �׷� �������� ���� ��������� ����
        //  .net�� ������ ���̵忡�� ����ü�� 16����Ʈ �̳���� Ŭ����(��ü)���� ���ɻ� �����ϴ� ��������.

        public int F;
        public int G;
        public int Y;
        public int X;

        public int CompareTo(PQNode _other) {
            if (F == _other.F)
                return 0;
            return F < _other.F ? 1 : -1;
        }
    }

    void AStar() {

        int[] deltaY = new int[] { -1, 0, 1, 0, -1, 1, 1, -1 };
        int[] deltaX = new int[] { 0, -1, 0, 1, -1, -1, 1, 1 };
        int[] cost = new int[] { 10, 10, 10, 10, 14, 14, 14, 14 };

        // ���� �ű��
        // F = G + H
        // F = ���� ���� (���� ���� ����, ��ο� ���� �޶���)
        // G = ���������� �ش� ��ǥ���� �̵��ϴµ� ��� ��� (���� ���� ����, ��ο� ���� �޶���)
        // H = (�޸���ƽ) ���������� �󸶳� ������� (���� ���� ����, ����)

        // (y, x) �̹� �湮�ߴ��� ���� ( �湮 = closed ����)
        bool[,] closed = new bool[board.size, board.size]; // CloseList

        // (y, x) ���� ���� �ѹ� �̶� �߰� �ߴ���
        // �߰� X => MaxValue
        // �߰� O => F = G + H
        int[,] open = new int[board.size, board.size]; // OpenList
        for (int y = 0; y < board.size; y++) {

            for (int x = 0; x < board.size; x++) {
                open[y, x] = Int32.MaxValue;
            }
        }

        Pos[,] parent = new Pos[board.size, board.size];

        // ���� ����Ʈ�� �ִ� ������ �߿���, ���� ���� �ĺ��� ������ �̾ƿ��� ���� �켱���� ť
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

        // ������ �߰�
        open[PosY, PosX] = 10 * (Math.Abs(board.DestY - PosY) + Math.Abs(board.DestX - PosX));
        pq.Push(new PQNode() {
            F = 10 * (Math.Abs(board.DestY - PosY) + Math.Abs(board.DestX - PosX)),
            G = 0,
            Y = PosY,
            X = PosX
        });

        parent[PosY, PosX] = new Pos(PosY, PosX);

        while (pq.Count > 0) {
            // ���� ���� �ĺ� ã��
            PQNode node = pq.Pop();

            // ������ ��ǥ�� ���� ��η� ã�Ƽ�, �� ���� ��η� ���ؼ� �̹� �湮(closed) �� ���� ��ŵ

            if (closed[node.Y, node.X]) {
                // �츮�� ���� PriorityQueue�� DecreaseKey �� ���� �ܼ� Push/Pop��
                // ���� ť�� ���� Ű�� �������� ����Ű�� ����� �� ���� Ű�� ������ ����� ����
                // �ߺ��Ǵ� Ű�� ���� ���� �ְ� �װ� �����ϱ� ���� �ڵ�
                continue;
            }

            // �湮 �Ѵ�.
            closed[node.Y, node.X] = true;

            // �������� �����ϸ� �ٷ� ����
            if (node.Y == board.DestY && node.X == board.DestX) continue;

            // �����Ͽ� �� �̵��� �� �ִ� ��ǥ���� Ȯ���ؼ� ����(open) �Ѵ�.
            for (int i = 0; i < deltaY.Length; i++) {
                int nextY = node.Y + deltaY[i];
                int nextX = node.X + deltaX[i];

                // ��ȿ���� ����� ��ŵ
                if (nextY < 0 || nextY >= board.size || nextX < 0 || nextX >= board.size) continue;

                // üũ �Ϸ��� ���� �� �� �ִ� ������
                if ((board.tiles[nextY, nextX] == TileType.INNER_WALL) ||
                    (board.tiles[nextY, nextX] == TileType.OUTER_WALL)) {
                    continue;
                }

                // �̹� �湮������ ��ŵ
                if (closed[nextY, nextX]) continue;

                // ��� ���
                int g = node.G + cost[i];
                int h = 10 * (Math.Abs(board.DestY - nextY) + Math.Abs(board.DestX - nextX));

                // �ٸ� ��ο��� �� ���� ���� �̹� ã������ ��ŵ
                if (open[nextY, nextX] < g + h) continue;

                // ���� ����
                open[nextY, nextX] = g + h;

                pq.Push(new PQNode() {
                    F = g + h,
                    G = g,
                    Y = nextY,
                    X = nextX
                });

                parent[nextY, nextX] = new Pos(node.Y, node.X);
            }
        }

        CalcPathFromParent(parent);
    }


    void BFS() {
        int[] deltaY = new int[] { -1, 0, 1, 0 };
        int[] deltaX = new int[] { 0, -1, 0, 1 };

        bool[,] found = new bool[board.size, board.size];
        Pos[,] parent = new Pos[board.size, board.size];

        Queue<Pos> queue = new Queue<Pos>();
        queue.Enqueue(new Pos(PosY, PosX));
        found[PosY, PosX] = true;
        parent[PosY, PosX] = new Pos(PosY, PosX);

        while (queue.Count > 0) {
            Pos pos = queue.Dequeue();
            int nowY = pos.y;
            int nowX = pos.x;

            for (int i = 0; i < 4; i++) {
                int nextY = nowY + deltaY[i];
                int nextX = nowX + deltaX[i];

                // ������ �ʰ����� �ʰ� ����
                if (nextY < 0 || nextY >= board.size || nextX < 0 || nextX >= board.size) continue;

                // üũ �Ϸ��� ���� �� �� �ִ� ������
                if ((board.tiles[nextY, nextX] == TileType.INNER_WALL) ||
                    (board.tiles[nextY, nextX] == TileType.OUTER_WALL)) {
                    continue;
                }

                // �̹� ã�� ������ Ȯ��
                if (found[nextY, nextX] == true) continue;

                queue.Enqueue(new Pos(nextY, nextX));
                found[nextY, nextX] = true;
                parent[nextY, nextX] = new Pos(nowY, nowX);
            }
        }

        int y = board.DestY;
        int x = board.DestX;

        while (parent[y, x].y != y || parent[y, x].x != x) {
            points.Add(new Pos(y, x));

            Pos pos = parent[y, x];
            y = pos.y;
            x = pos.x;
        }

        points.Add(new Pos(y, x)); // �������� ���� �߰�
        points.Reverse();

    }

    void CalcPathFromParent(Pos[,] _parent) {
        int y = board.DestY;
        int x = board.DestX;

        while (_parent[y, x].y != y || _parent[y, x].x != x) {
            points.Add(new Pos(y, x));

            Pos pos = _parent[y, x];
            y = pos.y;
            x = pos.x;
        }

        points.Add(new Pos(y, x)); // �������� ���� �߰�
        points.Reverse();
    }

    // �����
    void RigthHand() {
        // ���� �ٶ󺸴� ���� ���� �չ��� Ÿ���� Ȯ�� �ϱ� ���� ��ǥ
        int[] forntY = new int[] { -1, 0, 1, 0 };
        int[] forntX = new int[] { 0, -1, 0, 1 };

        // ���� �ٶ󺸴� ���� ���� ������ Ÿ����
        int[] rigthY = new int[] { 0, -1, 0, 1 };
        int[] rigthX = new int[] { 1, 0, -1, 0 };

        points.Add(new Pos(PosY, PosX));

        // ������ ���� ���� ��θ� Ȯ���ϱ� ���� ��� Ž�� 
        while (PosY != board.DestY || PosX != board.DestX) {
            // 1. ���� �ٶ󺸴� ������ �������� ���������� �� �� �ִ��� Ȯ��
            if ((board.tiles[PosY + rigthY[dir], PosX + rigthX[dir]] != TileType.INNER_WALL) &&
                (board.tiles[PosY + rigthY[dir], PosX + rigthX[dir]] != TileType.OUTER_WALL)) {
                #region
                // ������ �������� 90�� ȸ��
                //switch (dir) {
                //    case (int)Dir.UP:
                //        dir = (int)Dir.RIGHT;
                //        break;
                //    case (int)Dir.LEFT:
                //        dir = (int)Dir.UP;
                //        break;
                //    case (int)Dir.DOWN:
                //        dir = (int)Dir.LEFT;
                //        break;
                //    case (int)Dir.RIGHT:
                //        dir = (int)Dir.DOWN;
                //        break;
                //} �� ����ġ���� �Ʒ��� ����
                #endregion

                dir = (dir - 1 + 4) % 4;
                // ��ⷯ ����(modular arihmetic)�� �̿��� ���� �ε���(circular index) ����
                // ��ⷯ ���� = ������ ���� %�� ����ؼ� ���� ������ �����ϴ� ������ ���
                // ���� �ε��� = ������ ������ ��� �ε����� ������ �ʵ��� ���� �����ϸ� �ٽ� ó������ ���ư��� ����

                // ������ �Ϻ� ����
                PosY += forntY[dir];
                PosX += forntX[dir];

                points.Add(new Pos(PosY, PosX));
            }
            // ���� �ٶ󺸴� ������ �������� �����Ҽ��ִ��� Ȯ��
            else if ((board.tiles[PosY + forntY[dir], PosX + forntX[dir]] != TileType.INNER_WALL) &&
                     (board.tiles[PosY + forntY[dir], PosX + forntX[dir]] != TileType.OUTER_WALL)) {
                PosY += forntY[dir];
                PosX += forntX[dir];
                // ������ �Ϻ� ����

                points.Add(new Pos(PosY, PosX));
            }
            // 3. �� ������, ���� ��� ���� �ִٸ�
            else {
                // ���� �������� 90�� ȸ�� �� �� �ѱ��
                dir = (dir + 1 + 4) % 4;
            }

        }
    }


    const float MOVE_TICK = 0.2f;
    float sumTick = 0;
    int lastIndex = 0;

    public void Update() {
        if (lastIndex >= points.Count) return;

        if (!isBoardCreated) return;

        sumTick += Time.deltaTime;

        if (sumTick < MOVE_TICK) return;

        sumTick = 0;

        PosY = points[lastIndex].y;
        PosX = points[lastIndex].x;
        lastIndex++;

        transform.position = new Vector3(PosX, 0, -PosY);
    }
}
