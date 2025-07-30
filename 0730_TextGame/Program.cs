using System;

namespace _0730_TextGame { // 텍스트 미니 게임
    internal class Program {

        static string[] classInfo = { "선택안됨", "전사", "마법사",
        "도둑", "궁수", "사제", "성기사", "백수" };
        static int[] maxAtt = { 0, 13, 13, 11, 11, 9, 13, 9 };
        static int[] minAtt = { 0, 5, 7, 8, 9, 4, 6, 3 };
        static int[] def = { 0, 3, 2, 3, 3, 4, 5, 1 };
        static int[] maxHp = { 0, 80, 50, 60, 60, 100, 70, 30 };
        static int[] mobHP = { 0, 40, 30, 20 };
        static int[] mobAtt = { 0, 7, 5, 3 };
        static string[] mobInfo = { "선택안됨", "스켈레톤", "고블린", "슬라임" };

        static int j = 0;
        static int mj = 0;
        static int hp = 0;
        static int monsterHp = 0;
        static int progress = 0;
        static int battleCount = 0;

        static Random rand = new Random();

        // 진입점
        static void Main(string[] args) {
            do {
                Console.Clear();
                ChoseJob();
            } while (progress == 0);
        }

        // 클래스 선택
        static void ChoseJob() {
            bool GetJob = false;
            byte errorCount = 0;
            // 텍스트 부분
            while (!GetJob) {
                Console.WriteLine("================================");
                Console.WriteLine("       직업을 선택하세요!");
                Console.WriteLine($"[1] {classInfo[1]} / [2] {classInfo[2]} / [3] {classInfo[3]}");
                Console.WriteLine($"[4] {classInfo[4]} / [5] {classInfo[5]} / [6] {classInfo[6]}");
                Console.WriteLine($"[7] {classInfo[7]}");
                Console.WriteLine("================================");

                // 선택 부분
                while (true) {
                    Console.Write(">>");
                    j = int.Parse(Console.ReadLine());
                    if (j >= 1 && j <= 7) {
                        GetJob = true;
                        break;
                    }
                    errorCount++;
                    if (errorCount < 10) Console.WriteLine("Sys> 1 ~ 7 말고 다른 숫자가 보이나요?");
                    else {
                        Console.Clear();
                        Console.WriteLine("Sys> 무슨 문제라도 있습니까? 휴먼?");
                        errorCount = 0;
                        break;
                    }
                }
            }
            progress++;
            hp = maxHp[j];
            Status();
            battleField();
        }

        static void Status() {
            // 호출 시 항상 보여줄 화면
            Console.Clear();
            if (progress == 3) BattleAction(ref hp);
            Console.WriteLine("================================");
            Console.WriteLine($"직업 : {classInfo[j]}  /  H P : {hp} / {maxHp[j]}");
            Console.WriteLine($"공격력 : {minAtt[j]} ~ {maxAtt[j]}  /  방어력 : {def[j]}");
            Console.WriteLine("================================");

            // 직업 선택에서 호출한 경우에 한번만
            if (progress == 1) {
                Console.WriteLine($"Sys> {classInfo[j]}을 선택하셨습니다.");
                progress++;
            }
        }

        static void battleField() {
            Status();
            Console.WriteLine("사냥터에 도착했습니다.");

            mj = rand.Next(1, 4);
            monsterHp = mobHP[mj];
            Console.WriteLine($"{mobInfo[mj]}이 스폰되었습니다.");
            Console.WriteLine($"{mobInfo[mj]}  /  Hp {monsterHp} ATK {mobAtt[mj]}");
            Console.WriteLine("================================");
            Console.WriteLine("[1] 전투 시작");
            Console.WriteLine("[2] 로비로 돌아가기");

            Console.Write(">>");
            int temp = int.Parse(Console.ReadLine());
            if (temp == 1) {
                progress++;
                Battle();
            } else progress = 0;
        }

        static void Battle() {
            while (true) {
                Status();
                Console.WriteLine($"{mobInfo[mj]}이 달려듭니다.");
                Console.WriteLine($"{mobInfo[mj]}  /  Hp {monsterHp} ATK {mobAtt[mj]}");
                Console.WriteLine("================================");
                if(progress == 4) {
                    if (hp <= 0) {
                        Console.WriteLine("악! 너무 아프다!");
                        break;
                    }
                    else {
                        Console.WriteLine("이겼다!");
                        break;
                    }
                }
                Console.WriteLine("[1] 자세를 잡는다.");
                Console.WriteLine("[2] 겁쟁이가 된다.");

                Console.Write(">>");
                int temp = int.Parse(Console.ReadLine());
                if (temp != 1) {
                    progress = 0;
                    break;
                } 
            }
        }
        static void BattleAction(ref int n) {
            int damage = rand.Next(minAtt[j], maxAtt[j] + 1);
            int ruin = mobAtt[mj] - def[j];
            monsterHp -= damage;
            if (ruin > 0) n -= ruin;
            if (n <= 0 || monsterHp <= 0) progress++;
        }
    }
}