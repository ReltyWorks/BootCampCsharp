namespace _0729_02 {
    class Program {

        enum Game {
            scissors = 1,
            rock,
            paper,
        }

        // 상수
        const string scissorsText = "가위";
        const string rockText = "바위";
        const string paperText = "보";

        static void Main(string[] args) {

            Console.WriteLine("========================================");
            Console.WriteLine($"{scissorsText} {rockText} {paperText} 게임 (1:{scissorsText}, 2:{rockText}, 3:{paperText})");
            Console.WriteLine("========================================");

            // 컴퓨터 선택
            Random rand = new Random();
            int comChoice = rand.Next(1, 4);

            Console.Write("선택하세요 : ");

            // 유저 선택
            int userChoice = 0;
            while (true) {
                userChoice = int.Parse(Console.ReadLine());
                if (userChoice == (int)Game.scissors || userChoice == (int)Game.rock || userChoice == (int)Game.paper) break;
                Console.WriteLine("잘못된 입력입니다. 1~3 중 하나만 입력해주세요.");
            }

            // 컴퓨터 선택 출력
            if (comChoice == (int)Game.scissors) Console.WriteLine("컴퓨터는 가위를 냈습니다.");
            else if (comChoice == (int)Game.rock) Console.WriteLine("컴퓨터는 바위를 냈습니다.");
            else Console.WriteLine("컴퓨터는 보를 냈습니다.");

            // 결과 출력
            switch (userChoice) {
                case (int)Game.scissors:
                    if (comChoice == (int)Game.scissors) Console.WriteLine("비겼습니다.");
                    else if (comChoice == (int)Game.rock) Console.WriteLine("당신이 졌습니다..");
                    else Console.WriteLine("당신이 이겼습니다!");
                    break;

                case (int)Game.rock:
                    if (comChoice == (int)Game.rock) Console.WriteLine("비겼습니다.");
                    else if (comChoice == (int)Game.paper) Console.WriteLine("당신이 졌습니다..");
                    else Console.WriteLine("당신이 이겼습니다!");
                    break;

                case (int)Game.paper:
                    if (comChoice == (int)Game.paper) Console.WriteLine("비겼습니다.");
                    else if (comChoice == (int)Game.scissors) Console.WriteLine("당신이 졌습니다..");
                    else Console.WriteLine("당신이 이겼습니다!");
                    break;
            }
        }
    }
}