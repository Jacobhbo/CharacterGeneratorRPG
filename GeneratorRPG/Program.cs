using GeneratorRPG;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Character firstChar = new Character();

//The method is static, so it runs on the class and not the object
firstChar.CharacterClass = Character.GetCharacterClassRandomly();
firstChar.Stats.GetRolled();
firstChar.Stats.Dexterity = 1;


Console.WriteLine(firstChar.Name);
