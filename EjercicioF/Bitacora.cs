namespace GuiaEjercitacion2.EjercicioF
{
    public class Bitacora
    {
        private static Bitacora _instancia;
        private readonly List<string> _registros = new List<string>();

        private Bitacora() { }

        public static Bitacora Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Bitacora();
                return _instancia;
            }
        }

        public void Registrar(string texto)
            => _registros.Add($"{_registros.Count + 1:00}. {texto}");

        public void MostrarTodo()
        {
            Console.WriteLine("--- Bitácora ---");
            foreach (string registro in _registros)
                Console.WriteLine(registro);
        }

    }
}
