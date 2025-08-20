namespace _0820_TRPG {
    #region Enum
    public enum GameMode {
        Lobby,
        Town,
        Field
    }

    enum CreatureType {
        None,
        Player,
        Monster
    }

    enum PlayerType {
        None,
        Knight,
        Archer,
        Mage
    }

    enum MonsterType {
        None,
        Slime,
        Orc,
        Skeleton
    }
    #endregion

    #region Creature
    class Creature {
        protected CreatureType creatureType = CreatureType.None;
        public int hp = 0;
        public int atk = 0;

        protected Creature(CreatureType ct) {
            creatureType = ct;
        }

        protected void SetStat(int h, int a) {
            hp = h;
            atk = a;
        }

        public int GetHp() => hp;

        public int GetAtk() => atk;

        public bool IsDead() => hp <= 0;

        public void OnDamaged(int dmg) {
            if (hp >= dmg) hp -= dmg;
            else hp = 0;
        }
    }
    #endregion

    #region Player
    class Player : Creature {
        PlayerType playerType = PlayerType.None;

        public Player(PlayerType pt) : base(CreatureType.Player) {
            playerType = pt;
        }
    }

    class Knight : Player {
        public Knight() : base(PlayerType.Knight) {
            SetStat(100, 10);
        }
    }

    class Archer : Player {
        public Archer() : base(PlayerType.Archer) {
            SetStat(75, 12);
        }
    }

    class Mage : Player {
        public Mage() : base(PlayerType.Mage) {
            SetStat(50, 15);
        }
    }
    #endregion

    #region Monster
    class Monster : Creature {
        MonsterType monsterType = MonsterType.None;

        protected Monster(MonsterType mt) : base(CreatureType.Monster) {
            monsterType = mt;
        }

        MonsterType GetMonsterType() => monsterType;
    }

    class Slime : Monster {
        public Slime() : base(MonsterType.Slime) {
            SetStat(10, 1);
        }
    }

    class Orc : Monster {
        public Orc() : base(MonsterType.Orc) {
            SetStat(20, 2);
        }
    }

    class Skeleton : Monster {
        public Skeleton() : base(MonsterType.Skeleton) {
            SetStat(15, 5);
        }
    }
    #endregion

    #region Game
    class Game {
        GameMode mode = GameMode.Lobby;
        Player player = null;
        Monster monster = null;
        Random rand = new Random();

        public void Process() {
            if (mode == GameMode.Town) ProcessTown(); 
            else if (mode == GameMode.Field) ProcessField();
            else ProcessLobby();
        }

        void ProcessLobby() {
            Console.WriteLine("직업을 선택하세요.\n[1] 기사, [2] 궁수, [3] 법사");
            string input = Console.ReadLine();
            int.TryParse(input, out int inputNum);
            if (inputNum == 1) {
                player = new Knight();
                mode = GameMode.Town;
            }
            else if (inputNum == 2) {
                player = new Archer();
                mode = GameMode.Town;
            }
            else if (inputNum == 3) {
                player = new Mage();
                mode = GameMode.Town;
            }
            else Console.WriteLine("!! 1 ~ 3사이에 숫자를 입력하세요. !!\n직업을 선택하세요.\n[1] 기사, [2] 궁수, [3] 법사");
        }

        void ProcessTown() {
            Console.WriteLine("마을에 입장했습니다.\n[1] 필드로 가기, [2] 로비로 돌아가기");
            string input = Console.ReadLine();
            int.TryParse(input, out int inputNum);
            if (inputNum == 1) {
                mode = GameMode.Field;
            }
            else if (inputNum == 2) {
                mode = GameMode.Lobby;
            }
            else Console.WriteLine("!! 1 ~ 2사이에 숫자를 입력하세요. !!\n마을에 입장했습니다.\n[1] 필드로 가기, [2] 로비로 돌아가기");
        }

        void ProcessField() {
            Console.WriteLine("필드에 입장했습니다.\n[1] 싸우기, [2] 일정 확률로 마을로 도망가기");
            CreateRandomMonster();
            string input = Console.ReadLine();
            int.TryParse(input, out int inputNum);
            if (inputNum == 1) {
                ProcessFight();
            }
            else if (inputNum == 2) {
                TryEscape();
            }
            else Console.WriteLine("!! 1 ~ 2사이에 숫자를 입력하세요. !!\n필드에 입장했습니다.\n[1] 싸우기, [2] 일정 확률로 마을로 도망가기");
        }

        void CreateRandomMonster() {
            int gen = rand.Next(0, 3);
            if (gen == 0) {
                monster = new Slime();
                Console.WriteLine("슬라임이 생성되었습니다.");
            }
            else if (gen == 1) {
                monster = new Orc();
                Console.WriteLine("오크가 생성되었습니다.");
            }
            else if (gen == 2) {
                monster = new Skeleton();
                Console.WriteLine("스켈레톤이 생성되었습니다.");
            }
        }

        private void ProcessFight() {
            while (true) {
                monster.OnDamaged(player.GetAtk());
                if (monster.IsDead()) {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 HP: {player.GetHp()}");
                    break;
                }
                player.OnDamaged(monster.GetAtk());
                if (player.IsDead()) {
                    Console.WriteLine("패배했습니다..");
                    Console.WriteLine($"남은 HP: {player.GetHp()}");
                    mode = GameMode.Lobby;
                    break;
                }
                Console.WriteLine($"플레이어 HP: {player.GetHp()} / 몬스터 HP: {monster.GetHp()}");
            }
        }

        private void TryEscape() {
            int escapeChance = rand.Next(0, 100);
            if (escapeChance < 33) {
                Console.WriteLine("도망에 성공했습니다! 마을로 돌아갑니다.");
                mode = GameMode.Town;
            }
            else {
                Console.WriteLine("도망에 실패했습니다! 전투를 시작합니다.");
                ProcessFight();
            }
        }
    }
#endregion

    class Program {
        static void Main() {
            Game game = new Game();
            while (true) { game.Process(); }
        }
    }
}