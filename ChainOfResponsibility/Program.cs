using ChainOfResponsibility;

var goblin  = new Creature("Goblin", 1, 1);
Console.WriteLine(goblin);
var root = new CreatureModifier(goblin);
root.Add(new DoubleAttackModifier(goblin));
root.Add(new DoubleAttackModifier(goblin));
root.Handle();
Console.WriteLine(goblin);