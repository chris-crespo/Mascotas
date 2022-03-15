using Mascotas;
using Mascotas.UI.Console;

var view = new View();
var system = new Manager();
var controller = new Controller(view, system);

#if !check
controller.Run();
#endif
