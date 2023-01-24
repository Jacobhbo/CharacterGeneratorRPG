using GeneratorRPG;
// Kom til at slette første del jeg lavede :(
namespace GeneratorRPG
{
    internal class Character
    {
        //Because the method that uses this array is static, we also make the array static.
        private static string[] characterClass = { "Warrior", "Wizard", "Priest", "Rouge", "Summoner", "Druid", "Ranger" };
        public static Random random = new Random();

        public string Name { get; set; } = "NoNameYet";
        public string CharacterClass { get; set; }
        public DateTime Birthday { get; set; }
        public Stats Stats { get; set; } = new();
        public string V { get; }


        public Character()
        {
            GetRandomBirthday();
            Name = RandomNameGenerator(3, 8);
        }

        public Character(string v)
        {
            V = v;
        }

        private string RandomNameGenerator(int v1, int v2)
        {
            //0-5 vowels 6-end consonant
            char[] letters = { 'a', 'e', 'i', 'o', 'u', 'y', 'b', 'c', 'd', 'f', 'g', 'h',
                'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

            int length = random.Next(v1, v2 + 1);
            int StartLetter = random.Next(letters.Length);
            bool isVowel = StartLetter < 6 ? true : false;
            string name = letters[StartLetter].ToString().ToUpper();
            for (int i = 0; i < length; i++)
            {
                if (isVowel)
                {
                    name += letters[random.Next(6, letters.Length)];
                    isVowel = false;
                }
                else
                {
                    name += letters[random.Next(0, 6)];
                    isVowel = true;
                }
            }
            return name;
        }

        private void GetRandomBirthday()
        {
            DateTime start = new DateTime(1020, 1, 1);
            DateTime end = new DateTime(1120, 1, 1);
            int range = (end - start).Days;
            int days = random.Next(range);
            Birthday = start.AddDays(days);
        }

        //Static method runs on class and not on object
        public static string GetCharacterClassRandomly()
        {
            int r = random.Next(characterClass.Length);
            string cc = characterClass[r];
            return cc;

            //return characterClass[new Random().Next(characterClass.Length)];
        }
        public void RollDiceForStats(int Stats)
        {
            Random random = new Random();
            Stats = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        }
        public int CalculateAge(DateTime birthdate)
        {
            int age = 0;
            age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
                age = age - 1;
            return age;
        }
        public void ShowCharacter()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Stats: {0}", Stats);
        }
        // A 'List<Character>' called 'party' is created and two new 'character' objects are added to the list with names
        static void Main(string[] args)
        {
            List<Character> party = new List<Character>();
            party.Add(new Character("Alice"));
            party.Add(new Character("Bob"));

            Console.WriteLine("Party Members:");
            foreach (Character character in party)
            {
                Console.WriteLine("{0}, Stats: {1}", character.Name, character.Stats);
            }

        }
    }
}