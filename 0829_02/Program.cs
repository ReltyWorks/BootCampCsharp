/*
Graph(그래프) -> 개념적으로는 현실 세계의 사물이나 추상적인 개념간의 연결 관계를 표현 한다.
    그래프를 표현하기 위한 자료형은 존재하지 않으며
    상황에 따라 리스트 혹은 배열로 직접 구현해야함
Vertex(정점) -> 데이터를 표현(위치, 사람, 물건)

Edge(간선) -> 정점들을 잇는 선(관계, 경로)
    단방향 간선 : 정점에서 다른 정점으로만 이은것
    양방향 간선 : 정점에서 다른 정점을 서로 이은것

Weight(가중치) -> 간선위에 표시하는 정점간의 수치(임의 정보)를 표현
    가중치 그래프 : 간선위에 가중치가 표시된 그래프


*/
namespace _0829_02 {
    //class Vertex {
    //    public List<Vertex> edges = new List<Vertex>();
    //}

    class Edge {
        public int vertex;
        public int weight;

        // 잘 안쓰지만 학술적으로 해봄
        public Edge(int v, int w) { 
            vertex = v;
            weight = w;
        }
    }

    // 그래프(양방향 간선)를 작성하는법
    internal class Program {
        static void Main(string[] args) {
            //List<Vertex> Vertexs = new List<Vertex>();
            //Vertexs.Add(new Vertex());
            //Vertexs.Add(new Vertex());
            //Vertexs.Add(new Vertex());
            //Vertexs.Add(new Vertex());
            //Vertexs.Add(new Vertex());

            //Vertexs[0].edges.Add(Vertexs[1]);
            //Vertexs[0].edges.Add(Vertexs[2]);

            //Vertexs[1].edges.Add(Vertexs[2]);
            //Vertexs[1].edges.Add(Vertexs[3]);

            //Vertexs[2].edges.Add(Vertexs[0]);
            //Vertexs[2].edges.Add(Vertexs[2]);
            //Vertexs[2].edges.Add(Vertexs[3]);

            //Vertexs[3].edges.Add(Vertexs[4]);

            // 아래는 위와 같다.

            List<int>[] adj = new List<int>[5] {
                new List<int> { 1, 2 },
                new List<int> { 2, 3 },
                new List<int> { 0, 2, 3 },
                new List<int> { 4 },
                new List<int> { }
            };

            // 아래는 가중치까지 표현한 것 (아래 방식은 잘 안씀)

            List<Edge>[] edgeAdj = new List<Edge>[5] {
                new List<Edge> { new Edge(1, 2), new Edge(2, 3) },
                new List<Edge> { new Edge(2, 7), new Edge(3, 26) },
                new List<Edge> { new Edge(0, 3), new Edge(3, 12) },
                new List<Edge> { new Edge(4, 9) },
                new List<Edge> { }
            };

            // 위에 것들은 리스트를 썻지만, 아래부턴 배열을 쓴다.

            // 인덱싱 연결방법
            int[,] arrAdj1 = new int[5, 5] {
                { 0, 1, 1, 0, 0 }, // 0번점 표시, 비트표현
                { 1, 0, 1, 1, 0 }, // 1번점 표시
                { 1, 1, 0, 1, 0 }, // 2번점 표시
                { 0, 1, 1, 0, 1 }, // 3번점 표시
                { 0, 0, 0, 1, 0 } // 4번점 표시
            };

            // 가중치를 넣고 싶다면?
            int[,] arrAdj2 = new int[5, 5] {
                { -1, 02, 03, -1, -1 }, // 0번점 표시
                { 02, -1, 07, 26, -1 }, // 1번점 표시
                { 03, 07, -1, 12, -1 }, // 2번점 표시
                { -1, 26, 12, -1, 09 }, // 3번점 표시
                { -1, -1, -1, 09, -1 } // 4번점 표시
            };
            // 0 => -1 // 이건 나올 수 없는 수다 = 끊김
            // 대각은 끊겨있고(본인이라), 대각선 대칭이 나온다
            // 1의 자리는 가독성을 위해 앞에 0을 붙여줌
        }
    }
}
