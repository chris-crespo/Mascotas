using Mascotas;
using Mascotas.UI.Console;
using Mascotas.Data;

var memberRepo = new MemberRepo();
var petRepo    = new PetRepo();
var specieRepo = new SpecieRepo();

var view = new View();
var system = new Manager(memberRepo, petRepo, specieRepo);
var controller = new Controller(view, system);

#if !check
controller.Run();
#endif
