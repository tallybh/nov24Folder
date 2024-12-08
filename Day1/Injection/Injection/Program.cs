using Injection;

var p = new Print(new SmsPrinter());
var p1 = new Print(new ConsolePrinter());
//p.Printing();
//p1.Printing();

p.MethodInjection(new SmsPrinter());
p.MethodInjection(new ConsolePrinter());