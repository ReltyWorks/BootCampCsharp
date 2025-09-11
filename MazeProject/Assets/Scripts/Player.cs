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

        // 스트럭트로 만든 이유
        // 1. 값형식이라 힙 할당 => GC부담이 없음
        //  class는 참조형식이라 new 할 때마다 힙(heap)에 객체가 생기고, GC가 관리해야함
        //  struct는 값 형식이라 스택(stack) 이나 배열 내부에 바로 저장 됨
        //  즉, 우선순위 큐에서 엄청 많은 노드를 Push/Pop할 때 GC Alloc이 줄고 성능이 좋아질 수 있음.

        // 2. 크기가 작은 데이터 묶음이기 때문에 struct가 적절
        //  PQNode가 담고 있는 필드가 몇개 안될거고
        //  struct가 딱 그런 변수들의 묶음 덩어리용으로 쓰임
        //  .net의 디자인 가이드에도 구조체가 16바이트 이내라면 클래스(객체)보다 성능상 유리하다 나와있음.

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

        // 점수 매기기
        // F = G + H
        // F = 최종 점수 (작을 수록 좋음, 경로에 따라 달라짐)
        // G = 시작점에서 해당 좌표까지 이동하는데 드는 비용 (작을 수록 좋음, 경로에 따라 달라짐)
        // H = (휴리스틱) 목적지에서 얼마나 가까운지 (작을 수록 좋음, 고정)

        // (y, x) 이미 방문했는지 여부 ( 방문 = closed 상태)
        bool[,] closed = new bool[board.size, board.size]; // CloseList

        // (y, x) 가는 길을 한번 이라도 발견 했는지
        // 발견 X => MaxValue
        // 발견 O => F = G + H
        int[,] open = new int[board.size, board.size]; // OpenList
        for (int y = 0; y < board.size; y++) {

            for (int x = 0; x < board.size; x++) {
                open[y, x] = Int32.MaxValue;
            }
        }

        Pos[,] parent = new Pos[board.size, board.size];

        // 오픈 리스트에 있는 정보들 중에서, 가장 좋은 후보를 빠르게 뽑아오기 위한 우선순위 큐
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

        // 시작점 발견
        open[PosY, PosX] = 10 * (Math.Abs(board.DestY - PosY) + Math.Abs(board.DestX - PosX));
        pq.Push(new PQNode() {
            F = 10 * (Math.Abs(board.DestY - PosY) + Math.Abs(board.DestX - PosX)),
            G = 0,
            Y = PosY,
            X = PosX
        });

        parent[PosY, PosX] = new Pos(PosY, PosX);

        while (pq.Count > 0) {
            // 제일 좋은 후보 찾기
            PQNode node = pq.Pop();

            // 동일한 좌표를 여러 경로로 찾아서, 더 빠른 경로로 인해서 이미 방문(closed) 된 경우는 스킵

            if (closed[node.Y, node.X]) {
                // 우리가 만든 PriorityQueue는 DecreaseKey 가 없는 단순 Push/Pop임
                // 같은 큐에 같은 키가 들어왔을때 최적키만 남기고 더 나쁜 키는 버리는 기능이 없음
                // 중복되는 키가 생길 수도 있고 그걸 방지하기 위한 코드
                continue;
            }

            // 방문 한다.
            closed[node.Y, node.X] = true;

            // 목적지에 도착하면 바로 종료
            if (node.Y == board.DestY && node.X == board.DestX) continue;

            // 상좌하우 등 이동할 수 있는 좌표인지 확인해서 예약(open) 한다.
            for (int i = 0; i < deltaY.Length; i++) {
                int nextY = node.Y + deltaY[i];
                int nextX = node.X + deltaX[i];

                // 유효범위 벗어나면 스킵
                if (nextY < 0 || nextY >= board.size || nextX < 0 || nextX >= board.size) continue;

                // 체크 하려는 점이 갈 수 있는 점인지
                if ((board.tiles[nextY, nextX] == TileType.INNER_WALL) ||
                    (board.tiles[nextY, nextX] == TileType.OUTER_WALL)) {
                    continue;
                }

                // 이미 방문했으면 스킵
                if (closed[nextY, nextX]) continue;

                // 비용 계산
                int g = node.G + cost[i];
                int h = 10 * (Math.Abs(board.DestY - nextY) + Math.Abs(board.DestX - nextX));

                // 다른 경로에서 더 빠른 길을 이미 찾았으면 스킵
                if (open[nextY, nextX] < g + h) continue;

                // 예약 진행
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

                // 범위를 초과하지 않게 막기
                if (nextY < 0 || nextY >= board.size || nextX < 0 || nextX >= board.size) continue;

                // 체크 하려는 점이 갈 수 있는 점인지
                if ((board.tiles[nextY, nextX] == TileType.INNER_WALL) ||
                    (board.tiles[nextY, nextX] == TileType.OUTER_WALL)) {
                    continue;
                }

                // 이미 찾은 점인지 확인
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

        points.Add(new Pos(y, x)); // 최초지점 수동 추가
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

        points.Add(new Pos(y, x)); // 최초지점 수동 추가
        points.Reverse();
    }

    // 우수법
    void RigthHand() {
        // 내가 바라보는 방향 기준 앞방향 타일을 확인 하기 위한 좌표
        int[] forntY = new int[] { -1, 0, 1, 0 };
        int[] forntX = new int[] { 0, -1, 0, 1 };

        // 내가 바라보는 방향 기준 오른쪽 타일을
        int[] rigthY = new int[] { 0, -1, 0, 1 };
        int[] rigthX = new int[] { 1, 0, -1, 0 };

        points.Add(new Pos(PosY, PosX));

        // 목적지 까지 가는 경로를 확인하기 위해 계속 탐색 
        while (PosY != board.DestY || PosX != board.DestX) {
            // 1. 현재 바라보는 방향을 기준으로 오른쪽으로 갈 수 있는지 확인
            if ((board.tiles[PosY + rigthY[dir], PosX + rigthX[dir]] != TileType.INNER_WALL) &&
                (board.tiles[PosY + rigthY[dir], PosX + rigthX[dir]] != TileType.OUTER_WALL)) {
                #region
                // 오른쪽 방향으로 90도 회전
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
                //} 위 스위치문이 아래와 같음
                #endregion

                dir = (dir - 1 + 4) % 4;
                // 모듈러 연산(modular arihmetic)을 이용한 원형 인덱스(circular index) 패턴
                // 모듈러 연산 = 나머지 연산 %을 사용해서 값의 범위를 고정하는 수학적 기법
                // 원형 인덱스 = 음수나 범위를 벗어난 인덱스가 나오지 않도록 끝에 도달하면 다시 처음으로 돌아가는 구조

                // 앞으로 일보 전진
                PosY += forntY[dir];
                PosX += forntX[dir];

                points.Add(new Pos(PosY, PosX));
            }
            // 현재 바라보는 방향을 기준으로 전진할수있는지 확인
            else if ((board.tiles[PosY + forntY[dir], PosX + forntX[dir]] != TileType.INNER_WALL) &&
                     (board.tiles[PosY + forntY[dir], PosX + forntX[dir]] != TileType.OUTER_WALL)) {
                PosY += forntY[dir];
                PosX += forntX[dir];
                // 앞으로 일보 전진

                points.Add(new Pos(PosY, PosX));
            }
            // 3. 내 오른쪽, 내앞 모두 벽이 있다면
            else {
                // 왼쪽 방향으로 90도 회전 후 턴 넘기기
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
