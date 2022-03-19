using static System.Console;
using Mascotas.Models;

namespace Mascotas.UI.Console;

public class Controller 
{
    private View _view;
    private Manager _manager;
    private Dictionary<string, Action> _useCases;

    public Controller(View view, Manager manager)
    {
        _view = view;
        _manager = manager;
        _useCases = new Dictionary<string, Action>() {
            { "Alta de Socio",    AddMember },
            { "Baja de Socio",    RemoveMember },
            { "Alta de Mascota",  AddPet },
            { "Baja de Mascota",  () => WriteLine("BM") },
            { "Añadir Especie",   () => WriteLine("AE") },
            { "Eliminar Especie", () => WriteLine("AE") },
            { "Comprar Mascota",  () => WriteLine("CM") },
            { "Mostrar Mascotas", () => WriteLine("MM") }
        };
    }

    public void Run() 
    {
        var menu = _useCases.Keys.ToList<String>();
        while (true) 
        {
            try 
            {
                _view.ClearScreen();

                var key = _view.TryGetListItem("Menu", menu, "Selecciona una opcion");
                _view.Show("");

                _useCases[key].Invoke();
                _view.ShowAndReturn("Pulsa <Return> para continuar", ConsoleColor.DarkGray);
            }
            catch { return; }
        }
    }

    private void AddMember() 
    {
        try
        {
            var member = new Member(
                id:     Guid.NewGuid(),
                name:   _view.TryGetInput<string>("Nombre"),
                gender: _view.TryGetChar("Sexo", "HM", 'H')
            );

            _manager.AddMember(member);
        }
        catch (Exception e)
        {
            _view.Show($"UC: {e.Message}");
        }
    }

    private void RemoveMember() 
    {
        try
        {
            var member = _view.TryGetListItem("Socios", _manager.Members, "Selecciona un socio"); 
            _manager.RemoveMember(member);
        }
        catch (Exception e)
        {
            _view.Show($"UC: {e.Message}");
        }
    }

    private void AddPet()
    {
        try
        {
            if (_manager.Species.Count == 0)
                throw new Exception("No hay ninguna especie registrada.");

            var pet = new Pet(
                id:        Guid.NewGuid(),
                name:      _view.TryGetInput<string>("Nombre"),
                gender:    _view.TryGetChar("Sexo", "HM", 'H'),
                specieID:  _view.TryGetListItem("Especies", _manager.Species, "Selecciona una especie").ID,
                birthdate: _view.TryGetDate("Fecha de Nacimiento"),
                memberID:  null
            );
            _manager.AddPet(pet);
        }
        catch (Exception e)
        {
            _view.Show($"{e.Message}", ConsoleColor.DarkRed);
        }
    }
}
