using NullObject;

//var log = new ConsoleLog();
//ILog log = null;

var log = new NullLog();
var ba = new BankAccount(log);
ba.Deposit(100);
ba.Withdraw(200);
