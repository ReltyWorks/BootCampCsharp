namespace _0806_02 { // 문제문제문제
    public enum MagicType {
        None, Fireball, Icebolt, Heal,
    }
    public class Wizard {
        public int mp;
        public int intelligence;

        public Wizard() {
            mp = 50;
            intelligence = 20;
        }
    }

    public class Archer {
        public int hp;
        public int dexterity;

        public Archer() {
            hp = 70;
            dexterity = 30;
        }
        public Archer(int a, int b) {
            this.hp = a;
            this.dexterity = b;
        }
    }

    public class Paladin {
        public int hp;
        public int atk;
        public int def;
        public Paladin() {
            def = 5;
            Console.WriteLine("Paladin 기본 생성자 호출");
        }
        public Paladin(int a, int b) : this() {
            this.hp = a;
            this.atk = b;
            Console.WriteLine("Paladin 커스텀 생성자 호출");
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Wizard wizard = new Wizard();
            Console.WriteLine($"위자드 : 마나 {wizard.mp}, 인트 {wizard.intelligence}");
            Archer archerA = new Archer();
            Archer archerB = new Archer(90, 45);
            Console.WriteLine($"기본 궁수 : 체력 {archerA.hp}, 민첩 {archerA.dexterity}");
            Console.WriteLine($"커스텀 궁수 : 체력 {archerB.hp}, 민첩 {archerB.dexterity}");
            Paladin paladin = new Paladin(150, 30);
            Console.WriteLine($"성기사 : 체력 {paladin.hp}, 공격 {paladin.atk}, 방어 {paladin.def}");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine(CastSpell(MagicType.Fireball, ref wizard.mp));
            Console.WriteLine(CastSpell(MagicType.Heal, ref wizard.mp));
            Console.WriteLine(CastSpell(MagicType.Icebolt, ref wizard.mp));
            Console.WriteLine(CastSpell(MagicType.Icebolt, ref wizard.mp));

        }

        static string CastSpell(MagicType magic, ref int mana) {
            string spellName = "";
            int spellCost = 0;

            switch (magic) {
                case MagicType.Fireball:
                    spellName = "파이어 볼";
                    spellCost = 20;
                    break;
                case MagicType.Icebolt:
                    spellName = "아이스 볼트";
                    spellCost = 15;
                    break;
                case MagicType.Heal:
                    spellName = "힐";
                    spellCost = 10;
                    break;
            }
            if (spellCost > mana) return $"{spellName} 시전! 실패, 마나가 부족합니다.";

            mana -= spellCost;

            return $"{spellName} 시전! 마나가 {spellCost} 줄어듭니다. 남은 마나 {mana}";
        }
    }
}