using Command;

var ba = new BankAccount();
var cmd = new BankAccountCommand(
    ba, BankAccountCommand.Action.Deposit, 100);
cmd.Call();
Console.WriteLine(ba);
cmd = new BankAccountCommand(
    ba, BankAccountCommand.Action.Withdraw, 1000);
cmd.Call();
Console.WriteLine(ba);
cmd.Undo();
Console.WriteLine(ba);