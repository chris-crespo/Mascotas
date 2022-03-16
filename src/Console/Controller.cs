using static System.Console;

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
            { "Alta de Socio",    AddMember},
            { "Baja de Socio",    () => WriteLine("BS") },
            { "Alta de Mascota",  () => WriteLine("AM") },
            { "Baja de Mascota",  () => WriteLine("BM") },
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
            var id        = Guid.NewGuid();
            var name      = _view.TryGetInput<string>("Nombre");
            var sexo      = _view.TryGetChar("Sexo", "HM", 'H');
            var birthdate = _view.TryGetDate("Fecha de Nacimiento");

            var member = new Member
            {
                id        = id,
                name      = name,
                sexo      = sexo,
                birthdate = birthdate
            };

            _manager.AddMember(member);
        }
        catch (Exception e)
        {
            _view.Show($"UC: {e.Message}");
        }
    }
}
